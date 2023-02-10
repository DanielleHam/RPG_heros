using rpg_heros_c.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public class Mage : HeroBase
    {
        public Mage(string Name) : base(Name) 
        {
            this.Name = Name;
            this.Class = "Mage";
            Level = 1;
            this.Attributes = new HeroAttributes(1,1,8);
            WeaponTypes = new WeaponType[] { WeaponType.Staffs, WeaponType.Wands };
            ArmorTypes = new ArmorType[] { ArmorType.Cloth };
        }


        public override double DamageCount()
        {
            if(WeaponSlots != null)
            {
                return WeaponSlots.WeaponDamage * (1 + Attributes.Intelligence / 100);
            } else
            {
                return 1 * (1 + Attributes.Intelligence / 100);
            }
        }

        public override void LevelUp()
        {
            Attributes.Strength += 1;
            Attributes.Dexterity += 1;
            Attributes.Intelligence += 5;
            Level++;
        }
    }
}
