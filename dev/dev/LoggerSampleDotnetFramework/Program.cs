using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using CSEngineer;
using CSEngineer.Logger;
using CSEngineer.Logger.Interface;

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
			SetUpLogger(new CSEngineer.Logger.Console.Log()
			{
				TraceOfTrace = true,
				TraceOn = true,
				TraceOfDebug = true,
				DebugOn = false,
				TraceOfFatal = true,
				ErrorOn = false
			});
			SetUpLogger(new CSEngineer.Logger.File.Log());

			var sampleClass = new LoggerSampleClass();
			sampleClass.Sample();

			return;
		}

	}
}
