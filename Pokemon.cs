using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class Pokemon
    {
        private double _power;


        public Pokemon() { 
            Random random = new Random();

            Power = random.Next(1, 10000);
        }

        public double Power {
            get { return _power; }
            set
            {
                if (value > 0 && value <= 10000)
                {
                    _power = value;
                }
            }
        }

        public void upgrade() {
            if (this.Power * 2 > 10000)
            {
                this.Power = 10000;
                Console.WriteLine("You reach max level of your pokemon");
            }
            else
            {
                this.Power = this.Power * 2;

            }
        }

    }
}
