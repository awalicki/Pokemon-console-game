using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_game
{
    internal class PokemonCollection
    {
        private List<Pokemon> _pokemons;
        private int _upgrades;


        public PokemonCollection(int[] pp) {
            _pokemons = new List<Pokemon>();
            _upgrades = 0;
        }

        public Pokemon this[int n] {
            get { return _pokemons[n]; }
            set { _pokemons[n] = value; }
        }

    }
}
