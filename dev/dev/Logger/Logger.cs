using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace CSEngineer
{
	/// <summary>
	/// Logger class to output log class.
	/// </summary>
	public class _Logger
	{
		#region Private fields and constants
		/// <summary>
		/// Format
		/// </summary>
		private static readonly string DATE_TIME_FORMAT = "yyyy/MM/dd HH:mm:ss.fff";
		#endregion

		#region Public constants
		public enum LogLevel {
			All = 0,
			TRACE = 0,
			DEBUG,
			INFO,
			WARN,
			ERROR,
			FATAL,
			NONE,
			MAX,
		};
		#endregion

		#region properties
		/// <summary>
		/// Current log level.
		/// </summary>
		public static LogLevel Level { get; set; } = LogLevel.INFO;

		/// <summary>
		/// List of TextWriter to output log message.
		/// </summary>
		private static readonly IEnumerable<TextWriter> TextStreams = new List<TextWriter>();

		/// <summary>
		/// List of available log level.
		/// </summary>
		public static readonly IEnumerable<string> AvailableLogLevelList = new List<string>
		{
			LogLevel.TRACE.ToString(),
			LogLevel.DEBUG.ToString(),
			LogLevel.INFO.ToString(),
			LogLevel.WARN.ToString(),
			LogLevel.ERROR.ToString(),
			LogLevel.FATAL.ToString(),
			LogLevel.NONE.ToString()
		};
		#endregion

		#region public library interface.
		/// <summary>
		/// Add TextWriter object to list of text stream.
		/// </summary>
		/// <param name="textStream">Object to add to the list.</param>
		public static void AddStream(TextWriter textStream)
		{
			((List<TextWriter>)Logger.TextStreams).Add(textStream);
		}

		/// <summary>
		/// Remove TextWriter object to list of text stream.
		/// </summary>
		/// <param name="textStream">Object to remove from the list.</param>
		/// <returns>Result of remove.</returns>
		public static bool RemoveStream(TextWriter textStream)
		{
			return ((List<TextWriter>)Logger.TextStreams).Remove(textStream);
		}

		/// <summary>
		/// Output TRACE level log message.
		/// </summary>
		/// <param name="message">Log message</param>
		public static void TRACE(string message)
		{
			WriteLine(message, LogLevel.TRACE);
		}

		/// <summary>
		/// Output DEBUG level log message.
		/// </summary>
		/// <param name="message">Log message</param>
		public static void DEBUG(string message)
		{
			WriteLine(message, LogLevel.DEBUG);
		}

		/// <summary>
		/// Output INFO level log message
		/// </summary>
		/// <param name="message">Log message</param>
		public static void INFO(string messag)
		{
			WriteLine(messag, LogLevel.INFO);
		}

		/// <summary>
		/// Output WARN level log message.
		/// </summary>
		/// <param name="message">Log message</param>
		public static void WARN(string message)
		{
			WriteLine(message, LogLevel.WARN);
		}

		/// <summary>
		/// Output ERROR level log message.
		/// </summary>
		/// <param name="message">Log message</param>
		public static void ERROR(string message)
		{
			WriteLine(message, LogLevel.ERROR);
		}

		/// <summary>
		/// output FATAL level log message.
		/// </summary>
		/// <param name="message">Log message</param>
		public static void FATAL(string message)
		{
			WriteLine(message, LogLevel.FATAL);
		}

		/// <summary>
		/// Output log message in console.
		/// And, if the output stream has been set TextStreams, the log message is written into a stream.
		/// </summary>
		/// <param name="message">Log message</param>
		/// <param name="level">Level of the message.</param>
		protected static void WriteLine(string message, LogLevel level)
		{
			if (level < Logger.Level)
			{
				return;
			}
			else
			{
				string logMessage = $"{DateTime.Now.ToString(DATE_TIME_FORMAT)} [{level.ToString().PadLeft(5)}] : {message}";
				Console.WriteLine(logMessage);
				try
				{
					foreach (var textStream in Logger.TextStreams)
					{
						textStream.WriteLine(logMessage);
					}
				}
				catch (NullReferenceException)
				{
					Debug.WriteLine($"Variable {nameof(TextStreams)} has not been created");
				}
			}
		}
		#endregion
	}
}
