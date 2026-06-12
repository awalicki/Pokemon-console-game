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


        public PokemonCollection() {
            _pokemons = new List<Pokemon>();
            _upgrades = 0;
        }

        public int Upgrades{
            get { return _upgrades;  }
            set { _upgrades = value; }
        }

        public Pokemon this[int n] {
            get { return _pokemons[n]; }
            set { _pokemons[n] = value; }
        }

        public List<Pokemon> getPokemons() { 
            return _pokemons;
        }

        public void addPokemon(Pokemon pokemon) {
            if (pokemon != null)
            {
                if (pokemon.Power == 0)
                {
                    _upgrades++;
                }
                else
                {
                    _pokemons.Add(pokemon);
                }
            }
        }

    }
}
