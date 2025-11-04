using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowCore
{
	internal static class PlatformHelper
	{
		private const int ProcessorCountRefreshIntervalMs = 30000;

		private static volatile int _processorCount;

		private static volatile int _lastProcessorCountRefreshTicks;

		internal static int ProcessorCount
		{
			get
			{
				int tickCount = Environment.TickCount;
				if (_processorCount == 0 || tickCount - _lastProcessorCountRefreshTicks >= 30000)
				{
					_processorCount = Environment.ProcessorCount;
					_lastProcessorCountRefreshTicks = tickCount;
				}
				return _processorCount;
			}
		}
	}
}
