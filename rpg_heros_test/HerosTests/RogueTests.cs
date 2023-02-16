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
    public class RogueTests
    {
        // creation 
        [Fact]
        public void Rogue_NameAfterCreation_ShouldReturnName()
        {
            //arrange & act
            Rogue newHero = new Rogue("Dan");

            //assert
            Assert.Equal("Dan", newHero.Name);
        }

        [Fact]
        public void Rogue_LevelAfterCreation_ShouldReturnOne()
        {
            Rogue newHero = new Rogue("Dan");

            //assert
            Assert.Equal(1, newHero.Level);
        }

        [Fact]
        public void Rogue_AttributesAfterCreation_ShouldReturnAttributes()
        {
            //arrange & act 
            Rogue newHero = new Rogue("Dan");

            // assert
            Assert.True(
                newHero.Attributes.Strength == 2 &&
                newHero.Attributes.Dexterity == 6 &&
                newHero.Attributes.Intelligence == 1);
        }

        // Level up 
        [Fact]
        public void Rogue_LevelAfterLevelUp_ShouldRetunTwo()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(2, newHero.Level);
        }

        [Fact]
        public void Rogue_AttributesAfterLevelUp_ShouldReturnAttributes()
        {
            // arrange
            Rogue newHero = new Rogue("Dan");
            int levelUpStrength = 2 + 1;
            int levelUpDexterity = 6 + 4;
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
        public void Rogue_equipValidWeaponType_ShouldReturnTypeOfWeaponInSlot()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Weapon commonDagger = new("Common Dagger", WeaponType.Daggers, 2, 1);

            //act 
            newHero.SetWeapon(commonDagger);

            //assert
            Assert.Equal(WeaponType.Daggers, newHero.WeaponSlots.type);
        }

        [Fact]
        public void Rogue_equipValidWeaponLevel_ShouldReturnWeaponLevel()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Weapon commonDagger = new("Common Dagger", WeaponType.Daggers, 2, 1);

            //act 
            newHero.SetWeapon(commonDagger);

            //assert
            Assert.Equal(commonDagger.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Rogue_equipInvalidWeaponLevel_ShouldThrowException()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Weapon dagger = new("Dagger", WeaponType.Daggers, 2, 2);

            //act 

            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(dagger));
        }

        [Fact]
        public void Rogue_equipInvalidWeaponType_ShouldThrowException()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);

            //act 

            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(commonAxe));
        }

        // armor equip 
        [Fact]
        public void Rogue_equipValidArmorType_ShouldReturnTypeOfArmorInSlot()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);


            //act 
            newHero.SetArmor(leather);

            //assert
            Assert.Equal(ArmorType.Leather, newHero.ArmorSlots[leather.equipmentSlot].armorType);
        }

        [Fact]
        public void Rogue_equipValidArmorLevel_ShouldReturnArmorLevel()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);


            //act 
            newHero.SetArmor(leather);

            //assert
            Assert.Equal(leather.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Rogue_equipInvalidArmorLevel_ShouldThrowException()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 2, 1, 0, 2);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(leather));
        }

        [Fact]
        public void Rogue_equipInvalidArmorType_ShouldThrowException()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(plate));
        }

        // attributes 
        [Fact]
        public void Rogue_TotalAttributeNoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");

            int totalStrength = 2;
            int totalDexterity = 6;
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
        public void Rogue_TotalAttributeOneArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);

            int totalStrength = 2 + 1;
            int totalDexterity = 6 + 0;
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
        public void Rogue_TotalAttributeTwoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);
            Armor hat = new Armor("Common rogue hat", EquipmentSlots.Head, ArmorType.Leather, 1, 0, 0, 3);

            int totalStrength = 2 + 1 + 0;
            int totalDexterity = 6 + 0 + 0;
            int totalIntelligence = 1 + 2 + 3;

            //act 
            newHero.SetArmor(leather);
            newHero.SetArmor(hat);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(total.Strength == totalStrength && total.Dexterity == totalDexterity && total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Rogue_TotalAttributeTwoArmorWithReplaced_ShouldReturnTotalAttributes()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);
            Armor hat = new Armor("Common rogue hat", EquipmentSlots.Head, ArmorType.Leather, 1, 0, 0, 3);
            Armor niceHat = new Armor("Common rogue hat for party's", EquipmentSlots.Head, ArmorType.Leather, 1, 1, 2, 3);

            int totalStrength = 2 + 1 + 1;
            int totalDexterity = 6 + 0 + 2;
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
        public void Rogue_TotalDamagesNoEquipment_ShouldReturnTotalDamages()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");

            //act 

            double expeted = Math.Round(1.06, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Rogue_TotalDamagesWithWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Weapon commonDagger = new("Common Dagger", WeaponType.Daggers, 2, 1);


            //act 
            newHero.SetWeapon(commonDagger);

            double expeted = Math.Round(2.12, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Rogue_TotalDamagesWithReplacedWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Weapon commonDagger = new("Common Dagger", WeaponType.Daggers, 2, 1);
            Weapon fineDagger = new("Fine Dagger", WeaponType.Daggers, 3, 1);

            //act 
            newHero.SetWeapon(commonDagger);
            newHero.SetWeapon(fineDagger);

            double expeted = Math.Round(3.18, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Rogue_TotalDamagesWithWeaponAndArmor_ShouldReturnTotalDamages()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
            Weapon commonDagger = new("Common Dagger", WeaponType.Daggers, 2, 1);
            Armor leather = new Armor("Common Leather cape", EquipmentSlots.Body, ArmorType.Leather, 1, 1, 0, 2);

            //act 
            newHero.SetWeapon(commonDagger);
            newHero.SetArmor(leather);

            double expeted = Math.Round(2.12, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Rogue_DisplayInfo_ShouldReturnInfo()
        {
            //arrange 
            Rogue newHero = new Rogue("Dan");
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
