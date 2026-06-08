using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonGame
{
    internal class RwrongValueException : Exception { 
        
        public RwrongValueException() : base("Podano złą wartość"){ }
    }
}
