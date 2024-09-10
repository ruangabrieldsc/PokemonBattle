using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    public class Ability
    {
        public string abName { get; set; }
        public int abCod {  get; set; }

        public string description { get; set; }
        public Ability(string Name, int cod , string description)
        {
            abName = Name;
            abCod = cod;
            this.description = description;
        }
    }
}
