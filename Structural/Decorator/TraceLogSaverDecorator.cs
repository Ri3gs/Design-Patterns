using System.Diagnostics;
using System.Threading.Tasks;

namespace Structural.Decorator
{
	public class TraceLogSaverDecorator : LogSaverDecorator
	{
		public TraceLogSaverDecorator(ILogSaver decoratee) : base(decoratee)
		{
		}

		public override async Task SaveLogEntry(string applicationId, LogEntry logEntry)
		{
			var watch = Stopwatch.StartNew();
			try
			{
				await _decoratee.SaveLogEntry(applicationId, logEntry);
			}
			finally
			{
				Trace.TraceInformation($"Operation successfully completed in {watch.ElapsedMilliseconds}ms");
			}
		}
	}
}