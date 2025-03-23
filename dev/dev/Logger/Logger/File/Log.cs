using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.File
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
