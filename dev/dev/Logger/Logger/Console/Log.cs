using System;
using System.Collections.Generic;
using System.Text;

namespace CSEngineer.Logger.Console
{
	/// <summary>
	/// Log class to output message into console, standard output.
	/// </summary>
	public class Log : ALog
	{
		/// <summary>
		/// Output log to console.
		/// </summary>
		/// <param name="level">Log level in string.</param>
		/// <param name="message">Log message.</param>
		public override void Output(string message)
		{
			System.Console.WriteLine(message);
		}
	}
}
