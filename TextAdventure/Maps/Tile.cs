using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Maps
{
    class Tile
    {
        public string description { get; set; }
        public char mapsymbol { get; set; }
        public string interaction { get; set; }

        public Tile(string description, char mapsymbol, string interaction)
        {
            this.description = description;
            this.mapsymbol = mapsymbol;
            this.interaction = interaction;
        }
    }
}
