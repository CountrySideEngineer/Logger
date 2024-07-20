# Logger

[![LICENSE](https://img.shields.io/badge/License-MIT-brightfreen.svg)](https://spdx.org/licenses/MIT)
![APP_VER](https://img.shields.io/badge/Logger_for_C%23-v1.0.0-blue)
![DOT_NET_CORE](https://img.shields.io/badge/Core-3.1-%20?style=flat&logo=.NET&color=%23512BD4)
![DOT_NET_FRAMEWORK](https://img.shields.io/badge/Framework-4.7.1-a?style=flat&logo=.NET)

Logger library for C#.

# What?

The library __"logger.dll"__ is a library to output log message, informaiton into console and/or file in C# applications.  

# How to use

To use this library, clone the repository and add reference to the file Logger.dll in the cloned into your project.
And then, setup logger in your codes called when starts.

Sample codes:

```
using Logger;

namespace LoggerSample
{
	public class Program
	{
		static void Main(string[] args)
		{
			Log.AddLogger(new Logger.Console.Log());
			Log.AddLogger(new Logger.File.Log());

			var sampleClass = new LoggerSampleClass();
			sampleClass.Sample();

			return;
		}
	}
}
```

Codes `Log.Addogger` is a method the logger.dll provides, `Logger.Console.Log`, and `Logger.File.Log` are class to output log message into console and file.  
The codes of `LoggerSampleClass` are below:

```
using Logger;

namespace LoggerSample
{
	public class LoggerSampleClass
	{
		public LoggerSampleClass() { }

		public void Sample()
		{
			Log.TRACE("Sample TRACE message");
			Log.DEBUG("Sample DEBUG message");
			Log.INFO("Sample INFO message");
			Log.WARN("Sample WARN message");
			Log.ERROR("Sample ERROR message");
			Log.FATAL("Sample FATAL message");
		}
	}
}
```

When the codes above are executed, the console like below will be displayed.
![sample_screen_shotpng](https://github.com/user-attachments/assets/cef742e7-bdf9-44d3-ac68-f710dde0bdb2)

And the same message will be output into a file like below:
[sample_log_file.log](https://github.com/user-attachments/files/16322408/sample_log_file.log)
File name is `yyyyMMddHHmmss` format.
It can change. The way to change, see wiki pages.
