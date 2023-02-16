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
    public class WarriorTests
    {
        // creation 
        [Fact]
        public void Warrior_NameAfterCreation_ShouldReturnName()
        {
            //arrange & act
            Warrior newHero = new Warrior("Dan");

            //assert
            Assert.Equal("Dan", newHero.Name);
        }

        [Fact]
        public void Warrior_LevelAfterCreation_ShouldReturnOne()
        {
            Warrior newHero = new Warrior("Dan");

            //assert
            Assert.Equal(1, newHero.Level);
        }

        [Fact]
        public void Warrior_AttributesAfterCreation_ShouldReturnAttributes()
        {
            //arrange & act 
            Warrior newHero = new Warrior("Dan");

            // assert
            Assert.True(
                newHero.Attributes.Strength == 5 &&
                newHero.Attributes.Dexterity == 2 &&
                newHero.Attributes.Intelligence == 1);
        }

        // Level up 
        [Fact]
        public void Warrior_LevelAfterLevelUp_ShouldRetunTwo()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(2, newHero.Level);
        }

        [Fact]
        public void Warrior_AttributesAfterLevelUp_ShouldReturnAttributes()
        {
            // arrange
            Warrior newHero = new Warrior("Dan");
            int levelUpStrength = 5 + 3;
            int levelUpDexterity = 2 + 2;
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
        public void Warrior_equipValidWeaponType_ShouldReturnTypeOfWeaponInSlot()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);

            //act 
            newHero.SetWeapon(commonAxe);

            //assert
            Assert.Equal(WeaponType.Axes, newHero.WeaponSlots.type);
        }

        [Fact]
        public void Warrior_equipValidWeaponLevel_ShouldReturnWeaponLevel()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);

            //act 
            newHero.SetWeapon(commonAxe);

            //assert
            Assert.Equal(commonAxe.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Warrior_equipInvalidWeaponLevel_ShouldThrowException()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 2);

            //act 

            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(commonAxe));
        }

        [Fact]
        public void Warrior_equipInvalidWeaponType_ShouldThrowException()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Weapon commonDagger = new("Common Dagger", WeaponType.Daggers, 2, 1);

            //act 

            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(commonDagger));
        }

        // armor equip 
        [Fact]
        public void Warrior_equipValidArmorType_ShouldReturnTypeOfArmorInSlot()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);


            //act 
            newHero.SetArmor(plate);

            //assert
            Assert.Equal(ArmorType.Plate, newHero.ArmorSlots[plate.equipmentSlot].armorType);
        }

        [Fact]
        public void Warrior_equipValidArmorLevel_ShouldReturnArmorLevel()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);


            //act 
            newHero.SetArmor(plate);

            //assert
            Assert.Equal(plate.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Warrior_equipInvalidArmorLevel_ShouldThrowException()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 2, 1, 0, 0);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(plate));
        }

        [Fact]
        public void Warrior_equipInvalidArmorType_ShouldThrowException()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(leather));
        }

        // attributes 
        [Fact]
        public void Warrior_TotalAttributeNoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");

            int totalStrength = 5;
            int totalDexterity = 2;
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
        public void Warrior_TotalAttributeOneArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            int totalStrength = 5 + 1;
            int totalDexterity = 2 + 0;
            int totalIntelligence = 1 + 0;

            //act 
            newHero.SetArmor(plate);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(
                total.Strength == totalStrength &&
                total.Dexterity == totalDexterity &&
                total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Warrior_TotalAttributeTwoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);
            Armor hat = new Armor("Common warrior hat", EquipmentSlots.Head, ArmorType.Plate, 1, 0, 0, 3);

            int totalStrength = 5 + 1 + 0;
            int totalDexterity = 2 + 0 + 0;
            int totalIntelligence = 1 + 0 + 3;

            //act 
            newHero.SetArmor(plate);
            newHero.SetArmor(hat);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(total.Strength == totalStrength && total.Dexterity == totalDexterity && total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Warrior_TotalAttributeTwoArmorWithReplaced_ShouldReturnTotalAttributes()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);
            Armor hat = new Armor("Common warrior hat", EquipmentSlots.Head, ArmorType.Plate, 1, 0, 0, 3);
            Armor niceHat = new Armor("Common warrior hat for party's", EquipmentSlots.Head, ArmorType.Plate, 1, 1, 2, 3);

            int totalStrength = 5 + 1 + 1;
            int totalDexterity = 2 + 0 + 2;
            int totalIntelligence = 1 + 0 + 3;

            //act 
            newHero.SetArmor(plate);
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
        public void Warrior_TotalDamagesNoEquipment_ShouldReturnTotalDamages()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");

            //act 

            double expeted = Math.Round(1.05, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Warrior_TotalDamagesWithWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1); ;


            //act 
            newHero.SetWeapon(commonAxe);

            double expeted = Math.Round(2.1, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Warrior_TotalDamagesWithReplacedWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);
            Weapon fineAxe = new Weapon("Fine Axe", WeaponType.Axes, 3, 1);

            //act 
            newHero.SetWeapon(commonAxe);
            newHero.SetWeapon(fineAxe);

            double expeted = Math.Round(3.15, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Warrior_TotalDamagesWithWeaponAndArmor_ShouldReturnTotalDamages()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            //act 
            newHero.SetWeapon(commonAxe);
            newHero.SetArmor(plate);

            double expeted = Math.Round(2.12, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Warrior_DisplayInfo_ShouldReturnInfo()
        {
            //arrange 
            Warrior newHero = new Warrior("Dan");
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
