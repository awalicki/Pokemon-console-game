using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class DIce
    {
        public static int rollTheDice() { 
            Random random = new Random();
            return (int)random.Next(1, 6);
        }
    }
}
