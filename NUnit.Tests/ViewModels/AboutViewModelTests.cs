using NUnit.Framework;
using NUnit.Tests.Models.Default;

using Game.ViewModels;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class AboutViewModelTests
    {
        [Test]
        public void ViewModel_AboutViewModel_Instantiate_Should_Pass()
        {
            var Actual = new AboutViewModel();

            Assert.AreEqual("About", Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        //[Test]
        //public void ViewModel_AboutViewModel_Instantiate_With_Data_Should_Pass()
        //{
        //    var myData = DefaultModels.AboutDefault();

        //    var value = "hi";
        //    myData.Name = value;
        //    var Actual = new AboutViewModel(myData);

        //    Assert.AreEqual(value, Actual.Title, TestContext.CurrentContext.Test.Name);
        //}

        //[Test]
        //public void ViewModel_AboutViewModel_GetData_With_Data_Should_Pass()
        //{
        //    var myData = DefaultModels.AboutDefault();

        //    var value = "hi";
        //    myData.Name = value;
        //    var myViewModel = new AboutViewModel(myData);

        //    var Actual = myViewModel.Data;
        //    var Expected = myData;

        //    Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
        //}
    }
}