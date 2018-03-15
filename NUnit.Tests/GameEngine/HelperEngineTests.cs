using NUnit.Framework;

using Game.GameEngine;
using Game.Models;

namespace NUnit.Tests.GameEngine
{
    [TestFixture]
    public class HelperEngineTests
    {
        [Test]
        public void GameEngine_Helper_Random_For_UnitTests_Roll1_Dice6_Should_Have_Known_Values()
        {

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            // 1 roll of dice value of 1 = 1
            var Expected = 1;
            var Actual = HelperEngine.RollDice(1, 6);

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void GameEngine_Helper_Random_For_UnitTests_Roll6_Dice4_Should_Have_Known_Values()
        {

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            // 6 roll of dice value of 1 = 1
            var Expected = 6;
            var Actual = HelperEngine.RollDice(6, 4);

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void GameEngine_Helper_Random_For_UnitTests_Roll0_Dice10_Should_Have_Known_Values()
        {

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Expected = 0;
            var Actual = HelperEngine.RollDice(0, 10);

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void GameEngine_Helper_Random_For_UnitTests_RollNeg_Dice10_Should_Have_Known_Values()
        {

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);


            var Expected = 0;
            var Actual = HelperEngine.RollDice(-1, 10);

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void GameEngine_Helper_Random_For_UnitTests_Roll1_Dice0_Should_Have_Known_Values()
        {

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Expected = 0;
            var Actual = HelperEngine.RollDice(1, 0);

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void GameEngine_Helper_Random_For_UnitTests_Roll1_DiceNeg_Should_Have_Known_Values()
        {

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Expected = 0;
            var Actual = HelperEngine.RollDice(1, -1);

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void GameEngine_Helper_Random_For_Dice_Should_Have_Known_Range()
        {
            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var ExpectedMin = 6;
            var ExpectedMax = 6*18;

            var Actual = HelperEngine.RollDice(6, 6);

            // Reset
            GameGlobals.ToggleRandomState();


            Assert.GreaterOrEqual(Actual, ExpectedMin, "Min " + TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, ExpectedMax, "Max " + TestContext.CurrentContext.Test.Name);
        }

    }
}
