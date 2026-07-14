using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class DIce
    {
        private static Random random = new Random();
        public static int rollTheDice() { 
            return (int)random.Next(1, 6);
        }
    }
}
