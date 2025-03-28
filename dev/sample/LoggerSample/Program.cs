// Sample code to use CS.Logger.Console class to output log message
// into console window.

using CS.Logger;

// 1. Instantiate CS.Logger.Console.Log class.
CS.Logger.ALog consoleLogger = new CS.Logger.Console.Log();

// REMARKS:
//  To change the log level of the output, specify the log level
//  to be output when the instace is created.
//  The available log level is from OFF to ALL.
//
//  Ex:
//      If to set to show only INFO, WANR, ERROR, and FATAL level,
//      pass LOG_LEVEL.INFO to constructor of the log class.
//      The code is like below:
//
//  CS.Logger.ALog consoleLogger = new CS.Logger.Console.Log(LOG_LEVEL.INFO);

// 2. Add the instance to Logger using AddLogger static method.
CS.Logger.Log.AddLogger(consoleLogger);

// 3. Raise each method of Log class.
CS.Logger.Log.TRACE("Sample TRACE level log message");
CS.Logger.Log.DEBUG("Sample DEBUG level log message");
CS.Logger.Log.INFO("Sample INFO(rmation) level log message");
CS.Logger.Log.WARN("Sample WARN(ing) level log message");
CS.Logger.Log.ERROR("Sample ERROR level log message");
CS.Logger.Log.FATAL("Sample FATAL level log message");
