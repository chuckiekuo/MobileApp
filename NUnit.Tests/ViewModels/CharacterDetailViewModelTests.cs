using NUnit.Framework;
using NUnit.Tests.Models.Default;

using Game.ViewModels;
using Xamarin.Forms.Mocks;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class CharacterDetailViewModelTests
    {
        [Test]
        public void ViewModel_CharactersViewModel_Instantiate_Should_Pass()
        {
            MockForms.Init();

            var Actual = new CharacterDetailViewModel();

            Assert.AreEqual(null, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_CharactersViewModel_Instantiate_With_Data_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.CharacterDefault();

            var value = "hi";
            myData.Name = value;
            var Actual = new CharacterDetailViewModel(myData);

            Assert.AreEqual(value, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_CharactersViewModel_GetData_With_Data_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.CharacterDefault();

            var value = "hi";
            myData.Name = value;
            var myViewModel = new CharacterDetailViewModel(myData);

            var Actual = myViewModel.Data;
            var Expected = myData;

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
        }
    }
}