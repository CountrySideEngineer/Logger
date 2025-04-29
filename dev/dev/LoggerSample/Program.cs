using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Logger;
using Logger.Interface;
using CS.Logger;

namespace LoggerSample
{
	/// <summary>
	/// Sample program using Logger.dll
	/// </summary>
	public class Program
	{
		static void SetUpLogger(ALog logger)
		{
			Log.AddLogger(logger);
		}

		static void Main(string[] args)
		{
            using var fileLogger = new CS.Logger.File.Log();
            using var debugLogger = new CS.Logger.Console.DebugLog();
            using var consoleLogger = new CS.Logger.Console.Log();

            SetUpLogger(debugLogger);
            SetUpLogger(consoleLogger);
            SetUpLogger(fileLogger);

            var sampleClass = new LoggerSampleClass();
            sampleClass.Sample();

            return;
		}

	}
}
