using rpg_heros_c.Heros;

namespace rpg_heros_test.HerosTests
{
    public class MageTest
    {

        // MAGE - Class Im testing
        //  - what im testing 
        // - what it shoud return 


        // creation 
        [Fact]
        public void Mage_NameAfterCreation_ShoudReturnName()
        {
            //arrange & act
            Mage newHero = new Mage("Dan");

            //assert
            Assert.Equal("Dan", newHero.Name);
        }

        [Fact]
        public void Mage_LevelAfterCreation_ShoudReturnOne()
        {
            Mage newHero = new Mage("Dan");

            //assert
            Assert.Equal(1, newHero.Level);
        }

        [Fact]
        public void Mage_StengthAfterCreation_ShoudRetunOne()
        {
            //arrange & act
            Mage newHero = new Mage("Dan");

            //assert
            Assert.Equal(1, newHero.Attributes.Strength);
        }

        [Fact]
        public void Mage_DexterityAfterCreation_ShoudRetunOne()
        {
            //arrange & act
            Mage newHero = new Mage("Dan");

            //assert
            Assert.Equal(1, newHero.Attributes.Dexterity);
        }

        [Fact]
        public void Mage_IntelligenceAfterCreation_ShoudRetunEight()
        {
            //arrange & act
            Mage newHero = new Mage("Dan");

            //assert
            Assert.Equal(8, newHero.Attributes.Intelligence);
        }

        // Level up 
        [Fact]
        public void Mage_LevelAfterLevelUp_ShoudRetunTwo()
        {
            //arrange 
            Mage newHero = new Mage("Dan");

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(2, newHero.Level);
        }

        [Fact]
        public void Mage_StrengthAfterLevelUp_ShoudRetunTwo()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            int strength = newHero.Attributes.Strength + 1;

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(strength, newHero.Attributes.Strength);
        }

        [Fact]
        public void Mage_DexterityAfterLevelUp_ShoudRetunTwo()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            int dexterity = newHero.Attributes.Dexterity + 1;

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(dexterity, newHero.Attributes.Dexterity);
        }

        [Fact]
        public void Mage_IntelligenceAfterLevelUp_ShoudRetunThirteen()
        {
            //arrange 
            Mage newHero = new Mage("Dan");
            int Intelligence = newHero.Attributes.Intelligence + 5;

            // act
            newHero.LevelUp();

            //assert
            Assert.Equal(Intelligence, newHero.Attributes.Intelligence);
        }
    }
}