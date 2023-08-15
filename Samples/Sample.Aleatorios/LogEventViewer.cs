using System;
using System.Diagnostics;

namespace Sample.Aleatorios
{
    public class GlobalInfo
    {
        public const string EVENT_VIEWER_GROUP = "consoleSamples";
        public const string SISNAME = "Sample.Aleatorios";
    }

    class LogEventViewer
    {
        public static void Log(Exception ex)
        {
            CheckRegisteredSource();
            EventLog.WriteEntry(GlobalInfo.EVENT_VIEWER_GROUP, String.Concat(ex.ToString(), ex.StackTrace), EventLogEntryType.Error);
        }

        public static void Log(string message)
        {
            CheckRegisteredSource();
            EventLog.WriteEntry(GlobalInfo.EVENT_VIEWER_GROUP, message, EventLogEntryType.Error);
        }

        private static void CheckRegisteredSource()
        {
            if (!EventLog.SourceExists(GlobalInfo.EVENT_VIEWER_GROUP))
                EventLog.CreateEventSource(GlobalInfo.EVENT_VIEWER_GROUP, "Application");
        }
    }
}
