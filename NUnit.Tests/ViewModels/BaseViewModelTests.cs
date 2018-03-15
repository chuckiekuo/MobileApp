using System;

using NUnit.Framework;
using NUnit.Tests.Models.Default;
using Xamarin.Forms.Mocks;
using System.Linq;

using Game.Controllers;
using Game.Models;
using Game.GameEngine;
using Game.ViewModels;
using Game.Services;
using Game.Views;

using Xamarin.Forms;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using System.ComponentModel;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class BaseViewModelTests
    {
        [Test]
        public void ViewModel_BaseViewModel_Instantiate_Should_Pass()
        {
            MockForms.Init();

            var Actual = new BaseViewModel();

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(string.Empty, Actual.Title, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ViewModel_BaseViewModel_OnPropertyChange_Should_Pass()
        {
            MockForms.Init();

            var viewModel = new CharactersViewModel();

            NotifyPropertyChangedTester tester = new NotifyPropertyChangedTester(viewModel);

            Assert.AreEqual(0, tester.Changes.Count, "First " + TestContext.CurrentContext.Test.Name);

            viewModel.Title = "Title";

            Assert.AreEqual(1, tester.Changes.Count, "Second " + TestContext.CurrentContext.Test.Name);

            tester.AssertChange(0, "Title");
        }
    }

    public class NotifyPropertyChangedTester
    {
        public NotifyPropertyChangedTester(INotifyPropertyChanged viewModel)
        {
            //if (viewModel == null)
            //{
            //    throw new ArgumentNullException("viewModel", "Argument cannot be null.");
            //}

            this.Changes = new List<string>();

            viewModel.PropertyChanged += new PropertyChangedEventHandler(viewModel_PropertyChanged);
        }

        void viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Changes.Add(e.PropertyName);
        }

        public List<string> Changes { get; private set; }

        public void AssertChange(int changeIndex, string expectedPropertyName)
        {
            Assert.IsNotNull(Changes, "Changes collection was null.");

            Assert.IsTrue(changeIndex < Changes.Count,
                    "Changes collection contains ‘{ 0}’ items and does not have an element at index ‘{ 1}’.",
                    Changes.Count,
                    changeIndex);

            Assert.AreEqual(expectedPropertyName,
                                Changes[changeIndex],
                                "Change at index ‘{ 0}’ is ‘{ 1}’ and is not equal to ‘{ 2}’.",
                                changeIndex,
                                Changes[changeIndex],
                                expectedPropertyName
                                );
        }
    }


}