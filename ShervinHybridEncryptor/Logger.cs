using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShervinHybridEncryptor
{
    internal class Logger
    {
        public static BackgroundWorker Worker { get; set; }
        public Logger(BackgroundWorker worker)
        {
            Worker = worker;
        }

        public static void Log(string message, bool islastLog = false)
        {
            if(Worker == null) throw new Exception("Error: Logger not initialized.");

            Worker.ReportProgress(0, TimeStamp + ' ' + message);
            Debug.WriteLine(message);

            if (!islastLog) return;

            var span = DateTime.Now - FirstLog;
            Worker.ReportProgress(0, "Run Time: " + span.ToString("mm':'ss':'fff", System.Globalization.CultureInfo.InvariantCulture));
        }

        private static string TimeStamp
        {
            get { return "[" + DateTime.Now.ToString("hh:mm:ss:fff tt") + "]"; }
        }

        public static DateTime FirstLog { get; set; }
    }
}
