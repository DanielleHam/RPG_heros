using rpg_heros_c.enums;
using rpg_heros_c.equipment;
using rpg_heros_c.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_test
{
    public class ArmorTest
    {
        [Fact]
        public void Armor_NameAfterCeation_ShoudeReturnName()
        {
            //arrange & act
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            // Assert
            Assert.Equal("Common Plate Chest", plate.Name);
        }

        [Fact]
        public void Armor_SlotAfterCeation_ShoudeReturnSlot()
        {
            //arrange & act
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            // Assert
            Assert.Equal(EquipmentSlots.Body, plate.equipmentSlot);
        }

        [Fact]
        public void Armor_TypeAfterCeation_ShoudeReturnType()
        {
            //arrange & act
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            // Assert
            Assert.Equal(ArmorType.Plate, plate.armorType);
        }

        [Fact]
        public void Armor_RequiredLevelAfterCeation_ShoudeReturnLevel()
        {
            //arrange & act
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            // Assert
            Assert.Equal(1, plate.RequiredLevel);
        }

        [Fact]
        public void Armor_StengthAfterCreation_ShoudRetunOne()
        {
            //arrange & act
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            //assert
            Assert.Equal(1, plate.ArmorAttributes.Strength);
        }

        [Fact]
        public void Armor_DexterityAfterCreation_ShoudReturnZero()
        {
            //arrange & act
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            //assert
            Assert.Equal(0, plate.ArmorAttributes.Dexterity);
        }

        [Fact]
        public void Armor_IntelligenceAfterCreation_ShoudRetunZero()
        {
            //arrange & act
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            //assert
            Assert.Equal(0, plate.ArmorAttributes.Intelligence);
        }
    }
}
