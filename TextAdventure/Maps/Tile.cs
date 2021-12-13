using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Maps
{
    class Tile
    {
        public string description;
        public char mapsymbol;
        public string interaction;

        public Tile(string description, char mapsymbol, string interaction)
        {
            this.description = description;
            this.mapsymbol = mapsymbol;
            this.interaction = interaction;
        }
    }
}
