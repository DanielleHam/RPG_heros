using rpg_heros_c.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_c.equipment
{
    public abstract class Equipment
    {
        public string Name { get; set; }

        public int RequiredLevel { get; set; }

        public EquipmentSlots equipmentSlot { get; set; }
    }
}
