using rpg_heros_c.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public class Weapon
    {
        public string Name { get; set; }
        public WeaponType type { get; set; } 

        public int WeaponDamage { get; set; }

        public int RequiredLevel { get; set; }

        public EquipmentSlots equipmentSlot { get; set; }
        public Weapon(string Name) 
        {
            this.Name= Name;
            this.equipmentSlot = EquipmentSlots.Weapon;
        }
    }
}
