using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    public class pokeType
    {
        public string typeName { get; set; }
        public int Cod {  get; set; }

        public pokeType (string typeName, int cod)
        {
        this.Cod = cod;
        this.typeName = typeName; 
        }
    }
}
