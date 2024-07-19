using CSEngineer.Logger.EventArg;
using CSEngineer.Logger.Interface;
using System;

namespace CSEngineer.Logger
{
	public abstract class ALog : ILog, ILogEvent
	{
		/// <summary>
		/// TRACE level log tag.
		/// </summary>
		protected static string _TRACE = "TRACE";

		/// <summary>
		/// DEBUG level log tag.
		/// </summary>
		protected static string _DEBUG = "DEBUG";

		/// <summary>
		/// INFO level log tag.
		/// </summary>
		protected static string _INFO = "INFO ";

		/// <summary>
		/// WARN level log tag.
		/// </summary>
		protected static string _WARN = "WARN ";

		/// <summary>
		/// ERROR level log tag.
		/// </summary>
		protected static string _ERROR = "ERROR";

		/// <summary>
		/// FATAL level log tag.
		/// </summary>
		protected static string _FATAL = "FATAL";

		public bool TraceOfTrace { get; set; } = true;

		public bool TraceOn { get; set; } = true;

		public bool TraceOfDebug { get; set; } = false;

		public bool DebugOn { get; set; } = true;

		public bool TraceOfInfo { get; set; } = false;

		public bool InfoOn { get; set; } = false;

		public bool TraceOfWarn { get; set; } = false;

		public bool WarnOn { get; set; } = true;

		public bool TraceOfError { get; set; } = false;

		public bool ErrorOn { get; set; } = true;

		public bool TraceOfFatal { get; set; } = false;

		public bool FatalOn { get; set; } = true;

		/// <summary>
		/// DEBUG level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public virtual void DEBUG(object sender, EventArgs e)
		{
			if (DebugOn)
			{
				Output(ALog._DEBUG, TraceOfDebug, e);
			}
		}

		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public virtual void DEBUG(string message)
		{
			DEBUG(ALog._DEBUG, new LogEventArgs(message));
		}

		/// <summary>
		/// ERROR level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public virtual void ERROR(object sender, EventArgs e)
		{
			if (ErrorOn)
			{
				Output(ALog._ERROR, TraceOfError, e);
			}
		}

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public virtual void ERROR(string message)
		{
			ERROR(ALog._ERROR, new LogEventArgs(message));
		}

		/// <summary>
		/// FATAL level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public virtual void FATAL(object sender, EventArgs e)
		{
			if (FatalOn)
			{
				Output(ALog._FATAL, TraceOfFatal, e);
			}
		}

		/// <summary>
		/// FATAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public virtual void FATAL(string message)
		{
			FATAL(ALog._FATAL, new LogEventArgs(message));
		}

		/// <summary>
		/// INFO (information) level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public virtual void INFO(object sender, EventArgs e)
		{
			if (InfoOn)
			{
				Output(ALog._INFO, TraceOfInfo, e);
			}
		}

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public virtual void INFO(string message)
		{
			INFO(ALog._INFO, new LogEventArgs(message));
		}

		/// <summary>
		/// TRACE level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public virtual void TRACE(object sende, EventArgs e)
		{
			if (TraceOn)
			{
				Output(ALog._TRACE, TraceOfTrace, e);
			}
		}

		/// <summary>
		/// TRACE level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public virtual void TRACE(string message)
		{
			TRACE(ALog._TRACE, new LogEventArgs(message));
		}

		/// <summary>
		/// WARN (warning) level log event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Log event argument.</param>
		public virtual void WARN(object sender, EventArgs e)
		{
			if (WarnOn)
			{
				Output(ALog._WARN, TraceOfWarn, e);
			}
		}

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public virtual void WARN(string message)
		{
			WARN(ALog._WARN, new LogEventArgs(message));
		}

		/// <summary>
		/// Extract log message from event argument.
		/// </summary>
		/// <param name="e">Event argument.</param>
		/// <returns>Log message.</returns>
		protected virtual string ExtractMessage(EventArgs e)
		{
			try
			{
				var logEventArsg = (LogEventArgs)e;
				string message = logEventArsg.Message;

				return message;
			}
			catch (Exception ex)
			when ((ex is InvalidCastException) || (ex is NullReferenceException))
			{
				string message = "Unknown message received.";
				return message;
			}
			catch (Exception)
			{
				string message = "Invalid message received.";
				return message;
			}
		}

		/// <summary>
		/// Generate message from event arguments.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="traceOfLevel">Bool whether the trace information output or not.</param>
		/// <param name="e">Message source event argument.</param>
		/// <returns>Message</returns>
		protected virtual string GenerateMessage(string level, bool traceOfLevel, EventArgs e)
		{
			string timeStamp = GetTimeStamp();
			string logMessage = $"[{level}][{timeStamp}]";

			try
			{
				var logEventArg = (LogEventArgs)e;
				if (traceOfLevel)
				{
					if ((!string.IsNullOrEmpty(logEventArg.FileName)) &&
						(!string.IsNullOrWhiteSpace(logEventArg.FileName)) &&
						(!string.IsNullOrEmpty(logEventArg.MemberName)) &&
						(!string.IsNullOrWhiteSpace(logEventArg.MemberName)) &&
						(0 < logEventArg.LineNumber)
						)
					{
						string optLog = $"[{logEventArg.FileName}({logEventArg.LineNumber,4})][{logEventArg.MemberName}]";
						logMessage += optLog;
					}
				}
				logMessage += $":{logEventArg.Message}";

				return logMessage;
			}
			catch (Exception ex)
			when ((ex is InvalidCastException) || (ex is NullReferenceException))
			{
				throw new NotSupportedException("Log message invalid.");
			}
		}

		/// <summary>
		/// Output message from event argument.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="e">Event argument.</param>
		protected virtual void Output(string level, bool doesShowTrace, EventArgs e)
		{
			string message = GenerateMessage(level, doesShowTrace, e);
			Output(message);
		}

		/// <summary>
		/// Abstract method to output log message.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="message">Log message.</param>
		public abstract void Output(string message);

		/// <summary>
		/// Default time stamp format.
		/// </summary>
		private static string TIME_STAMP_FORMAT = "yyyy/MM/dd HH:mm:ss.fff";

		/// <summary>
		/// Return time stamp.
		/// </summary>
		/// <returns>Time stamp in string.</returns>
		public virtual string GetTimeStamp()
		{
			string timeStamp = GetTimeStamp(TIME_STAMP_FORMAT);
			return timeStamp;
		}

		/// <summary>
		/// Return time stamp with in a format.
		/// </summary>
		/// <param name="format">Time stamp format.</param>
		/// <returns>Time stamp in string.</returns>
		public virtual string GetTimeStamp(string format)
		{
			string timeStamp = DateTime.Now.ToString(format);
			return timeStamp;
		}
	}
}
