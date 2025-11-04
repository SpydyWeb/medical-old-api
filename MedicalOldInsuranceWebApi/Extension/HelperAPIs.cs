using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceAPIs.Extension
{
	public class HelperAPIs
	{
		public static List<int> CalculateDeltas(List<DateTime> times)
		{
			List<int> time_deltas = new List<int>();
			DateTime prev = times.First();
			foreach (DateTime t in times.Skip(1))
			{
				time_deltas.Add((t - prev).Days);
				prev = t;
			}
			return time_deltas;
		}
	}
}
