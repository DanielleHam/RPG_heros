using rpg_heros_c.enums;
using rpg_heros_c.equipment;
using rpg_heros_c.exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public abstract class HeroBase
    {
        public string Name { get; protected set; }

        public HeroBase(string Name)
        {
            this.Name = Name;
        }

        public string Class { get; set; }

        public int Level
        {
            get; set;
        }

        public abstract void LevelUp();


        public HeroAttributes Attributes;

        public WeaponType[] WeaponTypes; // what the hero can have

        public Weapon WeaponSlots; // what the Hero has

        public ArmorType[] ArmorTypes; // What the Hero can have
        public Dictionary<EquipmentSlots, Armor> ArmorSlots; // what the Hero has

        public void SetWeapon(Weapon weapon)
        {

            if (Level == weapon.RequiredLevel)
            {
                if (Array.Exists(WeaponTypes, element => element == weapon.type))
                {
                    WeaponSlots = weapon;
                }
                else
                {
                    throw new InvalidWeaponException("you can't equip that sort of weapon!");
                }
            }
            else
            {
                throw new InvalidWeaponException("you have to low of a level for this weapon!");

            }


        }
        public void SetArmor(Armor armor)
        {
            if (Level == armor.RequiredLevel)
            {
                if (Array.Exists(ArmorTypes, element => element == armor.armorType))
                {
                    ArmorSlots[armor.equipmentSlot] = armor;
                }
                else
                {
                    throw new InvalidArmorException("you can't equip that sort of armor!");
                }
            } else
            {
                throw new InvalidArmorException("you have to low of a level for this armor!");
            }


        }

        public abstract double DamageCount();

        public HeroAttributes TotalAttributes()
        {

            int totalStr = Attributes.Strength;
            int totalInt = Attributes.Intelligence;
            int totalDex = Attributes.Dexterity;
            if (ArmorSlots != null)
            {
                foreach (Armor armor in ArmorSlots.Values)
                {
                    totalStr += armor.ArmorAttributes.Strength;
                    totalInt += armor.ArmorAttributes.Intelligence;
                    totalDex += armor.ArmorAttributes.Dexterity;

                }
            }


            HeroAttributes totalHeroAttributes = new HeroAttributes(totalStr, totalDex, totalInt);



            return totalHeroAttributes;
        }

        public string Display()
        {

            StringBuilder heroInfo = new StringBuilder();

            var totalAtt = TotalAttributes();

            heroInfo.AppendLine("Here is the info about your Hero: ");
            heroInfo.AppendLine("Name: " + this.Name);
            heroInfo.AppendLine("Level: " + this.Level);
            heroInfo.AppendLine("Class: " + this.Class);
            heroInfo.AppendLine();
           
            heroInfo.AppendLine(totalAtt.ToString());
            heroInfo.AppendLine("Total damage: " + DamageCount());

            return heroInfo.ToString();
        }


    }
}
