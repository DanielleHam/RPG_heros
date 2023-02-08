using rpg_heros_c.enums;
using rpg_heros_c.equipment;
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
       

        public HeroAttributes Attributes { get; set; }

        public WeaponType[] WeaponTypes; // what the hero can have

        public  Weapon WeaponSlots; // what the Hero has

        public ArmorType[] ArmorTypes; // What the Hero can have
        public Dictionary<EquipmentSlots, Armor> ArmorSlots; // what the Hero has

        public void SetWeapon(Weapon weapon)
        {
            WeaponSlots = weapon;
        }
        public void SetArmor(Armor armor)
        {
            ArmorSlots[armor.equipmentSlot] = armor;
        }

        public abstract int DamageCount();

        public HeroAttributes TotalAttributes()
        {
           
            int totalStr = Attributes.Strength;
            int totalInt = Attributes.Intelligence;
            int totalDex = Attributes.Dexterity;
            foreach (Armor armor in ArmorSlots.Values)
            {
                totalStr += armor.ArmorAttributes.Strength;
                totalInt += armor.ArmorAttributes.Intelligence;
                totalDex += armor.ArmorAttributes.Dexterity;
                  
            }

            HeroAttributes totalHeroAttributes = new HeroAttributes(totalStr, totalDex, totalInt);

            return totalHeroAttributes;
        }

        public void Display()
        {
            Console.WriteLine("Here is the info about your Hero: ");
            Console.WriteLine("Name: ", this.Name);
            Console.WriteLine("Level: ", this.Level);
            Console.WriteLine("Class: ", this.Class);
            Console.WriteLine("Strength: ", Attributes.Strength);
            Console.WriteLine("Intelligence: ", Attributes.Intelligence);
            Console.WriteLine("Dexterity: ", Attributes.Dexterity);
            Console.WriteLine("Armors: ");
            foreach (Armor armor in ArmorSlots.Values)
            {
                Console.WriteLine("Name: ", armor.Name);
                Console.WriteLine("Required Level: ", armor.RequiredLevel);
                Console.WriteLine("Slot: ", armor.equipmentSlot);
                Console.WriteLine("Armor Type: ", armor.armorType);
                Console.WriteLine("Armor Attribute: str: ", armor.ArmorAttributes.Strength, ", dex: ", armor.ArmorAttributes.Dexterity, ", int: ", armor.ArmorAttributes.Intelligence);
                Console.WriteLine();
            }

            Console.WriteLine("Weapon: ");
            Console.WriteLine("Name: ", WeaponSlots.Name);
            Console.WriteLine("Required Level: ", WeaponSlots.RequiredLevel);
            Console.WriteLine("Slot: ", WeaponSlots.equipmentSlot);
            Console.WriteLine("Weapon type: ", WeaponSlots.type);
            Console.WriteLine("Weapon damage: ", WeaponSlots.WeaponDamage);
        }


    }
}
