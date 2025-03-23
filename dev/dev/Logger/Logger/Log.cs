using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Logger.EventArg;

namespace Logger
{
	public class Log
	{
		/// <summary>
		/// Deleagate event handler to raise log message event.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="e">Log message event.</param>
		public delegate void LogMessageEventHandler(object sender, EventArgs e);

		/// <summary>
		/// TRACE log level event handler.
		/// </summary>
		protected event LogMessageEventHandler TraceLogEventHandler;

		/// <summary>
		/// DEBUG log level event handler.
		/// </summary>
		protected event LogMessageEventHandler DebugLogEventHandler;

		/// <summary>
		/// INFO log level event handler.
		/// </summary>
		protected event LogMessageEventHandler InfoLogEventHandler;

		/// <summary>
		/// WARNING log level event handler.
		/// </summary>
		protected event LogMessageEventHandler WarnLogEventHandler;

		/// <summary>
		/// ERROR log level event handler.
		/// </summary>
		protected event LogMessageEventHandler ErrorLogEventHandler;

		/// <summary>
		/// FATAL log level event handler.
		/// </summary>
		protected event LogMessageEventHandler FatalLogEventHandler;

		/// <summary>
		/// Default constructor.
		/// </summary>
		private Log() { }

		/// <summary>
		/// Log singleton object.
		/// </summary>
		private static Log _instance = null;

		/// <summary>
		/// Static method to get singleton Log object.
		/// </summary>
		/// <returns>Log object.</returns>
		protected static Log GetInstance()
		{
			if (null == Log._instance)
			{
				Log._instance = new Log();
			}
			return Log._instance;
		}

		/// <summary>
		/// TRACE level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void TRACE(
			string message = "", 
			[CallerFilePath] string filePath = "", 
			[CallerLineNumber] int lineNumber = 0, 
			[CallerMemberName] string memberName = ""
			)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.TraceLogEventHandler, message, filePath, lineNumber, memberName);
		}

		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void DEBUG(
			string message,
			[CallerFilePath] string filePath = "",
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string memberName = ""
			)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.DebugLogEventHandler, message, filePath, lineNumber, memberName);
		}

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void INFO(
			string message,
			[CallerFilePath] string filePath = "",
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string memberName = ""
			)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.InfoLogEventHandler, message, filePath, lineNumber, memberName);
		}

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void WARN(
			string message,
			[CallerFilePath] string filePath = "",
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string memberName = ""
			)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.WarnLogEventHandler, message, filePath, lineNumber, memberName);
		}

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void ERROR(
			string message,
			[CallerFilePath] string filePath = "",
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string memberName = ""
			)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.ErrorLogEventHandler, message, filePath, lineNumber, memberName);
		}

		/// <summary>
		/// FATAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public static void FATAL(
			string message,
			[CallerFilePath] string filePath = "",
			[CallerLineNumber] int lineNumber = 0,
			[CallerMemberName] string memberName = ""
			)
		{
			var log = Log.GetInstance();
			RaiseLogEvent(log.FatalLogEventHandler, message, filePath, lineNumber, memberName);
		}

        /// <summary>
        /// Raise log send event.
        /// </summary>
        /// <param name="eventHandler">Log event handler (delegate).</param>
        /// <param name="message">Log message</param>
        protected static void RaiseLogEvent(
            LogMessageEventHandler eventHandler,
            string message,
            string filePath = "",
            int lineNumber = 0,
            string memberName = ""
            )
        {
            var eventArg = new LogEventArgs(message, filePath, lineNumber, memberName);
            eventHandler?.Invoke(Log.GetInstance(), eventArg);
        }

        /// <summary>
        /// Setup event handler.
        /// </summary>
        /// <param name="logger"></param>
        public static void AddLogger(ALog logger)
		{
			var log = Log.GetInstance();

			log.TraceLogEventHandler += logger.TRACE;
			log.DebugLogEventHandler += logger.DEBUG;
			log.InfoLogEventHandler += logger.INFO;
			log.WarnLogEventHandler += logger.WARN;
			log.ErrorLogEventHandler += logger.ERROR;
			log.FatalLogEventHandler += logger.FATAL;
		}
	}
}
