using System;
using NUnit.Framework;
using NUnit.Tests.Models.Default;
using Xamarin.Forms.Mocks;
using System.Linq;

using Game.Models;
using Game.GameEngine;
using Game.ViewModels;
using Game.Services;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class ConverterTests
    {
        [Test]
        public void Model_Converter_IntEnumConverter_Convert_Should_Skip()
        {
            var myConverter = new IntEnumConverter();

            var myObject = "Bogus";
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_IntEnumConverter_Convert_Should_Pass()
        {
            var myConverter = new IntEnumConverter();

            var myObject = ItemLocationEnum.Feet;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 40;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_StringEnumConverter_Convert_String_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            var myObject = "Feet";
            var Result = myConverter.Convert(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = ItemLocationEnum.Feet;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_StringEnumConverter_Convert_Enum_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            var myObject = ItemLocationEnum.Feet;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 40;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_StringEnumConverter_Convert_Other_Should_Skip()
        {
            var myConverter = new StringEnumConverter();

            var myObject = new Item();
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void Model_Converter_IntEnumConverter_ConvertBack_Should_Skip()
        {
            var myConverter = new IntEnumConverter();

            var myObject = "Bogus";
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void Model_Converter_IntEnumConverter_ConvertBack_Int_Should_Pass()
        {
            var myConverter = new IntEnumConverter();

            int myObject = 40;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = "Feet";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_StringEnumConverter_ConvertBack_String_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            var myObject = "Feet";
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = ItemLocationEnum.Feet;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_StringEnumConverter_ConvertBack_Enum_Should_Skip()
        {
            var myConverter = new StringEnumConverter();

            var myObject = ItemLocationEnum.Feet;
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_StringEnumConverter_ConvertBack_Other_Should_Skip()
        {
            var myConverter = new StringEnumConverter();

            var myObject = new Item();
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Converter_StringEnumConverter_ConvertBack_Int_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            int myObject = 40;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = "Feet";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}
