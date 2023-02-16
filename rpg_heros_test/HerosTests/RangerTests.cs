using rpg_heros_c.enums;
using rpg_heros_c.equipment;
using rpg_heros_c.exceptions;
using rpg_heros_c.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_heros_test.HerosTests
{
    public class RangerTests
    {
        // creation 
        [Fact]
        public void Ranger_NameAfterCreation_ShouldReturnName()
        {
            //arrange & act
            Ranger newHero = new Ranger("Dan");

            //assert
            Assert.Equal("Dan", newHero.Name);
        }

        [Fact]
        public void Ranger_LevelAfterCreation_ShouldReturnOne()
        {
            Ranger newHero = new Ranger("Dan");

            //assert
            Assert.Equal(1, newHero.Level);
        }

        [Fact]
        public void Ranger_AttributesAfterCreation_ShouldReturnAttributes()
        {
            //arrange & act 
            Ranger newHero = new Ranger("Dan");

            // assert
            Assert.True(
                newHero.Attributes.Strength == 1 &&
                newHero.Attributes.Dexterity == 7 &&
                newHero.Attributes.Intelligence == 1);
        }

        // Level up 
        [Fact]
        public void Ranger_LevelAfterLevelUp_ShouldRetunTwo()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(2, newHero.Level);
        }

        [Fact]
        public void Ranger_AttributesAfterLevelUp_ShouldReturnAttributes()
        {
            // arrange
            Ranger newHero = new Ranger("Dan");
            int levelUpStrength = 1 + 1;
            int levelUpDexterity = 7 + 5;
            int levelUpIntelligence = 1 + 1;

            //act
            newHero.LevelUp();

            //assert
            Assert.True(
                newHero.Attributes.Strength == levelUpStrength &&
                newHero.Attributes.Dexterity == levelUpDexterity &&
                newHero.Attributes.Intelligence == levelUpIntelligence);
        }

        // weapon equip 

        [Fact]
        public void Ranger_equipValidWeaponType_ShouldReturnTypeOfWeaponInSlot()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Weapon Bow = new("Bow", WeaponType.Bows, 2, 1);

            //act 
            newHero.SetWeapon(Bow);

            //assert
            Assert.Equal(WeaponType.Bows, newHero.WeaponSlots.type);
        }

        [Fact]
        public void Ranger_equipValidWeaponLevel_ShouldReturnWeaponLevel()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Weapon Bow = new("Bow", WeaponType.Bows, 2, 1);

            //act 
            newHero.SetWeapon(Bow);

            //assert
            Assert.Equal(Bow.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Ranger_equipInvalidWeaponLevel_ShouldThrowException()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Weapon Bow = new("Bow", WeaponType.Bows, 2, 2);

            //act 

            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(Bow));
        }

        [Fact]
        public void Ranger_equipInvalidWeaponType_ShouldThrowException()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);

            //act 

            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(commonAxe));
        }

        // armor equip 
        [Fact]
        public void Ranger_equipValidArmorType_ShouldReturnTypeOfArmorInSlot()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);


            //act 
            newHero.SetArmor(leather);

            //assert
            Assert.Equal(ArmorType.Leather, newHero.ArmorSlots[leather.equipmentSlot].armorType);
        }

        [Fact]
        public void Ranger_equipValidArmorLevel_ShouldReturnArmorLevel()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);


            //act 
            newHero.SetArmor(leather);

            //assert
            Assert.Equal(leather.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Ranger_equipInvalidArmorLevel_ShouldThrowException()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 2, 1, 0, 2);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(leather));
        }

        [Fact]
        public void Ranger_equipInvalidArmorType_ShouldThrowException()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(plate));
        }

        // attributes 
        [Fact]
        public void Ranger_TotalAttributeNoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");

            int totalStrength = 1;
            int totalDexterity = 7;
            int totalIntelligence = 1;

            //act 
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(
                total.Strength == totalStrength &&
                total.Dexterity == totalDexterity &&
                total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Ranger_TotalAttributeOneArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);

            int totalStrength = 1 + 1;
            int totalDexterity = 7 + 0;
            int totalIntelligence = 1 + 2;

            //act 
            newHero.SetArmor(leather);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(
                total.Strength == totalStrength &&
                total.Dexterity == totalDexterity &&
                total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Ranger_TotalAttributeTwoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);
            Armor hat = new Armor("Common Ranger hat", EquipmentSlots.Head, ArmorType.Leather, 1, 0, 0, 3);

            int totalStrength = 1 + 1 + 0;
            int totalDexterity = 7 + 0 + 0;
            int totalIntelligence = 1 + 2 + 3;

            //act 
            newHero.SetArmor(leather);
            newHero.SetArmor(hat);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(
                total.Strength == totalStrength &&
                total.Dexterity == totalDexterity &&
                total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Ranger_TotalAttributeTwoArmorWithReplaced_ShouldReturnTotalAttributes()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);
            Armor hat = new Armor("Common Ranger hat", EquipmentSlots.Head, ArmorType.Leather, 1, 0, 0, 3);
            Armor niceHat = new Armor("Common Ranger hat for party's", EquipmentSlots.Head, ArmorType.Leather, 1, 1, 2, 3);

            int totalStrength = 1 + 1 +1;
            int totalDexterity = 7 + 0 + 2;
            int totalIntelligence = 1 + 2 + 3;

            //act 
            newHero.SetArmor(leather);
            newHero.SetArmor(hat);
            newHero.SetArmor(niceHat);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(
                total.Strength == totalStrength &&
                total.Dexterity == totalDexterity &&
                total.Intelligence == totalIntelligence);
        }

        // Damages calculation
        [Fact]
        public void Ranger_TotalDamagesNoEquipment_ShouldReturnTotalDamages()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");

            //act 

            double expeted = 1.07;

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Ranger_TotalDamagesWithWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Weapon Bow = new("Bow", WeaponType.Bows, 2, 1);

            //act 
            newHero.SetWeapon(Bow);
          
            double expeted = 2.14;

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Ranger_TotalDamagesWithReplacedWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Weapon Bow = new("Bow", WeaponType.Bows, 2, 1);
            Weapon fineBow = new("Bow in fine tree", WeaponType.Bows, 3, 1);

            //act 
            newHero.SetWeapon(Bow);
            newHero.SetWeapon(fineBow);

            double expeted = 3.21;

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Ranger_TotalDamagesWithWeaponAndArmor_ShouldReturnTotalDamages()
        {
            //arrange 
            Ranger newHero = new Ranger("Dan");
            Weapon Bow = new("Bow", WeaponType.Bows, 2, 1);
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);

            //act 
            newHero.SetWeapon(Bow);
            newHero.SetArmor(leather);

            double expeted = 2.14;

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Ranger_DisplayInfo_ShouldReturnInfo()
        {   
            //arrange 
            Ranger newHero = new Ranger("Dan");
            StringBuilder heroInfo = new StringBuilder();

            //act 

            var totalAtt = newHero.TotalAttributes();

            heroInfo.AppendLine("Here is the info about your Hero: ");
            heroInfo.AppendLine("Name: " + newHero.Name);
            heroInfo.AppendLine("Level: " + newHero.Level);
            heroInfo.AppendLine("Class: " + newHero.Class);
            heroInfo.AppendLine();

            heroInfo.AppendLine(totalAtt.ToString());
            heroInfo.AppendLine("Total damage: " + newHero.DamageCount());

            //assert
            Assert.Equal(heroInfo.ToString(), newHero.Display());
        }

        
    }
}

