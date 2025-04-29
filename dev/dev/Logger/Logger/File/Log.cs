using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CS.Logger.File
{
	public class Log : ALog
	{
        protected List<string> _messageBuf = new List<string>();

        /// <summary>
        /// Path to file to setup
        /// </summary>
        public string FilePath = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Log() : base()
		{
			FilePath = GenerateDefaultFilePath();
		}

		/// <summary>
		/// Constructor with path to log fiel.
		/// </summary>
		/// <param name="filePath">Path to log file.</param>
		public Log(string filePath) : base()
		{
			FilePath = filePath;
        }

        /// <summary>
        /// Constructor with path to log file and output log level.
        /// </summary>
		/// <param name="filePath">Path to log file.</param>
        /// <param name="logLevel">Output log level.</param>
        public Log(LOG_LEVEL logLevel, string filePath) : base(logLevel)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Constructor with path to log file and output log level.
        /// </summary>
		/// <param name="filePath">Path to log file.</param>
        /// <param name="logLevel">Output log level.</param>
        public Log(LOG_LEVEL logLevel, bool optionEnable, string filePath) : base(logLevel, optionEnable)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Constructor with log level, their tags, and path to log file.
        /// </summary>
        /// <param name="logLevel">Output log level.</param>
        /// <param name="filePath">Log message output file path.</param>
        /// <param name="optionEnable">Option part in message header is enable or not.</param>
        /// <param name="fatalTag">FATAL level log tag displayed in log message header.</param>
        /// <param name="errTag">ERROR level log tag displayed in log message header.</param>
        /// <param name="warnTag">WARN(ing) level log tag displayed in log message header.</param>
        /// <param name="infoTag">INFO(rmation) level log tag displayed in log message header.</param>
        /// <param name="debugTag">DEBUG level log tag displayed in log message header.</param>
        /// <param name="traceTag">TRACE level log tag displayed in log message header.</param>
        /// <param name="logLevel">Output log level.</param>
        public Log(
            LOG_LEVEL logLevel, bool optionEnable,
            string fatalTag, string errTag, string warnTag, string infoTag, string debugTag, string traceTag,
            string filePath
            )
            : base(logLevel, optionEnable, fatalTag, errTag, warnTag, infoTag, debugTag, traceTag)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Output mesage to log file.
        /// </summary>
        /// <param name="level">Log level in string.</param>
        /// <param name="message"></param>
        public override void Output(string message)
		{
            _messageBuf.Add(message);

            bool isSwitched = SwitchBuf();
            if (isSwitched)
            {
                Flush();
            }
		}

		/// <summary>
		/// Generate file path to log file.
		/// </summary>
		/// <returns>Path to log file.</returns>
		/// <remarks>
		/// The generated file path follows the format bewlo:
		/// "\Execution\File\Path\log_yyyyMMddHHmmss.log
		/// </remarks>
		protected virtual string GenerateDefaultFilePath()
		{
			string appPath = System.Reflection.Assembly.GetEntryAssembly().Location;
			string appDirPath = System.IO.Path.GetDirectoryName(appPath);
			string defaultTimeStamp = "yyyyMMddHHmmss";
			string timeStamp = base.GetTimeStamp(defaultTimeStamp);
			string fileName = $"log_{timeStamp}.log";
			string filePath = $@"{appDirPath}\{fileName}";

			return filePath;
        }

        /// <summary>
        /// Writes the accumulated log messages in the buffer to the log file.
        /// </summary>
        /// <remarks>
        /// This method writes the current message buffer (_messageBuf) to the log file
        /// using the Flush(IEnumerable<string>) method and clears the buffer after writing.
        /// </remarks>
        protected virtual void Flush()
        {
            Flush(_messageBuf);

            _messageBuf.Clear();
        }

        /// <summary>
        /// Writes the provided collection of log messages to the log file.
        /// </summary>
        /// <param name="messages">A collection of log messages to be written to the log file.</param>
        /// <remarks>
        /// This method iterates through the provided messages and writes each one to the log file.
        /// If an exception occurs during the write operation, it is caught and ignored, as there is no
        /// mechanism to handle it. The StreamWriter is properly disposed of after the operation.
        /// </remarks>
        protected virtual void Flush(IEnumerable<string> messages)
        {
            try
            {
                using (var writer = new StreamWriter(FilePath, true))
                {
                    foreach (var message in messages)
                    {
                        writer.WriteLine(message);
                    }
                }
            }
            catch (Exception)
            {
                //There is no way to handle the exception.
            }
        }

        /// <summary>
        /// Determines whether the message buffer has reached the threshold for flushing.
        /// </summary>
        /// <returns>
        /// Returns <c>true</c> if the number of messages in the buffer exceeds the threshold (1000); 
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method checks the size of the message buffer (_messageBuf) and decides if it should
        /// be flushed to the log file. The threshold is currently set to 1000 messages.
        /// </remarks>
        protected virtual bool SwitchBuf()
        {
            if (1000 < _messageBuf.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Releases resources used by the logger and ensures any remaining messages are flushed to the log file.
        /// </summary>
        /// <remarks>
        /// This method overrides the base class's Dispose method. It flushes any remaining messages
        /// in the buffer (_messageBuf) to the log file before releasing resources.
        /// </remarks>
        public override void Dispose()
        {
            base.Dispose();

            if (0 < _messageBuf.Count)
            {
                Flush(_messageBuf);
            }
        }
    }
}
