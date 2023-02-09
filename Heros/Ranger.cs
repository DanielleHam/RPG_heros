using rpg_heros_c.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public class Ranger : HeroBase
    {
        public Ranger(string Name) : base(Name)
        {
            this.Name = Name;
            this.Class = "Ranger";
            this.Attributes = new HeroAttributes(1, 7, 1);
            WeaponTypes = new WeaponType[] { WeaponType.Bows };
            ArmorTypes = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
        }

        public override int DamageCount()
        {
            if (WeaponSlots != null)
            {
                return WeaponSlots.WeaponDamage * (1 + Attributes.Dexterity / 100);
            }
            else
            {
                return 1 * (1 + Attributes.Intelligence / 100);
            }
        }

        public override void LevelUp()
        {
            Attributes.Strength += 1;
            Attributes.Dexterity += 5;
            Attributes.Intelligence += 1;
            Level++;
        }
    }
}
