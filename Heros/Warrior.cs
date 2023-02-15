using rpg_heros_c.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public class Warrior : HeroBase
    {
        public Warrior(string Name) : base(Name)
        {
            this.Name = Name;
            this.Class = "Warrior";
            Level = 1;
            this.Attributes = new HeroAttributes(5, 2, 1);
            ArmorSlots = new Dictionary<EquipmentSlots, equipment.Armor>();
            WeaponTypes = new WeaponType[] { WeaponType.Axes, WeaponType.Hammers, WeaponType.Swords };
            ArmorTypes = new ArmorType[] { ArmorType.Plate, ArmorType.Mail };
        }

        public override double DamageCount()
        {
            double totalDamage;
            double baseDamage = TotalAttributes().Strength;

            if (WeaponSlots != null)
            {

                totalDamage = (WeaponSlots.WeaponDamage * (1 + baseDamage / 100));
            }
            else
            {
                totalDamage = (1 * (1 + baseDamage / 100));
            }
            return totalDamage;
        }

        public override void LevelUp()
        {
            Attributes.Strength += 3;
            Attributes.Dexterity += 2;
            Attributes.Intelligence += 1;
            Level++;
        }
    }
}
