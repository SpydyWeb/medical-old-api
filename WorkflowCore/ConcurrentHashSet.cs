using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowCore
{

	[DebuggerDisplay("Count = {Count}")]
	public class ConcurrentHashSet<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, ICollection<T>
	{
		private class Tables
		{
			public readonly Node[] Buckets;

			public readonly object[] Locks;

			public volatile int[] CountPerLock;

			public Tables(Node[] buckets, object[] locks, int[] countPerLock)
			{
				Buckets = buckets;
				Locks = locks;
				CountPerLock = countPerLock;
			}
		}

		private class Node
		{
			public readonly T Item;

			public readonly int Hashcode;

			public volatile Node Next;

			public Node(T item, int hashcode, Node next)
			{
				Item = item;
				Hashcode = hashcode;
				Next = next;
			}
		}

		private const int DefaultCapacity = 31;

		private const int MaxLockNumber = 1024;

		private readonly IEqualityComparer<T> _comparer;

		private readonly bool _growLockArray;

		private int _budget;

		private volatile Tables _tables;

		private static int DefaultConcurrencyLevel => PlatformHelper.ProcessorCount;

		public int Count
		{
			get
			{
				int num = 0;
				int locksAcquired = 0;
				try
				{
					AcquireAllLocks(ref locksAcquired);
					for (int i = 0; i < _tables.CountPerLock.Length; i++)
					{
						num += _tables.CountPerLock[i];
					}
					return num;
				}
				finally
				{
					ReleaseLocks(0, locksAcquired);
				}
			}
		}

		public bool IsEmpty
		{
			get
			{
				int locksAcquired = 0;
				try
				{
					AcquireAllLocks(ref locksAcquired);
					for (int i = 0; i < _tables.CountPerLock.Length; i++)
					{
						if (_tables.CountPerLock[i] != 0)
						{
							return false;
						}
					}
				}
				finally
				{
					ReleaseLocks(0, locksAcquired);
				}
				return true;
			}
		}

		bool ICollection<T>.IsReadOnly => false;

		public ConcurrentHashSet()
			: this(DefaultConcurrencyLevel, 31, growLockArray: true, (IEqualityComparer<T>)null)
		{
		}

		public ConcurrentHashSet(int concurrencyLevel, int capacity)
			: this(concurrencyLevel, capacity, growLockArray: false, (IEqualityComparer<T>)null)
		{
		}

		public ConcurrentHashSet(IEnumerable<T> collection)
			: this(collection, (IEqualityComparer<T>)null)
		{
		}

		public ConcurrentHashSet(IEqualityComparer<T> comparer)
			: this(DefaultConcurrencyLevel, 31, growLockArray: true, comparer)
		{
		}

		public ConcurrentHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
			: this(comparer)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			InitializeFromCollection(collection);
		}

		public ConcurrentHashSet(int concurrencyLevel, IEnumerable<T> collection, IEqualityComparer<T> comparer)
			: this(concurrencyLevel, 31, growLockArray: false, comparer)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			InitializeFromCollection(collection);
		}

		public ConcurrentHashSet(int concurrencyLevel, int capacity, IEqualityComparer<T> comparer)
			: this(concurrencyLevel, capacity, growLockArray: false, comparer)
		{
		}

		private ConcurrentHashSet(int concurrencyLevel, int capacity, bool growLockArray, IEqualityComparer<T> comparer)
		{
			if (concurrencyLevel < 1)
			{
				throw new ArgumentOutOfRangeException("concurrencyLevel");
			}
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if (capacity < concurrencyLevel)
			{
				capacity = concurrencyLevel;
			}
			object[] array = new object[concurrencyLevel];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new object();
			}
			int[] countPerLock = new int[array.Length];
			Node[] array2 = new Node[capacity];
			_tables = new Tables(array2, array, countPerLock);
			_growLockArray = growLockArray;
			_budget = array2.Length / array.Length;
			_comparer = comparer ?? EqualityComparer<T>.Default;
		}

		public bool Add(T item)
		{
			return AddInternal(item, _comparer.GetHashCode(item), acquireLock: true);
		}

		public void Clear()
		{
			int locksAcquired = 0;
			try
			{
				AcquireAllLocks(ref locksAcquired);
				Tables tables = (_tables = new Tables(new Node[31], _tables.Locks, new int[_tables.CountPerLock.Length]));
				_budget = Math.Max(1, tables.Buckets.Length / tables.Locks.Length);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		public bool Contains(T item)
		{
			int hashCode = _comparer.GetHashCode(item);
			Tables tables = _tables;
			int bucket = GetBucket(hashCode, tables.Buckets.Length);
			for (Node node = Volatile.Read(ref tables.Buckets[bucket]); node != null; node = node.Next)
			{
				if (hashCode == node.Hashcode && _comparer.Equals(node.Item, item))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryRemove(T item)
		{
			int hashCode = _comparer.GetHashCode(item);
			while (true)
			{
				Tables tables = _tables;
				GetBucketAndLockNo(hashCode, out var bucketNo, out var lockNo, tables.Buckets.Length, tables.Locks.Length);
				lock (tables.Locks[lockNo])
				{
					if (tables != _tables)
					{
						continue;
					}
					Node node = null;
					for (Node node2 = tables.Buckets[bucketNo]; node2 != null; node2 = node2.Next)
					{
						if (hashCode == node2.Hashcode && _comparer.Equals(node2.Item, item))
						{
							if (node == null)
							{
								Volatile.Write(ref tables.Buckets[bucketNo], node2.Next);
							}
							else
							{
								node.Next = node2.Next;
							}
							tables.CountPerLock[lockNo]--;
							return true;
						}
						node = node2;
					}
					break;
				}
			}
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			Node[] buckets = _tables.Buckets;
			for (int i = 0; i < buckets.Length; i++)
			{
				for (Node current = Volatile.Read(ref buckets[i]); current != null; current = current.Next)
				{
					yield return current.Item;
				}
			}
		}

		void ICollection<T>.Add(T item)
		{
			Add(item);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			int locksAcquired = 0;
			try
			{
				AcquireAllLocks(ref locksAcquired);
				int num = 0;
				for (int i = 0; i < _tables.Locks.Length; i++)
				{
					if (num < 0)
					{
						break;
					}
					num += _tables.CountPerLock[i];
				}
				if (array.Length - num < arrayIndex || num < 0)
				{
					throw new ArgumentException("The index is equal to or greater than the length of the array, or the number of elements in the set is greater than the available space from index to the end of the destination array.");
				}
				CopyToItems(array, arrayIndex);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		bool ICollection<T>.Remove(T item)
		{
			return TryRemove(item);
		}

		private void InitializeFromCollection(IEnumerable<T> collection)
		{
			foreach (T item in collection)
			{
				AddInternal(item, _comparer.GetHashCode(item), acquireLock: false);
			}
			if (_budget == 0)
			{
				_budget = _tables.Buckets.Length / _tables.Locks.Length;
			}
		}

		private bool AddInternal(T item, int hashcode, bool acquireLock)
		{
			checked
			{
				Tables tables;
				bool flag;
				while (true)
				{
					tables = _tables;
					GetBucketAndLockNo(hashcode, out var bucketNo, out var lockNo, tables.Buckets.Length, tables.Locks.Length);
					flag = false;
					bool lockTaken = false;
					try
					{
						if (acquireLock)
						{
							Monitor.Enter(tables.Locks[lockNo], ref lockTaken);
						}
						if (tables != _tables)
						{
							continue;
						}
						for (Node node = tables.Buckets[bucketNo]; node != null; node = node.Next)
						{
							if (hashcode == node.Hashcode && _comparer.Equals(node.Item, item))
							{
								return false;
							}
						}
						Volatile.Write(ref tables.Buckets[bucketNo], new Node(item, hashcode, tables.Buckets[bucketNo]));
						tables.CountPerLock[lockNo]++;
						if (tables.CountPerLock[lockNo] > _budget)
						{
							flag = true;
						}
						break;
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(tables.Locks[lockNo]);
						}
					}
				}
				if (flag)
				{
					GrowTable(tables);
				}
				return true;
			}
		}

		private static int GetBucket(int hashcode, int bucketCount)
		{
			return (hashcode & 0x7FFFFFFF) % bucketCount;
		}

		private static void GetBucketAndLockNo(int hashcode, out int bucketNo, out int lockNo, int bucketCount, int lockCount)
		{
			bucketNo = (hashcode & 0x7FFFFFFF) % bucketCount;
			lockNo = bucketNo % lockCount;
		}

		private void GrowTable(Tables tables)
		{
			int locksAcquired = 0;
			try
			{
				AcquireLocks(0, 1, ref locksAcquired);
				if (tables != _tables)
				{
					return;
				}
				long num = 0L;
				for (int i = 0; i < tables.CountPerLock.Length; i++)
				{
					num += tables.CountPerLock[i];
				}
				if (num < tables.Buckets.Length / 4)
				{
					_budget = 2 * _budget;
					if (_budget < 0)
					{
						_budget = int.MaxValue;
					}
					return;
				}
				int j = 0;
				bool flag = false;
				try
				{
					for (j = checked(tables.Buckets.Length * 2 + 1); j % 3 == 0 || j % 5 == 0 || j % 7 == 0; j = checked(j + 2))
					{
					}
					if (j > 2146435071)
					{
						flag = true;
					}
				}
				catch (OverflowException)
				{
					flag = true;
				}
				if (flag)
				{
					j = 2146435071;
					_budget = int.MaxValue;
				}
				AcquireLocks(1, tables.Locks.Length, ref locksAcquired);
				object[] array = tables.Locks;
				if (_growLockArray && tables.Locks.Length < 1024)
				{
					array = new object[tables.Locks.Length * 2];
					Array.Copy(tables.Locks, 0, array, 0, tables.Locks.Length);
					for (int k = tables.Locks.Length; k < array.Length; k++)
					{
						array[k] = new object();
					}
				}
				Node[] array2 = new Node[j];
				int[] array3 = new int[array.Length];
				for (int l = 0; l < tables.Buckets.Length; l++)
				{
					Node node = tables.Buckets[l];
					checked
					{
						while (node != null)
						{
							Node next = node.Next;
							GetBucketAndLockNo(node.Hashcode, out var bucketNo, out var lockNo, array2.Length, array.Length);
							array2[bucketNo] = new Node(node.Item, node.Hashcode, array2[bucketNo]);
							array3[lockNo]++;
							node = next;
						}
					}
				}
				_budget = Math.Max(1, array2.Length / array.Length);
				_tables = new Tables(array2, array, array3);
			}
			finally
			{
				ReleaseLocks(0, locksAcquired);
			}
		}

		private void AcquireAllLocks(ref int locksAcquired)
		{
			AcquireLocks(0, 1, ref locksAcquired);
			AcquireLocks(1, _tables.Locks.Length, ref locksAcquired);
		}

		private void AcquireLocks(int fromInclusive, int toExclusive, ref int locksAcquired)
		{
			object[] locks = _tables.Locks;
			for (int i = fromInclusive; i < toExclusive; i++)
			{
				bool lockTaken = false;
				try
				{
					Monitor.Enter(locks[i], ref lockTaken);
				}
				finally
				{
					if (lockTaken)
					{
						locksAcquired++;
					}
				}
			}
		}

		private void ReleaseLocks(int fromInclusive, int toExclusive)
		{
			for (int i = fromInclusive; i < toExclusive; i++)
			{
				Monitor.Exit(_tables.Locks[i]);
			}
		}

		private void CopyToItems(T[] array, int index)
		{
			Node[] buckets = _tables.Buckets;
			for (int i = 0; i < buckets.Length; i++)
			{
				for (Node node = buckets[i]; node != null; node = node.Next)
				{
					array[index] = node.Item;
					index++;
				}
			}
		}
	}
}
