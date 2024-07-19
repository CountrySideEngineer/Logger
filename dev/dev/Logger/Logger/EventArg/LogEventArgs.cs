using System;
using System.Collections.Generic;
using System.Text;

namespace CSEngineer.Logger.EventArg
{
	/// <summary>
	/// Event argument class for log event.
	/// </summary>
	public class LogEventArgs : EventArgs
	{
		/// <summary>
		/// Event message.
		/// </summary>
		public string Message { get; set; }

		public string FileName { get; set; } = string.Empty;	

		public int LineNumber { get; set; } = 0;

		public string MemberName { get; set; } = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LogEventArgs() : base()
		{
			Message = string.Empty;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Event message.</param>
		public LogEventArgs(string message) : base()
		{
			Message = message;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Event message.</param>
		/// <param name="fileName">File name the event raised.</param>
		public LogEventArgs(string message, string fileName)
		{
			Message = message;
			FileName = fileName;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Event message.</param>
		/// <param name="fileName">File name the event raised.</param>
		/// <param name="lineNumber">Line number the event raised.</param>
		public LogEventArgs(string message, string fileName, int lineNumber)
		{
			Message = message;
			FileName = fileName;
			LineNumber = lineNumber;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Event message.</param>
		/// <param name="fileName">File name the event raised.</param>
		/// <param name="lineNumber">Line number the event raised.</param>
		/// <param name="memberName">Member name the event railse.</param>
		public LogEventArgs(string message, string fileName, int lineNumber, string memberName)
		{
			Message = message;
			FileName = fileName;
			LineNumber = lineNumber;
			MemberName = memberName;
		}
	}
}
