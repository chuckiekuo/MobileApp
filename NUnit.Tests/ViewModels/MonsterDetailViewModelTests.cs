using NUnit.Framework;
using NUnit.Tests.Models.Default;

using Game.ViewModels;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class MonsterDetailViewModelTests
    {
        [Test]
        public void ViewModel_MonstersViewModel_Instantiate_Should_Pass()
        {
            var Actual = new MonsterDetailViewModel();

            Assert.AreEqual(null, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_MonstersViewModel_Instantiate_With_Data_Should_Pass()
        {
            var myData = DefaultModels.MonsterDefault();

            var value = "hi";
            myData.Name = value;
            var Actual = new MonsterDetailViewModel(myData);

            Assert.AreEqual(value, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_MonstersViewModel_GetData_With_Data_Should_Pass()
        {
            var myData = DefaultModels.MonsterDefault();

            var value = "hi";
            myData.Name = value;
            var myViewModel = new MonsterDetailViewModel(myData);

            var Actual = myViewModel.Data;
            var Expected = myData;

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
        }
    }
}