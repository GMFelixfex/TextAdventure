using System;
using System.Timers;
using TextAdventure.Display;
using TextAdventure.TextFormatting;
using TextAdventure.Options;
using TextAdventure.FileHandler;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.SetWindowSize(StartOptions.ScreenWidth, StartOptions.ScreenHeight);
            Console.ForegroundColor = ConsoleColor.White;
            Timer aTimer;
            aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 100;
            aTimer.Enabled = true;
            new System.Threading.AutoResetEvent(false).WaitOne();
            */
            Map map1 = new Map(2,2);
            Handler.WriteJSON<Map>("/save", "test.txt", map1);
            Console.WriteLine(Handler.ReadFile("/save", "test.txt"));
            Map mapCopy = Handler.ReadJSON<Map>("/save", "test.txt");
            Console.WriteLine(mapCopy.x);
            Console.WriteLine(mapCopy.y);
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Output.setCurrentText("\u001b[31mHello World!\u001b[0m");



            //Display type Menu
            TextDisplay Output = TextDisplay.getInstance();
            
            TextFormatter.formatMenu(new string[] {"Register", "Login", "Editor", "Options", "Play" ,"Exit" }, "TEXTADVENTURE", 2);
            string currentScreen = TextFormatter.GetFormatedScreen(Text.ScreenTypes.Menu);
            

            //Display type Ingame
            /*
            TextFormatter.formatDescrption("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.Lorem ipsum dolor sit amet,  FIN");
            TextFormatter.formatMap(new string[] {"XXXXXXXXXX","XXXXVVVXXX", "XXXXXXXXXX", "XXXXXPXXXX", "XXXXXXCCXX", "XXXXXXXMMM", "XXXXXXXXMM", "XXXXXXMMMM" });
            TextFormatter.formatInteraction(new string[] { "Register", "Login", "Editor", "Options", "Play", "Exit" }, 2);

            string currentScreen = TextFormatter.GetFormatedScreen(Text.ScreenTypes.Ingame);
            */

            //Display Type Input
            /*
            TextFormatter.formatInput("Input Title","Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.At vero eos et accusam et justo duo dolores et ea rebum.Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.Lorem ipsum dolor sit amet,  FIN");
            string currentScreen = TextFormatter.GetFormatedScreen(Text.ScreenTypes.Input);
            */

            Output.setCurrentText(currentScreen);
            Output.displayText();
        }
    }
}
