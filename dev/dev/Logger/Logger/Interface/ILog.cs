using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Logger.Interface
{
	public interface ILog
	{
		/// <summary>
		/// TRACE level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void TRACE(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            );

		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void DEBUG(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            );

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void INFO(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            );

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void WARN(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            );

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void ERROR(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            );

		/// <summary>
		/// FALTAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void FATAL(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = ""
            );
	}
}
