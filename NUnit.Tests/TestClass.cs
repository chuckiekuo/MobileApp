using NUnit.Framework;
using Xamarin.Forms.Mocks;
using Game;

namespace NUnit.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameTests_UnitTest_Running()
        {
            Assert.AreEqual(true,true, "Unit Test Running");
        }

        [Test]
        public void App_Instantiate_Should_Pass()
        {
            MockForms.Init();

            var Actual = new Game.App();

            Assert.AreEqual(true, true, "Unit Test Running");
        }
    }
}
