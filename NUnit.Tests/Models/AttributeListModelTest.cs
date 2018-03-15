using NUnit.Framework;
using Game.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace NUnit.Tests
{
    [TestFixture]
    public class AttributeListModelTests
    {
        [Test]
        public void Model_AttributeList_GetListCharacter_Should_Pass()
        {
            // Instantiate a new Attribute Base, should have default of 1 for all values
            var myDataList = AttributeList.GetListCharacter;

            // Get Expected set
            var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                            a.ToString() != AttributeEnum.Unknown.ToString()
                                        ).ToList();

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
                var found = false;
                foreach (var expected in myExpectedList)
                {
                    if (item == expected)
                    {
                        found = true;
                        break;
                    }
                }
                Assert.AreEqual(true, found, "item : " + item + TestContext.CurrentContext.Test.Name);
            }

            // reverse it, to make sure the list has each item
            // Make sure each item is in the list
            foreach (var expected in myExpectedList)
            {
                var found = false;
                {
                    foreach (var item in myDataList)
                        if (item == expected)
                        {
                            found = true;
                            break;
                        }
                }
                Assert.AreEqual(true, found, "expected : " + expected + TestContext.CurrentContext.Test.Name);
            }

        }

        [Test]
        public void Model_AttributeList_GetListItem_Should_Pass()
        {
            // Instantiate a new Attribute Base, should have default of 1 for all values
            var myDataList = AttributeList.GetListItem;

            // Get Expected set
            var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                                a.ToString() != AttributeEnum.Unknown.ToString() &&
                                                a.ToString() != AttributeEnum.MaxHealth.ToString()
                                            ).ToList();

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
                var found = false;
                foreach (var expected in myExpectedList)
                {
                    if (item == expected)
                    {
                        found = true;
                        break;
                    }
                }
                Assert.AreEqual(true, found, "item : " + item + TestContext.CurrentContext.Test.Name);
            }

            // reverse it, to make sure the list has each item
            // Make sure each item is in the list
            foreach (var expected in myExpectedList)
            {
                var found = false;
                {
                    foreach (var item in myDataList)
                        if (item == expected)
                        {
                            found = true;
                            break;
                        }
                }
                Assert.AreEqual(true, found, "expected : " + expected + TestContext.CurrentContext.Test.Name);
            }

        }

        [Test]
        public void Model_AttributeList_ConvertStringToEnum_Should_Pass()
        {
            var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();

            AttributeEnum myActual;
            AttributeEnum myExpected;

            foreach (var item in myList)
            {
                myActual = AttributeList.ConvertStringToEnum(item);
                myExpected = (AttributeEnum)Enum.Parse(typeof(AttributeEnum), item);

                Assert.AreEqual(myExpected,myActual, "string: "+item+ TestContext.CurrentContext.Test.Name);
            }
        }
    }
}

