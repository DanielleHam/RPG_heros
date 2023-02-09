using rpg_heros_c.enums;
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

        public Armor(string Name, EquipmentSlots slot, ArmorType armorType, int RequiredLevel, HeroAttributes attributes) // set in program cs
        {
            this.Name = Name;
            this.equipmentSlot = slot;
            this.armorType = armorType;
            this.RequiredLevel = RequiredLevel;
            this.ArmorAttributes = attributes;
        }
    }
}
