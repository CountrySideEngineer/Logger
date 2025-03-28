using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS.Logger.File
{
	public class Log : ALog
	{
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
			try
			{
				using (var stream = new StreamWriter(FilePath, true))
				{
					stream.WriteLine(message);
				}
			}
			catch (Exception)
			{
				//There is no way to handle the exception.
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
	}
}
