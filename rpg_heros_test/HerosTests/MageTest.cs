using rpg_heros_c.enums;
using rpg_heros_c.equipment;
using rpg_heros_c.exceptions;
using rpg_heros_c.Heros;
using System.Text;

namespace rpg_heros_test.HerosTests
{
    public class MageTest
    {
        // creation 
        [Fact]
        public void Mage_NameAfterCreation_ShouldReturnName()
        {
            //arrange & act
            Mage newHero = new Mage("Dan");

            //assert
            Assert.Equal("Dan", newHero.Name);
        }

        [Fact]
        public void Mage_LevelAfterCreation_ShouldReturnOne()
        {
            Mage newHero = new Mage("Dan");

            //assert
            Assert.Equal(1, newHero.Level);
        }

        [Fact] 
        public void Mage_AttributesAfterCreation_ShouldReturnAttributes()
        {
            //arrange & act 
            Mage newHero = new Mage("Dan");

            // assert
            Assert.True(
                newHero.Attributes.Strength == 1 && 
                newHero.Attributes.Dexterity == 1 && 
                newHero.Attributes.Intelligence == 8);
        }

        // Level up 
        [Fact]
        public void Mage_LevelAfterLevelUp_ShouldRetunTwo()
        {
            //arrange 
            Mage newHero = new Mage("Dan");

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(2, newHero.Level);
        }

        [Fact] 
        public void Mage_AttributesAfterLevelUp_ShouldReturnAttributes()
        {
            // arrange
            Mage newHero = new Mage("Dan");
            int levelUpStrength = 1 + 1;
            int levelUpDexterity = 1 + 1;
            int levelUpIntelligence = 8 + 5;

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
        public void Mage_equipValidWeaponType_ShouldReturnTypeOfWeaponInSlot()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Weapon commonWand = new("Common Wand", WeaponType.Wands, 2, 1);

            //act 
            newHero.SetWeapon(commonWand);

            //assert
            Assert.Equal(WeaponType.Wands, newHero.WeaponSlots.type);
        }

        [Fact]
        public void Mage_equipValidWeaponLevel_ShouldReturnWeaponLevel()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Weapon commonWand = new("Common Wand", WeaponType.Wands, 2, 1);

            //act 
            newHero.SetWeapon(commonWand);

            //assert
            Assert.Equal(commonWand.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Mage_equipInvalidWeaponLevel_ShouldThrowException()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Weapon Wand = new("Wand", WeaponType.Wands, 2, 2);

            //act 
           
            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(Wand));
        }

        [Fact]
        public void Mage_equipInvalidWeaponType_ShouldThrowException()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);

            //act 

            //assert
            Assert.Throws<InvalidWeaponException>(() => newHero.SetWeapon(commonAxe));
        }

        // armor equip 
        [Fact]
        public void Mage_equipValidArmorType_ShouldReturnTypeOfArmorInSlot()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Armor cloth = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 1, 0, 1, 2);


            //act 
            newHero.SetArmor(cloth);

            //assert
            Assert.Equal(ArmorType.Cloth, newHero.ArmorSlots[cloth.equipmentSlot].armorType);
        }

        [Fact]
        public void Mage_equipValidArmorLevel_ShouldReturnArmorLevel()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Armor cloth = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 1, 0, 1, 2);


            //act 
            newHero.SetArmor(cloth);

            //assert
            Assert.Equal(cloth.RequiredLevel, newHero.Level);
        }

        [Fact]
        public void Mage_equipInvalidArmorLevel_ShouldThrowException()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Armor cloth = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 2, 0, 1, 2);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(cloth));
        }

        [Fact]
        public void Mage_equipInvalidArmorType_ShouldThrowException()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0, 0);

            //act 

            //assert
            Assert.Throws<InvalidArmorException>(() => newHero.SetArmor(plate));
        }

        // attributes 
        [Fact]
        public void Mage_TotalAttributeNoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Mage newHero = new Mage("Dan");

            int totalStrength = 1;
            int totalDexterity = 1;
            int totalIntelligence = 8;

            //act 
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(
                total.Strength == totalStrength && 
                total.Dexterity == totalDexterity && 
                total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Mage_TotalAttributeOneArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Armor cloth = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 1, 1, 0, 2);

            int totalStrength = 1 + 1;
            int totalDexterity = 1 + 0;
            int totalIntelligence = 8 + 2;

            //act 
            newHero.SetArmor(cloth);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(
                total.Strength == totalStrength &&
                total.Dexterity == totalDexterity &&
                total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Mage_TotalAttributeTwoArmor_ShouldReturnTotalAttributes()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Armor cape = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 1, 1, 0, 2);
            Armor hat = new Armor("Common mage hat", EquipmentSlots.Head, ArmorType.Cloth, 1, 0, 0, 3);

            int totalStrength = 1 + 1 + 0;
            int totalDexterity = 1 + 0 + 0;
            int totalIntelligence = 8 + 2 + 3;

            //act 
            newHero.SetArmor(cape);
            newHero.SetArmor(hat);
            var total = newHero.TotalAttributes();

            //assert
            Assert.True(total.Strength == totalStrength && total.Dexterity == totalDexterity && total.Intelligence == totalIntelligence);
        }

        [Fact]
        public void Mage_TotalAttributeTwoArmorWithReplaced_ShouldReturnTotalAttributes()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Armor cape = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 1, 1, 0, 2);
            Armor hat = new Armor("Common mage hat", EquipmentSlots.Head, ArmorType.Cloth, 1, 0, 0, 3);
            Armor niceHat = new Armor("Common mage hat for party's", EquipmentSlots.Head, ArmorType.Cloth, 1, 1, 2, 3);

            int totalStrength = 1 + 1 + 1;
            int totalDexterity = 1 + 0 + 2;
            int totalIntelligence = 8 + 2 + 3;

            //act 
            newHero.SetArmor(cape);
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
        public void Mage_TotalDamagesNoEquipment_ShouldReturnTotalDamages()
        {
            //arrange 
            Mage newHero = new Mage("Dan");

            //act 
         
            double expeted = Math.Round(1.08, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Mage_TotalDamagesWithWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Weapon commonWand = new("Common Wand", WeaponType.Wands, 2, 1);
            

            //act 
            newHero.SetWeapon(commonWand);
            
            double expeted = Math.Round(2.16, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Mage_TotalDamagesWithReplacedWeapon_ShouldReturnTotalDamages()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Weapon commonWand = new("Common Wand", WeaponType.Wands, 2, 1);
            Weapon fineWand = new("Fine Wand", WeaponType.Wands, 3, 1);

            //act 
            newHero.SetWeapon(commonWand);
            newHero.SetWeapon(fineWand);

            double expeted = Math.Round(3.24, 2);

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Mage_TotalDamagesWithWeaponAndArmor_ShouldReturnTotalDamages()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            Weapon commonWand = new("Common Wand", WeaponType.Wands, 2, 1);
            Armor cloth = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 1, 0, 1, 2);

            //act 
            newHero.SetWeapon(commonWand);
            newHero.SetArmor(cloth);

            double expeted = 2.2;

            //assert
            Assert.Equal(expeted, newHero.DamageCount());

        }

        [Fact]
        public void Mage_DisplayInfo_ShouldReturnInfo()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
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