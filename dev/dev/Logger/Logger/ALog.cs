using Logger.EventArg;
using Logger.Interface;
using System;
using System.Runtime.CompilerServices;

namespace CS.Logger
{
    public enum LOG_LEVEL
    {
        OFF,
        FATAL,
        ERROR,
        WARNING,
        INFO,
        DEBUG,
        TRACE,
        ALL,
    };
    
    public abstract class ALog : ILog, ILogEvent
	{
        public LOG_LEVEL LogLevel { get; protected set; } = LOG_LEVEL.ALL;

        public bool OptionEnable { get; protected set; } = true;

		/// <summary>
		/// TRACE level log tag.
		/// </summary>
        public string TRACE_TAG { get; protected set; } = "TRACE";

        /// <summary>
        /// DEBUG level log tag.
        /// </summary>
        public string DEBUG_TAG { get; protected set; } = "DEBUG";

		/// <summary>
		/// INFO level log tag.
		/// </summary>
		public string INFO_TAG { get; protected set; } = "INFO ";

		/// <summary>
		/// WARN level log tag.
		/// </summary>
        public string WARN_TAG { get; protected set; } = "WARN ";

        /// <summary>
        /// ERROR level log tag.
        /// </summary>
        public string ERROR_TAG { get; protected set; } = "ERROR";

