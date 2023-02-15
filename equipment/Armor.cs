using rpg_heros_c.enums;
using rpg_heros_c.exceptions;
using rpg_heros_c.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.equipment
{
    public class Armor : Equipment
    {

        public ArmorType armorType { get; set; }

        public HeroAttributes ArmorAttributes { get; set; }

        public Armor(string Name, EquipmentSlots slot, ArmorType armorType, int RequiredLevel, int str, int dex, int intel) // set in program cs
        {
            if (slot == EquipmentSlots.Weapon)
            {
                throw new InvalidArmorException("you can't create an armor as weapon!");
            }
            this.Name = Name;
            this.equipmentSlot = slot;
            this.armorType = armorType;
            this.RequiredLevel = RequiredLevel;
            this.ArmorAttributes = new HeroAttributes(str, dex, intel);
        }
    }
}
