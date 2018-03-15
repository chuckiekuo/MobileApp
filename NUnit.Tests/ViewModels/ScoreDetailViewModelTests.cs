using NUnit.Framework;
using NUnit.Tests.Models.Default;

using Game.ViewModels;
using Xamarin.Forms.Mocks;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class ScoreDetailViewModelTests
    {
        [Test]
        public void ViewModel_ScoreViewModel_Instantiate_Should_Pass()
        {
            MockForms.Init();

            var Actual = new ScoreDetailViewModel();

            Assert.AreEqual(null, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_ScoreViewModel_Instantiate_With_Data_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.ScoreDefault();

            var value = "hi";
            myData.Name = value;
            var Actual = new ScoreDetailViewModel(myData);

            Assert.AreEqual(value, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_ScoreViewModel_GetData_With_Data_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.ScoreDefault();

            var value = "hi";
            myData.Name = value;
            var myViewModel = new ScoreDetailViewModel(myData);

            var Actual = myViewModel.Data;
            var Expected = myData;

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
        }
    }
}