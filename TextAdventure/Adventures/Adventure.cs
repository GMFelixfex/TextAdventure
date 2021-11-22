using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Adventures
{
    class Adventure
    {
        public string titel;
        public string description;
        public string[][] fieldInfo;
        public int spawnpointX;
        public int spawnpointY;
        public int totalPlayerCount;
        public float averagePlayerCount;

        public Adventure(string titel, string description, string[][] fieldInfo, int spawnpointX, int spawnpointY, int totalPlayerCount, float averagePlayerCount)
        {
            this.titel = titel;
            this.description = description;
            this.fieldInfo = fieldInfo;
            this.spawnpointX = spawnpointX;
            this.spawnpointY = spawnpointY;
            this.totalPlayerCount = totalPlayerCount;
            this.averagePlayerCount = averagePlayerCount;
        }

        private void CountPlayers()
        {

        }

        private void CountMoves()
        {

        }
    }
}
