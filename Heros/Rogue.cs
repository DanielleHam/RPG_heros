using rpg_heros_c.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public class Rogue : HeroBase
    {
        public Rogue(string Name) : base(Name)
        {
            this.Name = Name;
            this.Class = "Rouge";
            Level = 1;
            this.Attributes = new HeroAttributes(2, 6, 1);
            ArmorSlots = new Dictionary<EquipmentSlots, equipment.Armor>();
            WeaponTypes = new WeaponType[] { WeaponType.Daggers, WeaponType.Swords };
            ArmorTypes = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
        }

        public override double DamageCount()
        {
            double totalDamage;
            double baseDamage = TotalAttributes().Dexterity;

            if (WeaponSlots != null)
            {

                totalDamage = (WeaponSlots.WeaponDamage * (1 + baseDamage / 100));
            }
            else
            {
                totalDamage = (1 * (1 + baseDamage / 100));
            }
            return Math.Round(totalDamage, 2);
        }

        public override void LevelUp()
        {
            Attributes.Strength += 1;
            Attributes.Dexterity += 4;
            Attributes.Intelligence += 1;
            Level++;
        }
    }
}
