﻿using rpg_heros_c.enums;
using rpg_heros_c.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_test
{
    public class WeaponTest
    {

        [Fact] 
        public void Weapon_NameAfterCeation_ShoudeReturnName()
        {
            //arrange & act
            Weapon commonAxe = new("Common Axe", WeaponType.Axes, 2, 1);

            // Assert
            Assert.Equal("Common Axe", commonAxe.Name);
        }

        [Fact]
        public void Weapon_SlotAfterCeation_ShoudeReturnSlot()
        {
            //arrange & act
            Weapon commonAxe = new("Common Axe", WeaponType.Axes, 2, 1);

            // Assert
            Assert.Equal(EquipmentSlots.Weapon, commonAxe.equipmentSlot);
        }

        [Fact]
        public void Weapon_TypeAfterCeation_ShoudeReturnType()
        {
            //arrange & act
            Weapon commonAxe = new("Common Axe", WeaponType.Axes, 2, 1);

            // Assert
            Assert.Equal(WeaponType.Axes, commonAxe.type);
        }

        [Fact]
        public void Weapon_RequiredLevelAfterCeation_ShoudeReturnLevel()
        {
            //arrange & act
            Weapon commonAxe = new("Common Axe", WeaponType.Axes, 2, 1);

            // Assert
            Assert.Equal(1, commonAxe.RequiredLevel);
        }

        [Fact]
        public void Weapon_DanamgeAfterCeation_ShoudeReturnDamage()
        {
            //arrange & act
            Weapon commonAxe = new("Common Axe", WeaponType.Axes, 2, 1);

            // Assert
            Assert.Equal(2, commonAxe.WeaponDamage);
        }
    }
}
