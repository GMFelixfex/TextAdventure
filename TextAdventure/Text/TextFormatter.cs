using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Options;

namespace TextAdventure.TextFormatting
{
    class TextFormatter
    {
        private static string[] currentMapSymbols = new string[StartOptions.DisplayHeight];
        private static string[] currentDescription = new string[StartOptions.DescDisplayHeight];
        private static string[] currentInteraction = new string[StartOptions.DisplayHeight - StartOptions.DescDisplayHeight];
        private static string[] currentmenu = new string[StartOptions.DisplayHeight];
        private static string[] currentInput = new string[StartOptions.DisplayHeight];


        public static string[] formatDescrption(string _description)
        {

            currentDescription[0] = new String(' ', StartOptions.DescDisplayWidth);
            string[] descriptionArray = _description.Replace(".",". ").Split(' ');
            string tempString = "";
            int k = 1;
            foreach (var item in descriptionArray)
            {
                if ((item.Length + tempString.Length + 4) <= StartOptions.DescDisplayWidth)
                {
                    tempString += item+" ";
                } 
                
                else
                {
                    currentDescription[k] = "  " + tempString;
                    currentDescription[k] += new String(' ', StartOptions.DescDisplayWidth - currentDescription[k].Length);
                    k++;
                    tempString = ""+item+" ";
                }
            }
            currentDescription[k] = "  " + tempString;
            currentDescription[k] += new String(' ', StartOptions.DescDisplayWidth - currentDescription[k].Length);
            k++;



            for (int i = k; i < StartOptions.DescDisplayHeight; i++)
            {
                    currentDescription[i] = new String(' ', StartOptions.DescDisplayWidth);
            }

            
            return currentDescription;
        }
        public static string[] formatInteraction(string[] _options, int selected)
        {
            for (int i = 0; i < StartOptions.IntDisplayHeight; i++)
            {
                if (i < _options.Length)
                {
                    if (i == selected)
                    {
                        currentInteraction[i] = "  -> "+_options[i]+new String(' ', StartOptions.DescDisplayWidth-(5+_options[i].Length));
                    }
                    else
                    {
                        currentInteraction[i] = "     "+_options[i]+new String(' ', StartOptions.DescDisplayWidth - (5 + _options[i].Length));
                    }
                    
                }
                else
                {
                    currentInteraction[i] = new String(' ', StartOptions.DescDisplayWidth);
                }


                
            }
            return currentInteraction;
        }
        public static string[] formatMap(string[] _mapSymbols)
        {
            currentMapSymbols[0] = new String(' ', StartOptions.MapDisplayWidth);
            for (int i = 1; i < StartOptions.DisplayHeight; i++)
            {
                if (i-1<_mapSymbols.Length)
                {
                    currentMapSymbols[i] = "  "+_mapSymbols[i-1] + new String(' ', StartOptions.MapDisplayWidth - (_mapSymbols[i-1].Length+2));
                } else
                {
                    currentMapSymbols[i] = new String(' ', StartOptions.MapDisplayWidth);
                }

            }
            return currentMapSymbols;
        }
        public static string[] formatMenu(string[] _options, string title, int selected)
        {
            int gapToTop = 20;
            for (int i = 0; i < StartOptions.DisplayHeight; i++)
            {
                
                if (i < _options.Length+gapToTop && i >= gapToTop)
                {
                    
                    int tempLength = StartOptions.DisplayWidth/2-5;
                    //int tempLength = (StartOptions.DisplayWidth - _options[i - gapToTop].Length) / 2;

                    if (i== selected+gapToTop)
                    {
                        tempLength -= 3;

                        int tempLength2 = StartOptions.DisplayWidth - (_options[i - gapToTop].Length + tempLength);
                        currentmenu[i] = new String(' ', tempLength) + "-> "+ _options[i - gapToTop] + new String(' ', tempLength2-3);
                    }
                    else
                    {
                        int tempLength2 = StartOptions.DisplayWidth - (_options[i - gapToTop].Length + tempLength);

                        currentmenu[i] = new String(' ', tempLength) + _options[i - gapToTop] + new String(' ', tempLength2);
                    }

                }
                else if (i == gapToTop-1)
                {
                    int tempLength = StartOptions.DisplayWidth/2-5;
                    //int tempLength = (StartOptions.DisplayWidth - title.Length) / 2;
                    int tempLength2 = StartOptions.DisplayWidth - (title.Length + tempLength);
                    currentmenu[i] = new String(' ', tempLength) + title + new String(' ', tempLength2);
                } 
                else
                {
                    currentmenu[i] = new String(' ', StartOptions.DisplayWidth);
                }

            }
            return currentmenu;
        }
        public static string[] formatInput(string _title, string _input)
        {
            currentInput[0] = new String(' ', StartOptions.DisplayWidth);
            currentInput[1] = "  "+_title + new String(' ', StartOptions.DisplayWidth - (_title.Length+2));
            currentInput[2] = new String(' ', StartOptions.DisplayWidth);

            string[] inputArray = _input.Replace(".", ". ").Split(' ');
            string tempString = "";
            int k = 3;
            foreach (var item in inputArray)
            {
                if ((item.Length + tempString.Length + 4) <= StartOptions.DisplayWidth)
                {
                    tempString += item + " ";
                }
                else
                {
                    currentInput[k] = "  " + tempString;
                    currentInput[k] += new String(' ', StartOptions.DisplayWidth - currentInput[k].Length);
                    k++;
                    tempString = "" + item + " ";
                }
            }
            currentInput[k] = "  " + tempString;
            currentInput[k] += new String(' ', StartOptions.DisplayWidth - currentInput[k].Length);
            k++;



            for (int i = k; i < StartOptions.DisplayHeight; i++)
            {
                currentInput[i] = new String(' ', StartOptions.DisplayWidth);
            }
            return currentInput;
        }
        public static string GetFormatedScreen(Text.ScreenTypes _screenType)
        {
            string Screen = "";
            if(_screenType == Text.ScreenTypes.Menu)
            {
                Screen = "╔"+ new String('═', StartOptions.DisplayWidth)+ "╗";
                for (int i = 0; i < currentmenu.Length; i++)
                {
                    Screen += "║" + currentmenu[i] + "║";
                }
                Screen += "╚" + new String('═', StartOptions.DisplayWidth) + "╝";


            } 
            else if (_screenType == Text.ScreenTypes.Ingame)
            {
                Screen = "╔" + new String('═', currentMapSymbols[0].Length) + "╦" + new String('═', currentDescription[0].Length) + "╗" + "\n";
                for (int i = 0; i < currentMapSymbols.Length; i++)
                {
                    if (i < currentDescription.Length)
                    {
                        Screen += "║" + currentMapSymbols[i] + "║" + currentDescription[i] + "║" + "\n";
                    }
                    else if (i == currentDescription.Length)
                    {
                        Screen += "║" + currentMapSymbols[i] + "╠" + new String('═', currentDescription[0].Length) + "╣" + "\n";
                    } else
                    {
                        Screen += "║" + currentMapSymbols[i] + "║" + currentInteraction[i-(StartOptions.DisplayHeight-currentInteraction.Length)] + "║" + "\n";
                    }


                }
                Screen += "╚" + new String('═', currentMapSymbols[0].Length) + "╩"+ new String('═', currentDescription[0].Length) + "╝";
            }
            else if (_screenType == Text.ScreenTypes.Input)
            {
                Screen = "╔" + new String('═', StartOptions.DisplayWidth) + "╗";
                for (int i = 0; i < currentInput.Length; i++)
                {
                    Screen += "║" + currentInput[i] + "║";
                }
                Screen += "╚" + new String('═', StartOptions.DisplayWidth) + "╝";
            }
            else if (_screenType == Text.ScreenTypes.Editor)
            {

            } 
            return Screen;
        }
    }
}
