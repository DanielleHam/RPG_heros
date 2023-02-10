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
        protected string Name { get; set; }

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
            heroInfo.AppendLine(" - Strength: " + Attributes.Strength);
            heroInfo.AppendLine(" - Intelligence: " + Attributes.Intelligence);
            heroInfo.AppendLine(" - Dexterity: " + Attributes.Dexterity);
            heroInfo.AppendLine();

            if (ArmorSlots != null)
            {
                heroInfo.AppendLine("Armor: ");

                foreach (Armor armor in ArmorSlots.Values)
                {
                    heroInfo.AppendLine(" - Name: " + armor.Name);
                    heroInfo.AppendLine(" - Required Level: " + armor.RequiredLevel);
                    heroInfo.AppendLine(" - Slot: " + armor.equipmentSlot);
                    heroInfo.AppendLine(" - Armor Type: " + armor.armorType);
                    heroInfo.AppendLine(" - Armor Attribute : str: " + armor.ArmorAttributes.Strength + ", dex: " + armor.ArmorAttributes.Dexterity + ", int: " + armor.ArmorAttributes.Intelligence);
                    heroInfo.AppendLine();
                }
            }
            else
            {
                heroInfo.AppendLine("Allowed armor: ");
                foreach (ArmorType armor in ArmorTypes)
                    heroInfo.AppendLine(" - " + armor);
                heroInfo.AppendLine();
            }



            if (WeaponSlots != null)
            {
                heroInfo.AppendLine("Weapon: ");
                heroInfo.AppendLine(" - Name: " + WeaponSlots.Name);
                heroInfo.AppendLine(" - Required Level: " + WeaponSlots.RequiredLevel);
                heroInfo.AppendLine(" - Slot: " + WeaponSlots.equipmentSlot);
                heroInfo.AppendLine(" - Weapon type: " + WeaponSlots.type);
                heroInfo.AppendLine(" - Weapon damage: " + WeaponSlots.WeaponDamage);
                heroInfo.AppendLine("Total Damage count: " + DamageCount());
            }
            else
            {
                heroInfo.AppendLine("Allowed weapons: ");
                foreach (WeaponType weapon in WeaponTypes)
                    heroInfo.AppendLine(" - " + weapon);
            }

            heroInfo.AppendLine();
            heroInfo.AppendLine("Total damage: " + DamageCount());
            heroInfo.AppendLine(totalAtt.ToString());


            return heroInfo.ToString();

        }


    }
}
