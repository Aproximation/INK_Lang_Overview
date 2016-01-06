using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    public enum LogType
    {
        info,
        warning,
        error
            //, success
    }

    static class Log
    {
        public static void LogMsg(TextBox control, string msg, LogType type)
        {
            switch (type)
            {
                case LogType.info:
                    LogInfo(control, msg);
                    break;
                case LogType.warning:
                    LogWarning(control, msg);
                    break;
                case LogType.error:
                    LogError(control, msg);
                    break;
                default:
                    LogError(control, "Nieznana komenda");
                    break;
            }
        }

        private static void LogError(TextBox control, string msg)
        {
            control.Text = msg;
            control.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private static void LogWarning(TextBox control, string msg)
        {
            control.Text = msg;
            control.BorderBrush = new SolidColorBrush(Colors.Yellow);
        }

        private static void LogInfo(TextBox control, string msg)
        {
            control.Text = msg;
            control.BorderBrush = new SolidColorBrush(Colors.Black);
        }
    }
}
