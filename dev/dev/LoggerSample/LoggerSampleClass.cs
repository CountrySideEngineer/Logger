using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log = CS.Logger.Log;

namespace LoggerSample
{
	public class LoggerSampleClass
	{
		public LoggerSampleClass() { }

        public virtual void OutputSamples()
        {
            for (int index = 0; index < 2500; index++)
            {
                Log.TRACE();
                Log.TRACE($"{nameof(index),4} = {index,4} - Sample TRACE message");
                Log.DEBUG($"{nameof(index),4} = {index,4} - Sample DEBUG message");
                Log.INFO($"{nameof(index),4} = {index,4} - Sample INFO message");
                Log.WARN($"{nameof(index),4} = {index,4} - Sample WARN message");
                Log.ERROR($"{nameof(index),4} = {index,4} - Sample ERROR message");
                Log.FATAL($"{nameof(index),4} = {index,4} - Sample FATAL message");
            }
        }

		public void Sample()
		{
            OutputSamples();
		}
	}
}
