# Logger

[![LICENSE](https://img.shields.io/badge/License-MIT-brightfreen.svg)](https://spdx.org/licenses/MIT)
![APP_VER](https://img.shields.io/badge/Logger_for_C%23-v2.2.1-blue)
![DOT_NET_CORE](https://img.shields.io/badge/Core-8.0-%20?style=flat&logo=.NET&color=512BD4)
![DOT_NET_CORE](https://img.shields.io/badge/Core-3.1-%20?style=flat&logo=.NET&color=%23512BD4)
![DOT_NET_FRAMEWORK](https://img.shields.io/badge/Framework-4.7.1-a?style=flat&logo=.NET)
![OS](https://img.shields.io/badge/-Windows10-0078D6.svg?logo=windows&style=flat)

Logger library for C#.

# What?

The library __"logger.dll"__ is a library to output log message, informaiton into console and/or file in C# applications.  

# How to use

To use this library, clone the repository and add reference to the file Logger.dll in the cloned into your project.
And then, setup logger in your codes called when starts.

Sample codes:

```
using CS.Logger;

CS.Logger.ALog consoleLogger = new CS.Logger.Console.Log();
CS.Logger.Log.AddLogger(consoleLogger);

CS.Logger.Log.TRACE("Sample TRACE level log message");
CS.Logger.Log.DEBUG("Sample DEBUG level log message");
CS.Logger.Log.INFO("Sample INFO(rmation) level log message");
CS.Logger.Log.WARN("Sample WARN(ing) level log message");
CS.Logger.Log.ERROR("Sample ERROR level log message");
CS.Logger.Log.FATAL("Sample FATAL level log message");

```

Codes `Log.Addogger` is a method the logger.dll provides, `Logger.Console.Log`, and `Logger.File.Log` are class to output log message into console and file.  
The codes above output message into console like below:

![sample_screen_shotpng](https://github.com/user-attachments/assets/cef742e7-bdf9-44d3-ac68-f710dde0bdb2)

And the same message will be output into a file like below:
[sample_log_file.log](https://github.com/user-attachments/files/16322408/sample_log_file.log)
File name is `yyyyMMddHHmmss` format.
It can change. The way to change, see wiki pages.
