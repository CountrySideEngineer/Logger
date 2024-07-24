#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logger.Console
{
	public class DebugLog : ALog
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DebugLog() : base() { }

		/// <summary>
		/// Output log to debug console.
		/// </summary>
		/// <param name="message">Log message</param>
		/// <remarks>
		/// !ATTENTION!
		/// To use this method, define DEBUG constant.
		/// </remarks>
		public override void Output(string message)
		{
			Debug.WriteLine(message);
		}
	}
}
