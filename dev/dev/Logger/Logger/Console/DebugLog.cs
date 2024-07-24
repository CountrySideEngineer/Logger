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
		/// ATTENTION!!
		/// This method only outputs a message if the DEBUG constant is defined.
		/// (If the DEBUG constant is not defined, the message is not output.)
		/// </remarks>
		public override void Output(string message)
		{
#if DEBUG
			Debug.WriteLine(message);
#endif
		}
	}
}
