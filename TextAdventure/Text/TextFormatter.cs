using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.TextFormatting
{
    class TextFormatter
    {
        public static string formatQuestion(string _question, string[] _answers, string[] _mood)
        {
            return null;
        }
        public static string formatDescrption(string _description)
        {
            return null;
        }
        public static string formatMap(string[] _map)
        {
            return null;
        }
        public static string formatMenu(string[] _map)
        {
            return null;
        }

        public static void FormatText(string _formattedDescription, string _formattedMap)
        {
            Display.TextDisplay consoleInstance = Display.TextDisplay.getInstance();
            consoleInstance.displayText();
        }
    }
}
