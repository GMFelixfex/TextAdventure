using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextAdventure.Display
{
    class TextDisplay
    {
        private static readonly TextDisplay instance = new TextDisplay();
        private string currentScreen = "";
        
        private TextDisplay()
        {
            displayText();
        }

        public static TextDisplay getInstance()
        {
            return instance;
        }

        public void setCurrentScreen(string _text)
        {
            currentScreen = _text;
        }

        public void displayText()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(currentScreen);
        }


    }
}
