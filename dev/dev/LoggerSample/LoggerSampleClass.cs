using CSEngineer.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
