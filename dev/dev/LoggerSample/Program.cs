﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Logger;
using Logger.Interface;

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
			SetUpLogger(new Logger.Console.DebugLog());
            SetUpLogger(new Logger.Console.Log());
			SetUpLogger(new Logger.File.Log());

			var sampleClass = new LoggerSampleClass();
			sampleClass.Sample();

			return;
		}

	}
}
