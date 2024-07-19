using CSEngineer.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerSample
{
	public class CommonBaseObject : ALog
	{
		/// <summary>
		/// DEBUG level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void DEBUG(string message)
		{
			var logger = Log.GetInstance();
			logger._DEBUG(message);
		}

		/// <summary>
		/// ERROR level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void ERROR(string message)
		{
			var logger = Log.GetInstance();
			logger._ERROR(message);
		}

		/// <summary>
		/// FATAL level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void FATAL(string message)
		{
			var logger = Log.GetInstance();
			logger._FATAL(message);
		}

		/// <summary>
		/// INFO (information) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void INFO(string message)
		{
			var logger = Log.GetInstance();
			logger._INFO(message);
		}

		/// <summary>
		/// TRACE level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void TRACE(string message)
		{
			var logger = Log.GetInstance();
			logger._TRACE(message);
		}

		/// <summary>
		/// WARN (warning) level log.
		/// </summary>
		/// <param name="message">Log message.</param>
		public void WARN(string message)
		{
			var logger = Log.GetInstance();
			logger._WARN(message);
		}
	}
}
