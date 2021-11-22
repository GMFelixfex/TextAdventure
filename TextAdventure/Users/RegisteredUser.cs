using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Users
{
    class RegisteredUser
    {
        public string name;
        public string password;

        public RegisteredUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        private Adventures.Adventure CreateAdventure(object[] Adventuredaten)
        {
            return null;
        }

        private bool ReleaseAdventure(Adventures.Adventure adventure)
        {
            return true;
        }

        private int[] ReadStatistics(Adventures.Adventure adventure)
        {
            return null;
        }


    }
}
