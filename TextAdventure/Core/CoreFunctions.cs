using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Display;
using TextAdventure.Text;
using TextAdventure.TextFormatting;

namespace TextAdventure.Core
{
    class CoreFunctions
    {
        public static ScreenTypes ScreenType = ScreenTypes.Menu;
        public static int MenuSelected = 0;
        public static int MenuID = 0;
        public static Menu[] AllMenus = Menu.CreateAllMenu();
        private static int previousInputMenu;
        private static string currentInputText = "";
        private static int currentInteractionSelected = 1;
        private static int TEMPMaxinteractions = 4;
        private static int[] playerPosition = new int[]{ 2, 0 };
        private static Maps.Map testmap = Maps.Map.getTestMap();
        private static string[] testMapString = testmap.getMapSymbols();

        public static void GetCurrentScreen()
        {

            if (ScreenType == ScreenTypes.Menu)
            {
                TextFormatter.formatMenu(AllMenus[MenuID].choices, AllMenus[MenuID].title, AllMenus[MenuID].selected);

            } 
            else if (ScreenType == ScreenTypes.Ingame)
            {
                //TextFormatter.formatDescrption("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.Lorem ipsum dolor sit amet,  FIN");
                TextFormatter.formatDescrption(testmap.tiles[playerPosition[0], playerPosition[1]].description);
                TextFormatter.formatMap(playerPosition,testMapString);
                TextFormatter.formatInteraction(new string[] { "North", "West", "South", "East", "Interact" }, currentInteractionSelected);

            }
            else if (ScreenType == ScreenTypes.Input)
            {
                //TextFormatter.formatInput("Input Title", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.Lorem ipsum dolor sit amet,  FIN");
                TextFormatter.formatInput("Input Tile", currentInputText);
            }


            TextDisplay Output = TextDisplay.getInstance();
            string currentScreen = TextFormatter.GetFormatedScreen(ScreenType);
            Output.setCurrentScreen(currentScreen+"\n"+MenuID);
            
        }

        public static void InputHandler(ConsoleKeyInfo keyinfo)
        {
            if (ScreenType == ScreenTypes.Menu)
            {
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    if (ScreenType == ScreenTypes.Menu)
                    {

                        int newMenuID = AllMenus[MenuID].linkedMenu[AllMenus[MenuID].selected];
                        if (newMenuID >= 0)
                        {

                                AllMenus[newMenuID].previousMenu = MenuID;
                                MenuID = newMenuID;
                            
                        }
                        else
                        {
                            if (newMenuID == -1)
                            {
                                previousInputMenu = MenuID;
                                ScreenType = ScreenTypes.Input;
                            }
                            else if (newMenuID == -2)
                            {
                                //Code for Submit
                            }
                            else if (newMenuID == -3)
                            {
                                ScreenType = ScreenTypes.Ingame;
                            }
                            else if (newMenuID == -4)
                            {
                                //Code edit
                            }

                        }


                    }
                }
                else if (keyinfo.Key == ConsoleKey.Escape)
                {

                    int prev = AllMenus[MenuID].previousMenu;
                    if (MenuID == 6)
                    {
                        ScreenType = ScreenTypes.Ingame;
                    }
                    else if (prev >= 0)
                    {
                        MenuID = prev;
                    }

                }
                else if (keyinfo.Key == ConsoleKey.UpArrow && AllMenus[MenuID].selected > 1)
                {
                    AllMenus[MenuID].selected--;
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow && AllMenus[MenuID].selected < AllMenus[MenuID].choices.Length - 1)
                {
                    AllMenus[MenuID].selected++;
                }
            }

            
            //Ingame Controls
            else if (ScreenType == ScreenTypes.Ingame)
            {
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    //Interaction menu
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (currentInteractionSelected>0)
                    {
                        currentInteractionSelected--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (currentInteractionSelected < TEMPMaxinteractions)
                    {
                        currentInteractionSelected++;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Escape)
                {
                    MenuID = 6;
                    ScreenType = ScreenTypes.Menu;
                }
                else if (keyinfo.Key == ConsoleKey.S)
                {
                    if(playerPosition[0] < testmap.tiles.GetLength(0)-1)
                    {
                        playerPosition[0]++;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.W)
                {
                    if (playerPosition[0] > 0)
                    {
                        playerPosition[0]--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.A)
                {
                    if (playerPosition[1] > 0)
                    {
                        playerPosition[1]--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.D)
                {
                    if (playerPosition[1] < testmap.tiles.GetLength(1)-1)
                    {
                        playerPosition[1]++;
                    }
                }
            }

            
            else if (ScreenType == ScreenTypes.Input)
            {
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    //Save CurrentInputText to file/
                    MenuID = previousInputMenu;
                    ScreenType = ScreenTypes.Menu;
                }
                else if (keyinfo.Key == ConsoleKey.Escape)
                {
                    MenuID = previousInputMenu;
                    ScreenType = ScreenTypes.Menu;
                }
                else if (keyinfo.Key == ConsoleKey.Backspace)
                {
                    if (currentInputText.Length >0)
                    {
                        currentInputText = currentInputText.Remove(currentInputText.Length - 1);
                    }
                }
                else
                {
                    if (IsKeyAChar(keyinfo.Key)||IsKeyADigit(keyinfo.Key)||IsKeySpecial(keyinfo.Key))
                    {
                        currentInputText += keyinfo.KeyChar;
                    }

                }
            }
        }

        public static bool IsKeyAChar(ConsoleKey key)
        {
            return key >= ConsoleKey.A && key <= ConsoleKey.Z;
        }

        public static bool IsKeyADigit(ConsoleKey key)
        {
            return (key >= ConsoleKey.D0 && key <= ConsoleKey.D9) || (key >= ConsoleKey.NumPad0 && key <= ConsoleKey.NumPad9);
        }

        public static bool IsKeySpecial(ConsoleKey key)
        {
            return (key == ConsoleKey.Spacebar || key == ConsoleKey.OemComma || key == ConsoleKey.OemPeriod || key == ConsoleKey.OemMinus || key == ConsoleKey.OemPlus || key == ConsoleKey.Separator );
        }
    }
    
}
