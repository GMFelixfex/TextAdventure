using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Adventures
{
    class Player
    {
        public int positionX;
        public int prositionY;

        public Player(int positionX, int prositionY)
        {
            this.positionX = positionX;
            this.prositionY = prositionY;
        }


        private bool Walk(int direction)
        {
            return true;
        }

        private void Interact()
        {
             
        }

        private bool CloseGame()
        {
            return true;
        }
    }


}
