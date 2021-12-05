using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Options
{
    class StartOptions
    {
        public static int ScreenHeight = 50;
        public static int ScreenWidth = 150;
        public static int DisplayHeight = ScreenHeight-2;
        public static int DisplayWidth = ScreenWidth-2;
        public static int MapDisplayWidth = 87;
        public static int DescDisplayHeight = 27;
        public static int DescDisplayWidth = DisplayWidth - (MapDisplayWidth + 1);
        public static int IntDisplayHeight = DisplayHeight - (DescDisplayHeight);
    }
}
