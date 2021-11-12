using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler.Business.Helpers
{
    public static class ConsoleUtils
    {
        private const ConsoleColor DEFAULT_FOREGROUND_COLOR = ConsoleColor.White;
        public static void OutputConsole(string preffix, string text, params string[] parameters)
        {
            Console.WriteLine(preffix + " " + string.Format(text, parameters));
            Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
        }

        public static void OutputConsole(string preffix, string text, ConsoleColor foregroundColor, params string[] parameters)
        {
            Console.ForegroundColor = foregroundColor;
            OutputConsole(preffix, text, parameters);
        }
    }
}
