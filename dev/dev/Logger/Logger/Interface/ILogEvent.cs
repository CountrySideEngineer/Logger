using System;

namespace Logger.Interface
{
	/// <summary>
	/// Log event interface.
	/// </summary>
	public interface ILogEvent
	{
		/// <summary>
		/// TRACE level log event handler
		/// </summary>
		/// <param name="sende">Event sender.</param>
		/// <param name="e">Event argument.</param>
		void TRACE(object sender, EventArgs e);

		/// <summary>
		/// DEBUG level log event handler
		/// </summary>
		/// <param name="sende">Event sender.</param>
		/// <param name="e">Event argument.</param>
		void DEBUG(object sender, EventArgs e);

		/// <summary>
		/// INFO (information) level log event handler
		/// </summary>
		/// <param name="sende">Event sender.</param>
		/// <param name="e">Event argument.</param>
		void INFO(object sender, EventArgs e);

		/// <summary>
		/// WARN (warning) level log event handler
		/// </summary>
		/// <param name="sende">Event sender.</param>
		/// <param name="e">Event argument.</param>
		void WARN(object sender, EventArgs e);

		/// <summary>
		/// ERROR level log event handler
		/// </summary>
		/// <param name="sende">Event sender.</param>
		/// <param name="e">Event argument.</param>
		void ERROR(object sender, EventArgs e);

		/// <summary>
		/// FALTAL level log event handler
		/// </summary>
		/// <param name="sende">Event sender.</param>
		/// <param name="e">Event argument.</param>
		void FATAL(object sender, EventArgs e);
	}
}
