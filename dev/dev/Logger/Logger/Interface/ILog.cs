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
		void TRACE(string message);

		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void DEBUG(string message);

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void INFO(string message);

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void WARN(string message);

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void ERROR(string message);

		/// <summary>
		/// FALTAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		void FATAL(string message);
	}
}
