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
            Attributes.Strength = 1;
            Attributes.Dexterity = 1;
            Attributes.Intelligence = 8;
            WeaponTypes = new WeaponType[] {WeaponType.Staffs, WeaponType.Wands};
            ArmorTypes = new ArmorType[] {ArmorType.Cloth };
        }


        public override int DamageCount()
        {
            throw new NotImplementedException();
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
