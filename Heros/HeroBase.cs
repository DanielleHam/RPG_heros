using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    abstract class HeroBase
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public HeroAttributes Attributes { get; set; }

        public abstract WeaponTypes[];


    }
}
