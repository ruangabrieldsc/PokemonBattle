using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    public class Move
    {
        public string Name { get; set; }
        public int BP {  get; set; }
        public int PP { get; set; }      
        public int Acc {  get; set; }
        public pokeType pkType { get; set; }

        public Boolean critChance { get; set; }

        public Boolean phyEsp { get; set; }

        public Move (string name, int bP, int pP,int acc, pokeType ptype, Boolean crit, Boolean pE)
        {
            this.Name = name; 
            BP = bP;
            PP = pP;
            Acc = acc;
            this.pkType = ptype;
            this.critChance = crit;
            this.phyEsp = pE;
        }
    }
}
