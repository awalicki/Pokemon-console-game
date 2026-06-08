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
            if (this.Power * 1.1 > 10000)
            {
                this.Power = 10000;
                Console.WriteLine("Osiągnięto maks  level pokemona");
            }
            else
            {
                this.Power = this.Power * 1.1;

            }
        }

    }
}
