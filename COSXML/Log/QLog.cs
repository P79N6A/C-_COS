using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 10:06:17 AM
* bradyxiao
*/
namespace COSXML.Log
{
    public sealed class QLog
    {
        /**
        * log format: [time] [thread]/[application] [Level]/[TAG]: [message]
        */

        private static string timeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        //private static string currentDir = Directory.GetCurrentDirectory();

        private static Process currentProcess = Process.GetCurrentProcess();

        private static LogImpl logImpl = new LogImpl();

        private static LEVEL level = LEVEL.V;

        public static void SetLogLevel(LEVEL level)
        {
            QLog.level = level;
        }

        public static void V(string tag, string message, Exception exception)
        {
            if (LEVEL.V >= QLog.level)
            {
                logImpl.PrintLog(FormatLogMessage(LEVEL.V, tag, message, exception));
            }
            
        }

        public static void D(string tag, string message, Exception exception)
        {
            if (LEVEL.D >= QLog.level)
            {
                logImpl.PrintLog(FormatLogMessage(LEVEL.D, tag, message, exception));
            }
            
        }

        public static void I(string tag, string message, Exception exception)
        {

            if (LEVEL.I >= QLog.level)
            {
                logImpl.PrintLog(FormatLogMessage(LEVEL.I, tag, message, exception));
            }
            
        }

        public static void W(string tag, string message, Exception exception)
        {
            if (LEVEL.W >= QLog.level)
            {
                logImpl.PrintLog(FormatLogMessage(LEVEL.W, tag, message, exception));
            }
           
        }

        public static void E(string tag, string message, Exception exception)
        {
            if (LEVEL.E >= QLog.level)
            {
                logImpl.PrintLog(FormatLogMessage(LEVEL.E, tag, message, exception));
            }
           
        }

        private static string FormatLogMessage(LEVEL level, string tag, string message, Exception exception)
        {
            StringBuilder messageBuilder = new StringBuilder();
            
            messageBuilder.Append(DateTime.Now.ToString(timeFormat))
                .Append(" ")
                .Append(Thread.CurrentThread.ManagedThreadId)
                .Append("-")
                .Append(currentProcess.Id)
                .Append("/")
                .Append(currentProcess.ProcessName)
                .Append(" ")
                .Append(level.ToString())
                .Append("/")
                .Append(tag)
                .Append(": ")
                .Append(message);
            if (exception != null)
            {
                messageBuilder.Append("\n Exception:\n")
                    .Append(exception.ToString());
            }
            return messageBuilder.ToString();
        }

        private static string PrintExceptionTrace(Exception exception)
        {
            return exception.ToString();
        }
    }

    public enum LEVEL
    {
        V = 0,
        D,
        I,
        W,
        E
    }
}
