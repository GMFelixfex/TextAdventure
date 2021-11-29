using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TextAdventure.Display
{
    class TextDisplay
    {
        private static readonly TextDisplay instance = new TextDisplay();
        private string currentText = "";
        
        private TextDisplay()
        {
            displayText();
        }

        public static TextDisplay getInstance()
        {
            return instance;
        }

        public void setCurrentText(string _text)
        {
            currentText = _text;
        }

        public void displayText()
        {
            Console.WriteLine(currentText);

        }


    }
}
