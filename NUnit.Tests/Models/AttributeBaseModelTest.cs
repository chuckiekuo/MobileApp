using NUnit.Framework;
using Game.Models;
using Newtonsoft.Json;

namespace NUnit.Tests
{
    [TestFixture]
    public class AttributeBaseModelTests
    {
        [Test]
        public void Model_AttributeBase_Instantiate_Should_Pass()
        {
            // Instantiate a new Attribute Base, should have default of 1 for all values
            var myData = new AttributeBase();

            Assert.AreEqual(myData.Speed, 1, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Defense, 1, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attack, 1, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.CurrentHealth, 1, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.MaxHealth, 1, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_AttributeBase_Instantiate_FromString_Should_Pass()
        {

            // Instantiate a new Attribute Base, should have default of 1 for all values
            var myDataBase = new AttributeBase();

            // Convert it to a string
            var myAttributesString = JsonConvert.SerializeObject(myDataBase);

            // Pass that in as the constructor
            var myData = new AttributeBase(myAttributesString);

            Assert.AreEqual(myDataBase.Speed, myData.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataBase.Defense,myData.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataBase.Attack, myData.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataBase.CurrentHealth,myData.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataBase.MaxHealth, myData.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_AttributeBase_Instantiate_FromString_Empty_Should_Skip()
        {

            // Pass that in as the constructor
            var myData = new AttributeBase(null);

            Assert.AreEqual(1, myData.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myData.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myData.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myData.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myData.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_AttributeBase_GetAttributeFromString_With_Null_Should_Skip()
        {

            // Pass that in as the constructor
            var myData = new AttributeBase(null);
            string myString = null;

            var myResult = AttributeBase.GetAttributeFromString(myString);

            Assert.AreEqual(1, myResult.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_AttributeBase_GetAttributeFromString_With_Bad_String_Should_Skip()
        {

            // Pass that in as the constructor
            var myData = new AttributeBase(null);
            string myString = "Abc";

            var myResult = AttributeBase.GetAttributeFromString(myString);

            Assert.AreEqual(1, myResult.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(1, myResult.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }


        [Test]
        public void Model_AttributeBase_GetAttributeFromString_With_Valid_String_Should_Pass()
        {

            var myDataBase = new AttributeBase();
            var Value = 10;
            myDataBase.Speed = Value;
            myDataBase.Attack = Value;
            myDataBase.Defense = Value;
            myDataBase.CurrentHealth= Value;
            myDataBase.MaxHealth = Value;

            // Convert it to a string
            var myString = JsonConvert.SerializeObject(myDataBase);

            var myResult = AttributeBase.GetAttributeFromString(myString);

            Assert.AreEqual(Value, myResult.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Value, myResult.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Value, myResult.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Value, myResult.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Value, myResult.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }
    }
}
