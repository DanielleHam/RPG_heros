using rpg_heros_c.enums;
using rpg_heros_c.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.equipment
{
    public class Armor
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }

        public EquipmentSlots equipmentSlot { get; set; }

        public ArmorTypes armorType { get; set; }

        public HeroAttributes ArmorAttributes { get; set; }

        public Armor(string Name, EquipmentSlots slot, ArmorTypes armorType, HeroAttributes attributes) // set slot choses in program cs
        {
            this.Name = Name;
            this.equipmentSlot = slot;
            this.armorType = armorType;
            this.ArmorAttributes = attributes;
        }
    }
}
