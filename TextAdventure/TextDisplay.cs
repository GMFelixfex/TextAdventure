using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class TextDisplay
    {
        private static readonly TextDisplay instance = new TextDisplay();
        private string currentText = "";

        private TextDisplay()
        {

        }

        public static TextDisplay getInstance()
        {
            return instance;
        }

        public void setCurrentText(string text)
        {
            currentText = text;
        }

        public void displayText()
        {
            Console.WriteLine(currentText);
        }
    }
}
