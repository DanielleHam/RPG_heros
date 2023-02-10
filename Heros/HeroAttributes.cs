using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public class HeroAttributes
    {
        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public override string? ToString()
        {
            return string.Format("Strength: " + Strength + "\n" +  "Dexterity: " + Dexterity + "\n" + "Intelligence " + Intelligence);
        }
    }
}
