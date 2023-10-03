using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopytoDO.Utilities
{
   
    internal class CallLogger
    {
        
        private string _content = string.Empty;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public void WriteToFile(string content)
        {
            //Define the path to the text file
            string logFilePath = "console_log.txt";
            //Create a StreamWriter to write logs to a text file
            using (StreamWriter logFileWriter = new StreamWriter(logFilePath, append: true))
            {
                //Create an ILoggerFactory
                ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
                {
                    //Add console output
                    builder.AddSimpleConsole(options =>
                    {
                        options.IncludeScopes = true;
                        options.SingleLine = true;
                        options.TimestampFormat = "HH:mm:ss ";
                    });

                    //Add a custom log provider to write logs to text files
                    builder.AddProvider(new CustomFileLoggerProvider(logFileWriter));
                });

                //Create an ILogger
                ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

                // Output some text on the console
                using (logger.BeginScope("[scope is enabled]"))
                {
                    logger.LogInformation("Hello World!");
                    logger.LogInformation("Logs contain timestamp and log level.");
                    logger.LogInformation("Each log message is fit in a single line.");
                }
            }

        }
    }

 
}
