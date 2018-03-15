using NUnit.Framework;
using NUnit.Tests.Models.Default;
using Game.Models;
using Xamarin.Forms.Mocks;
using Game.ViewModels;
using Newtonsoft.Json.Linq;

namespace NUnit.Tests.Models
{
    [TestFixture]
    class MonsterModelTests
    {

        [Test]
        public void Model_Monster_Instantiate_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();

            // Set Monster to be the same as a default Monster

            // Base information
            myData.Name = myDataDefault.Name;
            myData.Description = myDataDefault.Description;
            myData.Level = myDataDefault.Level;
            myData.ExperienceTotal = myDataDefault.ExperienceTotal;
            myData.ImageURI = myDataDefault.ImageURI;
            myData.Alive = myDataDefault.Alive;

            // Populate the Attributes
            myData.AttributeString = myDataDefault.AttributeString;

            myData.Attribute.Speed = myDataDefault.Attribute.Speed;
            myData.Attribute.Defense = myDataDefault.Attribute.Defense;
            myData.Attribute.Attack = myDataDefault.Attribute.Attack;
            myData.Attribute.CurrentHealth = myDataDefault.Attribute.CurrentHealth;
            myData.Attribute.MaxHealth = myDataDefault.Attribute.MaxHealth;

            // Set the strings for the items
            myData.Head = null;
            myData.Feet = null;
            myData.Necklass = null;
            myData.RightFinger = null;
            myData.LeftFinger = null;
            myData.Feet = null;

            // Compare Monster to what is expected.
            Assert.AreEqual(myData.Alive, myDataDefault.Alive, "Alive " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Name, myDataDefault.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Description, myDataDefault.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Level, myDataDefault.Level, "Level " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ExperienceTotal, myDataDefault.ExperienceTotal, "ExperienceTotal " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ImageURI, myDataDefault.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Head, myDataDefault.Head, "Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataDefault.Feet, "Feet " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Necklass, myDataDefault.Necklass, "Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.RightFinger, myDataDefault.RightFinger, "RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.LeftFinger, myDataDefault.LeftFinger, "LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataDefault.Feet, "Feet " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Damage, myDataDefault.Damage, "Damage " + TestContext.CurrentContext.Test.Name);

