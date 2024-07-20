using Logger;

namespace LoggerSample
{
	public class LoggerSampleClass
	{
		public LoggerSampleClass() { }

		public void Sample()
		{
			Log.TRACE("Sample TRACE message");
			Log.DEBUG("Sample DEBUG message");
			Log.INFO("Sample INFO message");
			Log.WARN("Sample WARN message");
			Log.ERROR("Sample ERROR message");
			Log.FATAL("Sample FATAL message");
		}
	}
}
