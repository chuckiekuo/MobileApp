using NUnit.Framework;
using NUnit.Tests.Models.Default;

using Game.ViewModels;
using Xamarin.Forms.Mocks;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class ItemDetailViewModelTests
    {
        [Test]
        public void ViewModel_ItemsViewModel_Instantiate_Should_Pass()
        {
            MockForms.Init();

            var Actual = new ItemDetailViewModel();

            Assert.AreEqual(null, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_ItemsViewModel_Instantiate_With_Data_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.ItemDefault(Game.Models.ItemLocationEnum.Feet, Game.Models.AttributeEnum.Attack);

            var value = "hi";
            myData.Name = value;
            var Actual = new ItemDetailViewModel(myData);

            Assert.AreEqual(value, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_ItemsViewModel_GetData_With_Data_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.ItemDefault(Game.Models.ItemLocationEnum.Feet, Game.Models.AttributeEnum.Attack);

            var value = "hi";
            myData.Name = value;
            var myViewModel = new ItemDetailViewModel(myData);

            var Actual = myViewModel.Data;
            var Expected = myData;

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
        }
    }
}