		/// <summary>
		/// FATAL level log tag.
		/// </summary>
		public string FATAL_TAG { get; protected set; } = "FATAL";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ALog() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logLevel">Output log level.</param>
        public ALog(LOG_LEVEL logLevel)
        {
            LogLevel = logLevel;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logLevel">Output log level.</param>
        public ALog(LOG_LEVEL logLevel, bool optionEnable)
        {
            LogLevel = logLevel;
            OptionEnable = optionEnable;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logLevel">Output log level.</param>
        /// <param name="fatalTag">FATAL level log tag displayed in log message header.</param>
        /// <param name="errTag">ERROR level log tag displayed in log message header.</param>
        /// <param name="warnTag">WARN(ing) level log tag displayed in log message header.</param>
        /// <param name="infoTag">INFO(rmation) level log tag displayed in log message header.</param>
        /// <param name="debugTag">DEBUG level log tag displayed in log message header.</param>
        /// <param name="traceTag">TRACE level log tag displayed in log message header.</param></param>
        public ALog(
            LOG_LEVEL logLevel,
            bool optionEnable,
            string fatalTag, string errTag, string warnTag, string infoTag, string debugTag, string traceTag
            )
            : this(logLevel, optionEnable)
        {
            FATAL_TAG = fatalTag;
            ERROR_TAG = errTag;
            WARN_TAG = warnTag;
            INFO_TAG = infoTag;
            DEBUG_TAG = debugTag;
            TRACE_TAG = traceTag;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logLevel">Output log level.</param>
        /// <param name="fatalTag">FATAL level log tag displayed in log message header.</param>
        /// <param name="errTag">ERROR level log tag displayed in log message header.</param>
        /// <param name="warnTag">WARN(ing) level log tag displayed in log message header.</param>
        /// <param name="infoTag">INFO(rmation) level log tag displayed in log message header.</param>
        /// <param name="debugTag">DEBUG level log tag displayed in log message header.</param>
        /// <param name="traceTag">TRACE level log tag displayed in log message header.</param>
        /// <param name="dateTimeFormat">Date time format.</param>
        public ALog(
            LOG_LEVEL logLevel,
            bool optionEnable,
            string fatalTag, string errTag, string warnTag, string infoTag, string debugTag, string traceTag,
            string dateTimeFormat
            )
            : this(logLevel, optionEnable, fatalTag, errTag, warnTag, infoTag, debugTag, traceTag)
        {
            TIME_STAMP_FORMAT = dateTimeFormat;
        }

        /// <summary>
        /// FATAL level log event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Log event argument.</param>
        public virtual void FATAL(object sender, EventArgs e)
        {
            string message = GetMessage(e);
            var eventArg = (LogEventArgs)e;
            FATAL(message, eventArg.FileName, eventArg.LineNumber, eventArg.MemberName);
        }

        /// <summary>
        /// FATAL level log.
        /// </summary>
        /// <param name="message">Log message.</param>
        public virtual void FATAL(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            )
        {
            if (LOG_LEVEL.FATAL <= LogLevel)
            {
                string outputMessage = GetOutputMessage(FATAL_TAG, message, filePath, lineNumber, memberName);
                Output(outputMessage);
            }
        }

        /// <summary>
        /// ERROR level log event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Log event argument.</param>
        public virtual void ERROR(object sender, EventArgs e)
        {
            string message = GetMessage(e);
            var eventArg = (LogEventArgs)e;
            ERROR(message, eventArg.FileName, eventArg.LineNumber, eventArg.MemberName);
        }

        /// <summary>
        /// ERROR level log.
        /// </summary>
        /// <param name="message">Log message.</param>
        public virtual void ERROR(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            )
        {
            if (LOG_LEVEL.ERROR <= LogLevel)
            {
                string outputMessage = GetOutputMessage(ERROR_TAG, message, filePath, lineNumber, memberName);
                Output(outputMessage);
            }
        }

        /// <summary>
        /// WARN (warning) level log event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Log event argument.</param>
        public virtual void WARN(object sender, EventArgs e)
        {
            string message = GetMessage(e);
            var eventArg = (LogEventArgs)e;
            WARN(message, eventArg.FileName, eventArg.LineNumber, eventArg.MemberName);
        }

        /// <summary>
        /// WARN (warning) level log.
        /// </summary>
        /// <param name="message">Log message.</param>
        public virtual void WARN(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            )
        {
            if (LOG_LEVEL.WARNING <= LogLevel)
            {
                string outputMessage = GetOutputMessage(WARN_TAG, message, filePath, lineNumber, memberName);
                Output(outputMessage);
            }
        }

        /// <summary>
        /// INFO (information) level log event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Log event argument.</param>
        public virtual void INFO(object sender, EventArgs e)
        {
            string message = GetMessage(e);
            var eventArg = (LogEventArgs)e;
            INFO(message, eventArg.FileName, eventArg.LineNumber, eventArg.MemberName);
        }

        /// <summary>
        /// INFO (information) level log.
        /// </summary>
        /// <param name="message">Log message.</param>
        public virtual void INFO(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            )
        {
            if (LOG_LEVEL.INFO <= LogLevel)
            {
                string outputMessage = GetOutputMessage(INFO_TAG, message, filePath, lineNumber, memberName);
                Output(outputMessage);
            }
        }

        /// <summary>
        /// DEBUG level log event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Log event argument.</param>
        public virtual void DEBUG(object sender, EventArgs e)
		{
            string message = GetMessage(e);
            var eventArg = (LogEventArgs)e;
            DEBUG(message, eventArg.FileName, eventArg.LineNumber, eventArg.MemberName);
        }

        /// <summary>
        /// DEBUG level log.
        /// </summary>
        /// <param name="message">Log message.</param>
        public virtual void DEBUG(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            )
        {
            if (LOG_LEVEL.DEBUG <= LogLevel)
            {
                string outputMessage = GetOutputMessage(DEBUG_TAG, message, filePath, lineNumber, memberName);
                Output(outputMessage);
            }
        }

        /// <summary>
        /// TRACE level log event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Log event argument.</param>
        public virtual void TRACE(object sender, EventArgs e)
		{
            string message = GetMessage(e);
            var eventArg = (LogEventArgs)e;
            TRACE(message, eventArg.FileName, eventArg.LineNumber, eventArg.MemberName);
		}

		/// <summary>
		/// TRACE level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public virtual void TRACE(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            )
        {
            if (LOG_LEVEL.TRACE <= LogLevel)
            {
                string outputMessage = GetOutputMessage(TRACE_TAG, message, filePath, lineNumber, memberName);
                Output(outputMessage);
            }
        }

        /// <summary>
        /// Returns message set in log event argument, LogEventArgs object.
        /// </summary>
        /// <param name="e">Event argument.</param>
        /// <returns>Message get from event argument.</returns>
        protected virtual string GetMessage(EventArgs e)
        {
            try
            {
                LogEventArgs eventArg = (LogEventArgs)e;
                string message = eventArg.Message;

                return message;
            }
            catch (Exception ex)
            when ((ex is NullReferenceException) || (ex is InvalidCastException))
            {
                return string.Empty;
            }
        }

		/// <summary>
		/// Generate message from event arguments.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="traceOfLevel">Bool whether the trace information output or not.</param>
		/// <param name="e">Message source event argument.</param>
		/// <returns>Message</returns>
		protected virtual string GetOutputMessage(
            string level, 
            string message, 
            string filePath = "", 
            int lineNumber = 0, 
            string memberName = "")
		{
			try
			{
                string logLevelTag = GetLogLevelTag(level);
                string timeStamp = GetTimeStampTag();
                string logOpt = GetOption(filePath, lineNumber, memberName);

                if ((!string.IsNullOrEmpty(message)) && (!string.IsNullOrWhiteSpace(message)))
                {
                    string msgHeader = $"{logLevelTag}{timeStamp}{logOpt}";
                    if (!(string.IsNullOrEmpty(msgHeader)) && (!(string.IsNullOrWhiteSpace(msgHeader))))
                    {
                        return $"{msgHeader}:{message}";
                    }
                    else
                    {
                        return message;
                    }
                }
                else
                {
                    return string.Empty;

                }
			}
			catch (Exception ex)
			when ((ex is NullReferenceException) || (ex is ArgumentNullException))
			{
				throw new NotSupportedException("Log message invalid.");
			}
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
		protected string TIME_STAMP_FORMAT = "yyyy/MM/dd HH:mm:ss.fff";

        public virtual string GetTimeStampTag()
        {
            return GetTimeStampTag(TIME_STAMP_FORMAT);
        }

        public virtual string GetTimeStampTag(string format)
        {
            string timeStamp = GetTimeStamp(format);
            string timeStampTag = $"[{timeStamp}]";
            return timeStampTag;
        }

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
            try
            {
                string timeStamp = DateTime.Now.ToString(format);
                return timeStamp;
            }
            catch (Exception ex)
            when (
                (ex is ArgumentNullException) || 
                (ex is NullReferenceException) || 
                (ex is FormatException) || 
                (ex is ArgumentOutOfRangeException)
                )
            {
                return string.Empty;
            }
		}

        /// <summary>
        /// Returns log level tag message.
        /// </summary>
        /// <param name="tag">Tag of log level.</param>
        /// <returns>Log level tag message.</returns>
        public virtual string GetLogLevelTag(string tag)
        {
            if ((string.IsNullOrEmpty(tag)) || (string.IsNullOrWhiteSpace(tag)))
            {
                return string.Empty;
            }
            else
            {
                return $"[{tag}]";
            }
        }

        /// <summary>
        /// Returns log header option message.
        /// </summary>
        /// <param name="filePath">Path to file the event raised.</param>
        /// <param name="lineNumber">The line number the event raised.</param>
        /// <param name="memberName">The member name the event raised.</param>
        /// <returns>Log message header option.</returns>
        public virtual string GetOption(string filePath, int lineNumber, string memberName)
        {
            try
            {
                if (OptionEnable)
                {
                    if ((!string.IsNullOrEmpty(filePath)) && (!string.IsNullOrWhiteSpace(filePath)) &&
                        (!string.IsNullOrEmpty(memberName)) && (!string.IsNullOrWhiteSpace(memberName)) &&
                        (0 < lineNumber)
                        )
                    {
                        string option = $"[{filePath}({lineNumber,5})][{memberName}]";
                        return option;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
