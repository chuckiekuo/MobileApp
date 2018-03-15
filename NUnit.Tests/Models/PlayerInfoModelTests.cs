using NUnit.Framework;
using Game.Models;

namespace NUnit.Tests
{
    [TestFixture]
    public class PlayerInfoModelTests
    {
        [Test]
        public void Model_PlayerInfo_Instantiate_Should_Pass()
        {
            var myData = new PlayerInfo();

            Assert.AreNotEqual(null, myData, TestContext.CurrentContext.Test.Name);
        }
    }
}