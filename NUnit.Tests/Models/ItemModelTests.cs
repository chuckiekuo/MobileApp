using NUnit.Framework;
using Game.Models;
using NUnit.Tests.Models.Default;
using Xamarin.Forms.Mocks;
using Game.GameEngine;
using System.Linq;
using System;

namespace NUnit.Tests
{
    [TestFixture]
    public class ItemTests
    {
        #region NewItem
        [Test]
        public void Model_Item_Instantiate_Should_Pass()
        {

            // Walk all the Attributes and Locations and make an Item for each one
            // Verify the properties.

            Item myData;

            foreach (var attribute in AttributeList.GetListItem)
            {
                var attributeEnum = AttributeList.ConvertStringToEnum(attribute);

                foreach (var location in ItemLocationList.GetListItem)
                {
                    var locationEnum = ItemLocationList.ConvertStringToEnum(location);

                    myData = DefaultModels.ItemDefault(locationEnum, attributeEnum);


                    Assert.AreEqual(locationEnum, myData.Location, "location: " + location + " " + TestContext.CurrentContext.Test.Name);
                    Assert.AreEqual(attributeEnum, myData.Attribute, "attribute: " + attribute + " " + TestContext.CurrentContext.Test.Name);

                    Assert.AreEqual(1, myData.Value, "value " + TestContext.CurrentContext.Test.Name);
                    Assert.AreEqual(1, myData.Damage, "damage " + TestContext.CurrentContext.Test.Name);
                    Assert.AreEqual(1, myData.Range, "range " + TestContext.CurrentContext.Test.Name);


                    Assert.AreEqual("Item for " + location, myData.Name, "Name " + TestContext.CurrentContext.Test.Name);
                    Assert.AreEqual("Auto Created", myData.Description, "Description " + TestContext.CurrentContext.Test.Name);
                    Assert.AreEqual(null, myData.ImageURI, "range " + TestContext.CurrentContext.Test.Name);
                }
            }
        }

        #endregion NewItem

        #region Output
        [Test]
        public void Model_Item_FormatOutput_DefaultItem_Should_Pass()
        {
            Item myData;

            foreach (var attribute in AttributeList.GetListItem)
            {
                var attributeEnum = AttributeList.ConvertStringToEnum(attribute);

                foreach (var location in ItemLocationList.GetListItem)
                {
                    var locationEnum = ItemLocationList.ConvertStringToEnum(location);

                    myData = DefaultModels.ItemDefault(locationEnum, attributeEnum);

                    // "Item for Feet , Auto Created for Feet with Speed+1 , Damage : 1 , Range : 1"

                    var Expected = "Item for " + location + " , Auto Created for " + location + " with " + attribute + "+" + myData.Value + " , Damage : " + myData.Damage + " , Range : " + myData.Range;

                    var Actual = myData.FormatOutput();

                    Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
                }
            }
        }

        [Test]
        public void Model_Item_FormatOutput_Name_WithSpace_Should_Pass()
        {
            Item myData;

            foreach (var attribute in AttributeList.GetListItem)
            {
                var attributeEnum = AttributeList.ConvertStringToEnum(attribute);

                foreach (var location in ItemLocationList.GetListItem)
                {
                    var locationEnum = ItemLocationList.ConvertStringToEnum(location);

                    myData = DefaultModels.ItemDefault(locationEnum, attributeEnum);

                    // Add leading space to name, to test the trim...
                    myData.Name = " " + myData.Name;

                    var Expected = "Item for " + location + " , Auto Created for " + location + " with " + attribute + "+" + myData.Value + " , Damage : " + myData.Damage + " , Range : " + myData.Range;

                    var Actual = myData.FormatOutput();

                    Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
                }
            }
        }
        #endregion Output

        #region Update