            // Validate the Attributes
            Assert.AreEqual(myData.AttributeString, myDataDefault.AttributeString, "AttributeString " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Attribute.Speed, myDataDefault.Attribute.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Defense, myDataDefault.Attribute.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Attack, myDataDefault.Attribute.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.CurrentHealth, myDataDefault.Attribute.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.MaxHealth, myDataDefault.Attribute.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_CalculateExperienceEarned_0_Should_Skip()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.ExperienceRemaining = 3000;
            myDataDefault.Attribute.MaxHealth = 20;
            myDataDefault.Attribute.CurrentHealth = 20;

            // Call calculate experience before applying damage
            var Result = myDataDefault.CalculateExperienceEarned(0);

            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_CalculateExperienceEarned_3_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.ExperienceRemaining = 3000;  
            myDataDefault.Attribute.MaxHealth = 20;
            myDataDefault.Attribute.CurrentHealth = 20;

            // Call calculate experience before applying damage
            var Result = myDataDefault.CalculateExperienceEarned(3);

            var Expected = 450;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_CalculateExperienceEarned_None_Avaiable_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.ExperienceRemaining = 0;  // 0 point remaining
            myDataDefault.Attribute.MaxHealth = 20;
            myDataDefault.Attribute.CurrentHealth = 20;

            // Call calculate experience before applying damage
            var Result = myDataDefault.CalculateExperienceEarned(3);

            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_CalculateExperienceEarned_Remaining_Should_Pass()
        {
            //      CalculateExperienceEarned(int)  11	100.00%	0	0.00%
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.ExperienceRemaining = 1;  // 1 point remaining
            myDataDefault.Attribute.MaxHealth = 20;
            myDataDefault.Attribute.CurrentHealth = 20;

            // Call calculate experience before applying damage
            var Result = myDataDefault.CalculateExperienceEarned(3);

            var Expected = 1;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetAttack_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();

            var Result = myDataDefault.GetAttack();
            var Expected = 1;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetDamage_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();

            var Result = myDataDefault.GetDamage();
            var Expected = 2; // 1 for level, and 1 for base damage

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetDefense_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();

            var Result = myDataDefault.GetDefense();
            var Expected = 1;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetHealthCurrent_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();

            var Result = myDataDefault.GetHealthCurrent();
            var Expected = 1;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetHealthMax_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();

            var Result = myDataDefault.GetHealthMax();
            var Expected = 1;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetSpeed_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();

            var Result = myDataDefault.GetSpeed();
            var Expected = 1;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_ExperienceRemaining_Get_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault(); // default is 3000

            
            var Result = myDataDefault.ExperienceRemaining;
            var Expected = 3000;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_ExperienceRemaining_Set_Valid_Should_Pass()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.ExperienceRemaining = 100;

            var Result = myDataDefault.ExperienceRemaining;
            var Expected = 100;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_DropAllItems_Null_Should_Skip()
        {
            MockForms.Init();

            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.UniqueItem = null;

            var Result = myDataDefault.DropAllItems();
            var Expected = 0;

            Assert.AreEqual(Expected, Result.Count, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_DropAllItems_With_Item_Should_Pass()
        {

            MockForms.Init();

            var myItem = new Item
            {
                Attribute = AttributeEnum.Attack,
                Location = ItemLocationEnum.Feet,
                Value = 1
            };

            ItemsViewModel.Instance.AddAsync(myItem).GetAwaiter().GetResult();  // Register Item to DataSet
            var myMonsterItem = ItemsViewModel.Instance.GetItem(myItem.Id);

            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.UniqueItem = myMonsterItem.Guid;

            var Result = myDataDefault.DropAllItems();
            var Expected = 1;

            Assert.AreEqual(Expected, Result.Count, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetUniqueItem_Null_Should_Skip()
        {
            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.UniqueItem = null;

            var Result = myDataDefault.GetUniqueItem();
            Item Expected = null;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_GetUniqueItem_Valid_Should_Pass()
        {
            MockForms.Init();

            var myItem = new Item
            {
                Attribute = AttributeEnum.Attack,
                Location = ItemLocationEnum.Feet,
                Value = 1
            };

            ItemsViewModel.Instance.AddAsync(myItem).GetAwaiter().GetResult();  // Register Item to DataSet
            var myMonsterItem = ItemsViewModel.Instance.GetItem(myItem.Id);

            var myData = new Monster();
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.UniqueItem = myMonsterItem.Guid;

            var Result = myDataDefault.GetUniqueItem();
            var Expected = myItem;

            // Guids should match up...
            Assert.AreEqual(Expected.Guid, Result.Guid, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_Monster_From_BaseMonster_Should_Pass()
        {
            var myBase = DefaultModels.BaseMonsterDefault();
            var Expected = new Monster(myBase);
            var Result = new Monster(myBase);

            // Check all Monster fields, that come from BaseMonster.
            Assert.AreEqual(Expected.Guid, Result.Guid, "Guid "+TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Result.Guid, Result.Id, " Guid match ID " +TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(Expected.Head, Result.Head, "Head " +TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Necklass, Result.Necklass, "Necklass " +TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.RightFinger, Result.RightFinger, "Right Finger " +TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.LeftFinger, Result.LeftFinger, "Left Finger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Feet, Result.Feet, "Feet " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(Expected.Damage, Result.Damage, "Damage " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(300, Result.ExperienceRemaining, "Experience Remaining "+TestContext.CurrentContext.Test.Name);

            // Check the Attributes
            var myAttributes = new AttributeBase
            {
                Attack = 1,
                Speed = 1,
                MaxHealth = 5,
                CurrentHealth = 5,
                Defense = 1
            };

            JObject myAttributesJson = (JObject)JToken.FromObject(myAttributes);
            var myAttibutesString = myAttributesJson.ToString();
            Assert.AreEqual(myAttibutesString, Result.AttributeString, "Attribute String" + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(Expected.Name, Result.Name, "Name " +TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Result.Description, "Description " +TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Level, Result.Level, "Level "+TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.ExperienceTotal, Result.ExperienceTotal, "Experience Total " +TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.ImageURI, Result.ImageURI, "Image " +TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_FormatOutput_DefaultMonster_Should_Pass()
        {
            MockForms.Init();
            var myData = DefaultModels.MonsterDefault();

            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Unique Item : None";

            var Actual = myData.FormatOutput();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_FormatOutput_With_Item_Should_Pass()
        {
            MockForms.Init();

            var myItem = new Item
            {
                Attribute = AttributeEnum.Attack,
                Location = ItemLocationEnum.Feet,
                Value = 1,
                Name = "Unique Item"
            };

            ItemsViewModel.Instance.AddAsync(myItem).GetAwaiter().GetResult();  // Register Item to DataSet
            var myMonsterItem = ItemsViewModel.Instance.GetItem(myItem.Id);

            var myData = DefaultModels.MonsterDefault();
            myData.UniqueItem = myMonsterItem.Guid;

            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Unique Item : Unique Item , Unknown for Feet with Attack+1 , Damage : 0 , Range : 0";
            var Actual = myData.FormatOutput();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_FormatOutput_With_Bogus_Item_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.MonsterDefault();
            myData.UniqueItem = "Bogus";

            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Unique Item : None";
            var Actual = myData.FormatOutput();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_Update_With_Bogus_Data_Should_Skip()
        {
            var myDataDefault = DefaultModels.MonsterDefault();
            var myData = new Monster();

            myData.Name = "Original Name";

            myData.Update(null);

            var Expected = "Original Name";
            var Actual = myData.Name;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_Update_With_Valid_Data_Should_Pass()
        {
            var myDataDefault = DefaultModels.MonsterDefault();
            var myData = new Monster();
            myData.Update(myDataDefault);

            // Validate the new Monster has the expected fields.
            // All fields should match.

            // The attirbute string is what is unique about creating from BaseMonster, and should be passed down...
            Assert.AreEqual(myData.ExperienceRemaining, myDataDefault.ExperienceRemaining, "ExperienceRemaining " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.UniqueItem, myDataDefault.UniqueItem, "UniqueItem " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Alive, myDataDefault.Alive, "Alive " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Name, myDataDefault.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Description, myDataDefault.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Level, myDataDefault.Level, "Level " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ExperienceTotal, myDataDefault.ExperienceTotal, "ExperienceTotal " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ImageURI, myDataDefault.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Head, myDataDefault.Head, "Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataDefault.Feet, "Feet " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Necklass, myDataDefault.Necklass, "Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.RightFinger, myDataDefault.RightFinger, "RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.LeftFinger, myDataDefault.LeftFinger, "LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataDefault.Feet, "Feet " + TestContext.CurrentContext.Test.Name);

            // Validate the Attributes
            Assert.AreEqual(myData.AttributeString, myDataDefault.AttributeString, "AttributeString " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Damage, myDataDefault.Damage, "Damage " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Attribute.Speed, myDataDefault.Attribute.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Defense, myDataDefault.Attribute.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Attack, myDataDefault.Attribute.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.CurrentHealth, myDataDefault.Attribute.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.MaxHealth, myDataDefault.Attribute.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_TakeDamage_With_MoreHealth__Should_Pass()
        {
            var health = 100;
            var myData = DefaultModels.MonsterDefault();
            myData.Attribute.CurrentHealth = health;
            myData.Attribute.MaxHealth = health;

            var value = 1;
            myData.TakeDamage(value);

            var Expected = health - value;
            var Actual = myData.GetHealthCurrent();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_TakeDamage_With_Zero_Should_Skip()
        {
            var health = 100;
            var myData = DefaultModels.MonsterDefault();
            myData.Attribute.CurrentHealth = health;
            myData.Attribute.MaxHealth = health;

            var value = 0;
            myData.TakeDamage(value);

            var Expected = health - value;
            var Actual = myData.GetHealthCurrent();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Monster_TakeDamage_With_Large_Damage_Should_Kill()
        {
            var health = 1;
            var myData = DefaultModels.MonsterDefault();
            myData.Attribute.CurrentHealth = health;
            myData.Attribute.MaxHealth = health;

            var value = 100;
            myData.TakeDamage(value);

            var Expected = 0;
            var Actual = myData.GetHealthCurrent();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(false, myData.Alive, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_BaseMonster_Update_With_Bogus_Data_Should_Skip()
        {
            var myDataDefault = DefaultModels.BaseMonsterDefault();
            var myData = new BaseMonster();

            myData.Name = "Original Name";

            myData.Update(null);

            var Expected = "Original Name";
            var Actual = myData.Name;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_BaseMonster_Instantiate_With_Valid_Data_Should_Pass()
        {
            var myDataDefault = DefaultModels.MonsterDefault();
            myDataDefault.Name = "Original Name";
            myDataDefault.UniqueItem ="UniqueItem";
            myDataDefault.Alive = false;
            myDataDefault.Description ="Description";
            myDataDefault.Level =6;
            myDataDefault.ExperienceTotal =  LevelTable.Instance.LevelDetailsList[myDataDefault.Level].Experience;
            myDataDefault.ImageURI ="ImageURI";
            myDataDefault.Head ="Head";
            myDataDefault.Feet ="Feet";
            myDataDefault.Necklass ="Necklass";
            myDataDefault.RightFinger ="RightFinger";
            myDataDefault.LeftFinger ="LeftFinger";
            myDataDefault.Feet ="Feet";
            myDataDefault.AttributeString ="AttributeString";
            myDataDefault.Damage =11;

            var myData = new BaseMonster(myDataDefault);

            Assert.AreEqual(myDataDefault.UniqueItem, myData.UniqueItem, "UniqueItem " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myDataDefault.Alive, myData.Alive, "Alive " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.Name, myData.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.Description, myData.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.Level, myData.Level, "Level " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.ExperienceTotal, myData.ExperienceTotal, "ExperienceTotal " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.ImageURI, myData.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myDataDefault.Head, myData.Head, "Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.Feet, myData.Feet, "Feet " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.Necklass, myData.Necklass, "Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.RightFinger, myData.RightFinger, "RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.LeftFinger, myData.LeftFinger, "LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myDataDefault.Feet, myData.Feet, "Feet " + TestContext.CurrentContext.Test.Name);

            // Validate the Attributes
            Assert.AreEqual(myData.AttributeString, myDataDefault.AttributeString, "AttributeString " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Damage, myDataDefault.Damage, "Damage " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_BaseMonster_Update_With_Valid_Data_Should_Pass()
        {
            var myDataDefault = DefaultModels.MonsterDefault();
            var myData = new BaseMonster();
            myData.Update(myDataDefault);

            // Validate the new BaseMonster has the expected fields.
            // All fields should match.

            // The attirbute string is what is unique about creating from BaseBaseMonster, and should be passed down...
            Assert.AreEqual(myData.UniqueItem, myDataDefault.UniqueItem, "UniqueItem " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Alive, myDataDefault.Alive, "Alive " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Name, myDataDefault.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Description, myDataDefault.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Level, myDataDefault.Level, "Level " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ExperienceTotal, myDataDefault.ExperienceTotal, "ExperienceTotal " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ImageURI, myDataDefault.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Head, myDataDefault.Head, "Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataDefault.Feet, "Feet " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Necklass, myDataDefault.Necklass, "Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.RightFinger, myDataDefault.RightFinger, "RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.LeftFinger, myDataDefault.LeftFinger, "LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataDefault.Feet, "Feet " + TestContext.CurrentContext.Test.Name);

            // Validate the Attributes
            Assert.AreEqual(myData.AttributeString, myDataDefault.AttributeString, "AttributeString " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Damage, myDataDefault.Damage, "AttributeString " + TestContext.CurrentContext.Test.Name);
        }

    }
}
