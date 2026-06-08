using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonGame
{
    internal class Cell
    {
        public int x {get; set;}
        public int y {get; set;}

        //If there is no pokemon on this field this value will be set to 0
        public double pokemon_power {get; set;}
        

        public bool super_potion {get; set;}


        public Cell(int x, int y) 
        {
            Random random = new Random();
            this.x = x;
            this.y = y;
            int power = random.Next(1, 10000);
            if (power % 10 == 0)
            {
                super_potion = true;
                pokemon_power = 0;
            }
            else 
            { 
                super_potion = false;
                pokemon_power = power;
            }
            
        }

    }
}