        [Test]
        public void Model_Item_Update_With_Null_Should_Skip()
        {
            var Actual = DefaultModels.ItemDefault(ItemLocationEnum.Feet, AttributeEnum.Attack);
            var Expected = DefaultModels.ItemDefault(ItemLocationEnum.Feet, AttributeEnum.Attack);

            var myActualId = Actual.Id;

            Actual.Update(null);

            // Should not change with update...
            Assert.AreEqual(Actual.Id, myActualId, "Id " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Actual.Guid, Actual.Id, "Guid " + TestContext.CurrentContext.Test.Name);

            // Rest should match default for same request
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, "Attribute " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, "Damage " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.ImageURI, Actual.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Location, Actual.Location, "Location " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Name, Actual.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Range, Actual.Range, "Range " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, "Value " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Item_Update_With_Change_Should_Pass()
        {
            var Actual = DefaultModels.ItemDefault(ItemLocationEnum.Feet, AttributeEnum.Attack);
            var myActualId = Actual.Id;

            var Expected = DefaultModels.ItemDefault(ItemLocationEnum.Head, AttributeEnum.Speed);
            Expected.ImageURI = "new uri";
            Expected.Name = "new name";
            Expected.Description = "new description";
            Expected.Range = 11;
            Expected.Value = 22;
            Expected.Damage = 33;

            Actual.Update(Expected);

            // Should not change with update...
            Assert.AreEqual(Actual.Id, myActualId, "Id " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Actual.Guid, Actual.Id, "Guid " + TestContext.CurrentContext.Test.Name);

            // Rest should match default for same request
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, "Attribute " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, "Damage " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.ImageURI, Actual.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Location, Actual.Location, "Location " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Name, Actual.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Range, Actual.Range, "Range " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, "Value " + TestContext.CurrentContext.Test.Name);
        }

        #endregion Update

        #region CreateItem
        [Test]
        public void Model_Item_Create_With_Values_Should_Pass()
        {
            var Expected = DefaultModels.ItemDefault(ItemLocationEnum.Head, AttributeEnum.Speed);
            Expected.ImageURI = "new uri";
            Expected.Name = "new name";
            Expected.Description = "new description";
            Expected.Range = 11;
            Expected.Value = 22;
            Expected.Damage = 33;

            var Actual = new Item(
                                    Expected.Name,
                                    Expected.Description,
                                    Expected.ImageURI,
                                    Expected.Range,
                                    Expected.Value,
                                    Expected.Damage,
                                    Expected.Location,
                                    Expected.Attribute
                                );

            // The ID of the new item, should be unique
            Assert.AreNotEqual(Expected.Id, Actual.Id, "Id " + TestContext.CurrentContext.Test.Name);

            // The guid of the new item should match the ID of the new item.
            Assert.AreEqual(Expected.Guid, Expected.Id, "Guid " + TestContext.CurrentContext.Test.Name);

            // Rest should match default for same request
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, "Attribute " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, "Damage " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.ImageURI, Actual.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Location, Actual.Location, "Location " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Name, Actual.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Range, Actual.Range, "Range " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, "Value " + TestContext.CurrentContext.Test.Name);
        }

        #endregion CreateItem

        #region ScaleLevel

        [Test]
        public void Model_Item_ScaleLevel_With_Values_Should_Pass()
        {
            MockForms.Init();

            var myItem = new Item();
            myItem.Value = 0;
            myItem.ScaleLevel(2);

            var Actual = myItem.Value;

            // Should roll for 1 item, and return it...
            var Expected = 0;

            Assert.AreNotEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Item_ScaleLevel_With_NoRandom_Values_Should_Pass()
        {
            MockForms.Init();

            // Turn off random numbers
            // Set random to 1, and to hit to 1
            GameGlobals.SetForcedRandomNumbers(3, 1);

            var myItem = new Item();
            myItem.ScaleLevel(2);

            var Actual = myItem.Value;

            // Should roll for 1 item, and return it...
            var Expected = 2;

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        #endregion ScaleLevel
    }
}