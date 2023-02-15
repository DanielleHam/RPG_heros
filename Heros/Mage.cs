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
            ArmorSlots = new Dictionary<EquipmentSlots, equipment.Armor>();
            WeaponTypes = new WeaponType[] { WeaponType.Staffs, WeaponType.Wands };
            ArmorTypes = new ArmorType[] { ArmorType.Cloth };
        }


        public override double DamageCount()
        {
            double totalDamage;
            double baseDamage = TotalAttributes().Intelligence; 

            if(WeaponSlots != null)
            {
               totalDamage = (WeaponSlots.WeaponDamage * (1 + baseDamage / 100));
            } else
            {
                totalDamage = (1 * (1 + baseDamage / 100));
            }
            return totalDamage;
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
