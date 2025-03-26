using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Logger.Console
{
	/// <summary>
	/// Log class to output message into console, standard output.
	/// </summary>
	public class Log : ALog
	{
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Log() : base() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logLevel">Log level to output.</param>
        public Log(LOG_LEVEL logLevel) : base(logLevel) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logLevel">Log level to output.</param>
        public Log(LOG_LEVEL logLevel, bool optionEnable) : base(logLevel, optionEnable) { }

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
