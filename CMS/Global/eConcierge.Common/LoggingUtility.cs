using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace eConcierge.Common
{
    public class LoggingUtility
    {
        public static void WriteLog(string message, TraceEventType eventType = TraceEventType.Error)
        {
            //LogEntry logEntry = new LogEntry();
            //logEntry.Categories.Clear();
            //logEntry.Categories.Add("General");
            //logEntry.Priority = 5;
            //logEntry.Severity = eventType;
            //logEntry.Message = message;
            //Logger.Write(logEntry);
        }
        public static void WriteLog(Exception ex, TraceEventType eventType = TraceEventType.Error)
        {
            WriteLog(ex.Message + Environment.NewLine + ex.StackTrace.ToString(), eventType);
        }
    }
}
