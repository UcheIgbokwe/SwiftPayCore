using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace SwiftPayCore.Log
{
    public class Logger : ExceptionLogger
    {
        private static readonly NLog.Logger Nlog = LogManager.GetCurrentClassLogger();

        public static void Log(LogLevel level, string message, bool isCSV = false)
        {
            if (isCSV)
                Nlog.Log(level, Environment.NewLine + message);
            else
                Nlog.Log(level, Environment.NewLine + message + System.Environment.NewLine + "-------------------------------------------------------------");

        }
    }
}