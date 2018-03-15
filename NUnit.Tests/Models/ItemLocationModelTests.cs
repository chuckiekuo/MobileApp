using NUnit.Framework;
using Game.Models;
using System.Linq;
using System;

namespace NUnit.Tests
{
    [TestFixture]
    public class ItemLocationTests
    {
        [Test]
        public void Model_ItemLocationList_GetListCharacter_Should_Pass()
        {
            // Instantiate a new ItemLocation Base, should have default of 1 for all values
            var myDataList = ItemLocationList.GetListCharacter;

            // Get Expected set
            var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();
            var myExpectedList  = myList.Where(a =>
                                           a.ToString() != ItemLocationEnum.Unknown.ToString() &&
                                            a.ToString() != ItemLocationEnum.Finger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();

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
        public void Model_ItemLocationList_GetListItem_Should_Pass()
        {
            // Instantiate a new ItemLocation Base, should have default of 1 for all values
            var myDataList = ItemLocationList.GetListItem;

            // Get Expected set
            var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                            a.ToString() != ItemLocationEnum.Unknown.ToString() &&
                                            a.ToString() != ItemLocationEnum.LeftFinger.ToString() &&
                                            a.ToString() != ItemLocationEnum.RightFinger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();

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
        public void Model_ItemLocationList_ConvertStringToEnum_Should_Pass()
        {
            var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();

            ItemLocationEnum myActual;
            ItemLocationEnum myExpected;

            foreach (var item in myList)
            {
                myActual = ItemLocationList.ConvertStringToEnum(item);
                myExpected = (ItemLocationEnum)Enum.Parse(typeof(ItemLocationEnum), item);

                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }
    }
}
