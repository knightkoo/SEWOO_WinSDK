using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helper
{
    internal enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Error = 3
    }

    internal static class Logger
    {
        static LogLevel logLevel = LogLevel.Debug;

        // 디폴트 생성자 추가
        static Logger()
        {
            Prepare(bFileSupport: true);
        }

        internal static void Prepare(bool bFileSupport = false)
        {
            if (!bFileSupport)
                return;

            string logFilePath = Path.Combine(Application.StartupPath, "oq_log.log");
            TextWriterTraceListener fileListener = new TextWriterTraceListener(logFilePath);

            Trace.Listeners.Add(fileListener);
            Trace.AutoFlush = true; 
        }

        internal static void Debug(string msg)
        {
            if (logLevel <= LogLevel.Debug)
                Write(msg);
        }

        internal static void Info(string msg)
        {
            if (logLevel <= LogLevel.Info)
                Write(msg);
        }

        internal static void Warn(string msg)
        {
            if (logLevel <= LogLevel.Warn)
                Write(msg);
        }

        internal static void Error(string msg)
        {
            if (logLevel <= LogLevel.Error)
                Write(msg);
        }

        private static void Write(string msg)
        {
            Trace.WriteLine(msg);
        }
    }
}
