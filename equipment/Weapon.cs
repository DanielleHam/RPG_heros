using rpg_heros_c.enums;
using rpg_heros_c.equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.Heros
{
    public class Weapon : Equipment
    {
        public WeaponType type { get; set; } 

        public int WeaponDamage { get; set; }
        
        public Weapon(string Name, WeaponType type, int WeaponDamage, int RequiredLevel) 
        {
            this.Name= Name;
            this.equipmentSlot = EquipmentSlots.Weapon;
            this.type = type;   
            this.WeaponDamage = WeaponDamage;
            this.RequiredLevel = RequiredLevel;
        }
    }
}
