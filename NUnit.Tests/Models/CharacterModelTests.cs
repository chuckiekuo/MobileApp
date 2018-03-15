using NUnit.Framework;
using NUnit.Tests.Models.Default;
using Xamarin.Forms.Mocks;
using System.Linq;

using Game.Models;
using Game.GameEngine;
using Game.ViewModels;
using Game.Services;
using NUnit.Tests.Models;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        #region NewCharacter
        [Test]
        public void Model_Character_Instantiate_Should_Pass()
        {
            var myData = new Character();
            var myDataDefault = DefaultModels.CharacterDefault();

            // Set character to be the same as a default character

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
            myData.Head = myDataDefault.Head;
            myData.Feet = myDataDefault.Feet;
            myData.Necklass = myDataDefault.Necklass;
            myData.RightFinger = myDataDefault.RightFinger;
            myData.LeftFinger = myDataDefault.LeftFinger;
            myData.Feet = myDataDefault.Feet;

            // Compare character to what is expected.
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

            Assert.AreEqual(myData.Attribute.Speed, myDataDefault.Attribute.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Defense, myDataDefault.Attribute.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Attack, myDataDefault.Attribute.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.CurrentHealth, myDataDefault.Attribute.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.MaxHealth, myDataDefault.Attribute.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_Instantiate_From_BaseCharacter_Should_Pass()
        {
            // create a new character from the base character

            var myDataBase = DefaultModels.BaseCharacterDefault();

            var myData = new Character(myDataBase);

            // Validate the new character has the expected fields.
            // All fields should match.

            // The attirbute string is what is unique about creating from BaseCharacter, and should be passed down...

            Assert.AreEqual(myData.Alive, myDataBase.Alive, "Alive " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Name, myDataBase.Name, "Name " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Description, myDataBase.Description, "Description " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Level, myDataBase.Level, "Level " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ExperienceTotal, myDataBase.ExperienceTotal, "ExperienceTotal " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.ImageURI, myDataBase.ImageURI, "ImageURI " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Head, myDataBase.Head, "Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataBase.Feet, "Feet " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Necklass, myDataBase.Necklass, "Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.RightFinger, myDataBase.RightFinger, "RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.LeftFinger, myDataBase.LeftFinger, "LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Feet, myDataBase.Feet, "Feet " + TestContext.CurrentContext.Test.Name);

            // Validate the Attributes
            Assert.AreEqual(myData.AttributeString, myDataBase.AttributeString, "AttributeString " + TestContext.CurrentContext.Test.Name);

            Assert.AreEqual(myData.Attribute.Speed, 1, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Defense, 1, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Attack, 1, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.CurrentHealth, 1, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.MaxHealth, 1, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }
        #endregion NewCharacter

        #region Update
        [Test]
        public void Model_Character_Update_Should_Pass()
        {
            // create a character
            // get the default character
            // Update the character by passing in the default
            // Compare results 

            var myDataDefault = DefaultModels.CharacterDefault();
            var myData = new Character();
            myData.Update(myDataDefault);

            // Validate the new character has the expected fields.
            // All fields should match.

            // The attirbute string is what is unique about creating from BaseCharacter, and should be passed down...

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

            Assert.AreEqual(myData.Attribute.Speed, myDataDefault.Attribute.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Defense, myDataDefault.Attribute.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Attack, myDataDefault.Attribute.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.CurrentHealth, myDataDefault.Attribute.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.MaxHealth, myDataDefault.Attribute.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_Update_Null_Should_Skip()
        {
            // create a character
            // get the default character
            // Update the character by passing in the default
            // Compare results 

            var myDataDefault = DefaultModels.CharacterDefault();
            var myData = new Character(myDataDefault);

            // Passing Null, so no update should happen
            myData.Update(null);

            // Validate the new character has the expected fields.
            // All fields should match.

            // The attirbute string is what is unique about creating from BaseCharacter, and should be passed down...

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

            Assert.AreEqual(myData.Attribute.Speed, myDataDefault.Attribute.Speed, "Speed " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Defense, myDataDefault.Attribute.Defense, "Defense " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.Attack, myDataDefault.Attribute.Attack, "Attack " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.CurrentHealth, myDataDefault.Attribute.CurrentHealth, "CurrentHealth " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Attribute.MaxHealth, myDataDefault.Attribute.MaxHealth, "MaxHealth " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_BaseCharacter_Update_Should_Pass()
        {
            // create a BaseCharacter
            // get the default BaseCharacter
            // Update the BaseCharacter by passing in the default
            // Compare results 

            var myDataDefault = DefaultModels.BaseCharacterDefault();
            var myData = new BaseCharacter();
            myData.Update(myDataDefault);

            // Validate the new BaseCharacter has the expected fields.
            // All fields should match.

            // The attirbute string is what is unique about creating from BaseBaseCharacter, and should be passed down...

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
        }

        [Test]
        public void Model_BaseCharacter_Update_Null_Should_Skip()
        {
            // create a BaseCharacter
            // get the default BaseCharacter
            // Update the BaseCharacter by passing in the default
            // Compare results 

            var myDataDefault = DefaultModels.CharacterDefault();
            var myData = new BaseCharacter(myDataDefault);

            // Passing Null, so no update should happen
            myData.Update(null);

            // Validate the new BaseCharacter has the expected fields.
            // All fields should match.

            // The attirbute string is what is unique about creating from BaseBaseCharacter, and should be passed down...

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
        }

        #endregion Update

        #region Experience
        [Test]
        public void Model_Character_AddExperience_Should_Pass()
        {
            var myData = DefaultModels.CharacterDefault();

            var Value = 1;
            var Expected = myData.ExperienceTotal + Value;

            myData.AddExperience(Value);

            Assert.AreEqual(myData.ExperienceTotal, Expected, "Added Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Level, 1, "Level 1 " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_AddExperience_Negative_Should_Fail()
        {
            var myData = DefaultModels.CharacterDefault();

            var Value = -1;
            var Expected = myData.ExperienceTotal + Value;

            myData.AddExperience(Value);

            Assert.AreNotEqual(myData.ExperienceTotal, Expected, "Added Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Level, 1, "Level 1 " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_AddExperience_AboveLevel2_Should_LevelUp()
        {
            var myData = DefaultModels.CharacterDefault();
            myData.Level = 1;

            // Add enough points to get to Level 2.
            var Value = 301;

            var Expected = myData.ExperienceTotal + Value;

            myData.AddExperience(Value);

            Assert.AreEqual(myData.ExperienceTotal, Expected, "Added Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(2, myData.Level, "Level 2 " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_AddExperience_AboveLevel20_Should_LevelUp()
        {
            var myData = DefaultModels.CharacterDefault();
            myData.Level = 1;

            // Add enough points to get to Level 2.
            var Value = 375000;

            var NewExperience = myData.ExperienceTotal + Value;
            var OldHealth = myData.Attribute.MaxHealth;

            myData.AddExperience(Value);

            var Expected = 20;
            var Actual = myData.Level;

            Assert.Greater(myData.Attribute.MaxHealth, OldHealth, "Health Updated " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(NewExperience, myData.ExperienceTotal, "Added Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_AddExperience_With_No_LevelUp_Should_StaySameLevel()
        {
            var myData = DefaultModels.CharacterDefault();
            myData.Level = 2;

            // Don't add enough points to increase level
            var Value = 1;

            var Expected = myData.ExperienceTotal + Value;

            myData.AddExperience(Value);

            Assert.AreEqual(myData.ExperienceTotal, Expected, "Added Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(2, myData.Level, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_LevelUp_With_Null_LevelList_Should_Skip()
        {
            var myData = DefaultModels.CharacterDefault();
            myData.Level = 1;

            // Remove the Level Data, and have only 1 row, which is level 0...
            var save0 = LevelTable.Instance.LevelDetailsList[0];
            LevelTable.Instance.LevelDetailsList.Clear();

            var Actual = myData.LevelUp();
            bool Expected = false;

            // Restore
            LevelTable.Instance.ClearAndLoadDatTable();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion Experience

        #region Output
        [Test]
        public void Model_Character_FormatOutput_DefaultCharacter_Should_Pass()
        {
            var myData = DefaultModels.CharacterDefault();

            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Speed : 1 , Defense : 1 , Attack : 1 , CurrentHealth : 1 , MaxHealth : 1 , Items : Head : None , Necklass : None , PrimaryHand : None , OffHand : None , RightFinger : None , LeftFinger : None , Feet : None , Damage : 0";

            var Actual = myData.FormatOutput();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_FormatOutput_With_Item_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.CharacterDefault();
            myData.Name = "Name";

            // Add Item to Character Head Postion
            var myItem = new Item();
            myItem.Name = "item";
            myItem.Value = 1;
            myItem.Attribute = AttributeEnum.Attack;

            ItemsViewModel.Instance.AddAsync(myItem).GetAwaiter().GetResult();
            myData.Head = myItem.Guid;

            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Speed : 1 , Defense : 1 , Attack : 1 , CurrentHealth : 1 , MaxHealth : 1 , Items : Head : 1 , Necklass : None , PrimaryHand : None , OffHand : None , RightFinger : None , LeftFinger : None , Feet : None , Damage : 0";

            var Actual = myData.FormatOutput();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_FormatOutput_With_Item_BogusLocation_Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.CharacterDefault();
            myData.Name = "Name";

            // Add Item to Character Head Postion
            var myItem = new Item();
            myItem.Name = "item";
            myItem.Value = 1;
            myItem.Attribute = AttributeEnum.Attack;

            ItemsViewModel.Instance.AddAsync(myItem).GetAwaiter().GetResult();
            myData.Head = "bogus";

            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Speed : 1 , Defense : 1 , Attack : 1 , CurrentHealth : 1 , MaxHealth : 1 , Items : Head : None , Necklass : None , PrimaryHand : None , OffHand : None , RightFinger : None , LeftFinger : None , Feet : None , Damage : 0";

            var Actual = myData.FormatOutput();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion Output

        #region LevelUp

        [Test]
        public void Model_Character_LevelUpToValue_LevelNeg_Should_Pass()
        {
            var myData = DefaultModels.CharacterDefault();

            var Level = -2;

            var Expected = 1;

            var Actual = myData.LevelUpToValue(Level);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_LevelUpToValue_Level2_Should_Pass()
        {
            var myData = DefaultModels.CharacterDefault();

            var Level = 2;

            var Expected = 2;

            var Actual = myData.LevelUpToValue(Level);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_LevelUpToValue_Level0_Should_Skip()
        {
            var myData = DefaultModels.CharacterDefault();

            var Level = 0;

            var Expected = 1;

            var Actual = myData.LevelUpToValue(Level);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_LevelUpToValue_Lower_Than_Current_Should_Skip()
        {
            var myData = DefaultModels.CharacterDefault();

            var Expected = 3;

            myData.LevelUpToValue(3);

            var Actual = myData.LevelUpToValue(1);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_LevelUpToValue_Level00_Should_Be_20()
        {
            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 100;

            var Expected = 20;

            var Actual = myData.LevelUpToValue(Level);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_LevelUpToValue_Leve20_Should_Have_Known_Values()
        {
            // Need to level up, but turn off Random, so know what the current and max health should be

            GameGlobals.SetForcedRandomNumbers(1, 20);

            var myData = DefaultModels.CharacterDefault();

            var Level = 20;

            var Expected = 20;

            var Actual = myData.LevelUpToValue(Level);

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, myData.Attribute.CurrentHealth, "Current Health " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, myData.Attribute.MaxHealth, "Max Health " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_LevelUpToValue_Leve20_Should_Have_Known_Range()
        {
            // Need to level up, but turn off Random, so know what the current and max health should be

            var myData = DefaultModels.CharacterDefault();

            var Level = 20;

            var Actual = myData.LevelUpToValue(Level);

            Assert.GreaterOrEqual(myData.Attribute.CurrentHealth, 20, "Current Health " + TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(myData.Attribute.CurrentHealth, 200, "Current Health" + TestContext.CurrentContext.Test.Name);

            Assert.GreaterOrEqual(myData.Attribute.MaxHealth, 20, "Max Health " + TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(myData.Attribute.MaxHealth, 200, "Max Health " + TestContext.CurrentContext.Test.Name);

        }

        #endregion LevelUp

        #region Death
        [Test]
        public void Model_Character_CauseDeath_Should_Pass()
        {
            var myData = DefaultModels.CharacterDefault();

            myData.CauseDeath();

            var Actual = myData.Alive;

            // Just current health, because value was -1
            bool Expected = false;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion Death

        #region TakeDamage
        [Test]
        public void Model_Character_TakeDamage_Neg__Should_Skip()
        {
            MockForms.Init();

            var myData = DefaultModels.CharacterDefault();

            myData.LevelUpToValue(2);

            var CurrentHealth = myData.GetHealthCurrent();

            var Value = -1;

            myData.TakeDamage(Value);

            var Actual = myData.Attribute.CurrentHealth;

            // Just current health, because value was -1
            var Expected = CurrentHealth;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_TakeDamage_1__Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.CharacterDefault();

            myData.LevelUpToValue(2);

            var CurrentHealth = myData.GetHealthCurrent();

            var Value = 1;

            myData.TakeDamage(Value);

            var Actual = myData.Attribute.CurrentHealth;

            // Just current health, because value was -1
            var Expected = CurrentHealth -1 ;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_TakeDamage_Kill__Should_Pass()
        {
            MockForms.Init();

            var myData = DefaultModels.CharacterDefault();

            myData.LevelUpToValue(2);

            var CurrentHealth = myData.GetHealthCurrent();

            // Same damage as health, should kill...
            var Value = CurrentHealth;

            myData.TakeDamage(Value);

            var Actual = myData.Attribute.CurrentHealth;
            var Expected = 0;

            Assert.AreEqual(Expected, Actual, "Health " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(myData.Alive, false, "Alive " + TestContext.CurrentContext.Test.Name);
        }

        #endregion TakeDamage

        #region Attributes
        #region Attack
        [Test]
        public void Model_Character_GetAttribute_Attack_Level1_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Attack;

            var Actual = myData.GetAttack();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Attack_Level20_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Attack;

            var Actual = myData.GetAttack();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Attack_Level1_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Attack;

            var Actual = myData.GetAttack();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Attack_Level20_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Attack;

            var Actual = myData.GetAttack();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion Attack

        #region Speed
        [Test]
        public void Model_Character_GetAttribute_Speed_Level1_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Speed;

            var Actual = myData.GetSpeed();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Speed_Level20_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Speed;

            var Actual = myData.GetSpeed();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Speed_Level1_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Speed;

            var Actual = myData.GetSpeed();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Speed_Level20_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Speed;

            var Actual = myData.GetSpeed();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion Speed

        #region Defense
        [Test]
        public void Model_Character_GetAttribute_Defense_Level1_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Defense;

            var Actual = myData.GetDefense();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Defense_Level20_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Defense;

            var Actual = myData.GetDefense();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Defense_Level1_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Defense;

            var Actual = myData.GetDefense();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Defense_Level20_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = 1 + LevelTable.Instance.LevelDetailsList[Level].Defense;

            var Actual = myData.GetDefense();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion Defense

        #region MaxHealth
        [Test]
        public void Model_Character_GetAttribute_MaxHealth_Level1_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthMax();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_MaxHealth_Level20_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthMax();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_MaxHealth_Level1_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthMax();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_MaxHealth_Level20_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthMax();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        #endregion MaxHealth

        #region CurrentHealth
        [Test]
        public void Model_Character_GetAttribute_CurrentHealth_Level1_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthCurrent();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_CurrentHealth_Level20_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthCurrent();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_CurrentHealth_Level1_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthCurrent();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_CurrentHealth_Level20_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var MinExpected = Level * 1;
            var MaxExpected = Level * 10;

            var Actual = myData.GetHealthCurrent();

            Assert.GreaterOrEqual(Actual, MinExpected, TestContext.CurrentContext.Test.Name);
            Assert.LessOrEqual(Actual, MaxExpected, TestContext.CurrentContext.Test.Name);
        }

        #endregion CurrentHealth

        #region Damage
        [Test]
        public void Model_Character_GetAttribute_Damage_Level1_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = myData.GetLevelBasedDamage();  // + ItemDamage TODO Add in Item here

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Actual = myData.GetDamageRollValue();

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Damage_Level20_NoItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = myData.GetLevelBasedDamage();  // + ItemDamage TODO Add in Item here

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Actual = myData.GetDamageRollValue();

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Damage_Level1_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 1;
            myData.LevelUpToValue(Level);

            var Expected = myData.GetLevelBasedDamage();  // + ItemDamage TODO Add in Item here

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Actual = myData.GetDamageRollValue();

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetAttribute_Damage_Level20_WithItems_Should_Pass()
        {
            MockForms.Init();

            // Has no Items, with appropraite Level Bonus

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var Level = 20;
            myData.LevelUpToValue(Level);

            var Expected = myData.GetLevelBasedDamage();  // + ItemDamage TODO Add in Item here

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Actual = myData.GetDamageRollValue();

            // Reset
            GameGlobals.ToggleRandomState();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion Damage


        #endregion Attributes

        #region Items

        [Test]
        public void Model_Character_RemoveItem_Correct_Should_Pass()
        {
            MockForms.Init();

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var FeetItem = myData.RemoveItem(ItemLocationEnum.Feet);
            var HeadItem = myData.RemoveItem(ItemLocationEnum.Head);
            var LeftFingerItem = myData.RemoveItem(ItemLocationEnum.LeftFinger);
            var NecklassItem = myData.RemoveItem(ItemLocationEnum.Necklass);
            var RightFingerItem = myData.RemoveItem(ItemLocationEnum.RightFinger);
            var OffHandItem = myData.RemoveItem(ItemLocationEnum.OffHand);
            var PrimaryHandItem = myData.RemoveItem(ItemLocationEnum.PrimaryHand);

            string Expected = null;

            Assert.AreEqual(Expected, myData.Feet, "Feet " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, myData.Head, "Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, myData.LeftFinger, "LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, myData.Necklass, "Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, myData.RightFinger, "RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, myData.OffHand, "OffHand " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, myData.PrimaryHand, "PrimaryHand " + TestContext.CurrentContext.Test.Name);

            // Validate the returned items are all empty items
            Item ExpectedItem = null;
            Assert.AreEqual(ExpectedItem, FeetItem, "Item Feet " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(ExpectedItem, HeadItem, "Item Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(ExpectedItem, LeftFingerItem, "Item LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(ExpectedItem, NecklassItem, "Item Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(ExpectedItem, RightFingerItem, "Item RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(ExpectedItem, OffHandItem, "Item OffHand " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(ExpectedItem, PrimaryHandItem, "Item PrimaryHand " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_RemoveItem_Unknown_Should_Skip()
        {
            MockForms.Init();

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            var UnknownItem = myData.RemoveItem(ItemLocationEnum.Unknown);

            // Validate the returned items are all empty items
            Item ExpectedItem = null;

            Assert.AreEqual(ExpectedItem, UnknownItem, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_DropAllItems_NoItems_Should_Skip()
        {
            MockForms.Init();

            // Add Items
            var myData = DefaultModels.CharacterDefault();

            // All item slots are empty, so nothing to return...
            var myItemList = myData.DropAllItems();

            Assert.AreEqual(false, myItemList.Any(), TestContext.CurrentContext.Test.Name);
        }
       
        [Test]
        public void Model_Character_AddItem_Correct_Head_Should_Pass()
        {
            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            // Add Item to Character Head Postion
            var myItem = new Item();

            ItemsViewModel.Instance.AddAsync(myItem).GetAwaiter().GetResult();

            myData.Head = myItem.Guid;

            var myResult = ItemsViewModel.Instance.GetItem(myData.Head);
            var Expected = 1;

            var Actual = 1;

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemBonus_Correct_Attack_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            myData.Head = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, ItemLocationEnum.Head, 10).Guid;
            myData.Necklass = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, ItemLocationEnum.Necklass, 100).Guid;
            myData.PrimaryHand = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 1000).Guid;
            myData.OffHand = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, ItemLocationEnum.OffHand, 10000).Guid;
            myData.RightFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, ItemLocationEnum.RightFinger, 100000).Guid;
            myData.LeftFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, ItemLocationEnum.LeftFinger, 1000000).Guid;
            myData.Feet = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, ItemLocationEnum.Feet, 10000000).Guid;

            var Actual = myData.GetItemBonus(AttributeEnum.Attack);
            var Expected = 11111110; // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemBonus_Correct_Speed_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            myData.Head = ItemHelper.AddItemForAttribute(AttributeEnum.Speed, ItemLocationEnum.Head, 10).Guid;
            myData.Necklass = ItemHelper.AddItemForAttribute(AttributeEnum.Speed, ItemLocationEnum.Necklass, 100).Guid;
            myData.PrimaryHand = ItemHelper.AddItemForAttribute(AttributeEnum.Speed, ItemLocationEnum.PrimaryHand, 1000).Guid;
            myData.OffHand = ItemHelper.AddItemForAttribute(AttributeEnum.Speed, ItemLocationEnum.OffHand, 10000).Guid;
            myData.RightFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Speed, ItemLocationEnum.RightFinger, 100000).Guid;
            myData.LeftFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Speed, ItemLocationEnum.LeftFinger, 1000000).Guid;
            myData.Feet = ItemHelper.AddItemForAttribute(AttributeEnum.Speed, ItemLocationEnum.Feet, 10000000).Guid;

            var Actual = myData.GetItemBonus(AttributeEnum.Speed);
            var Expected = 11111110; // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemBonus_Correct_Defense_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            myData.Head = ItemHelper.AddItemForAttribute(AttributeEnum.Defense, ItemLocationEnum.Head, 10).Guid;
            myData.Necklass = ItemHelper.AddItemForAttribute(AttributeEnum.Defense, ItemLocationEnum.Necklass, 100).Guid;
            myData.PrimaryHand = ItemHelper.AddItemForAttribute(AttributeEnum.Defense, ItemLocationEnum.PrimaryHand, 1000).Guid;
            myData.OffHand = ItemHelper.AddItemForAttribute(AttributeEnum.Defense, ItemLocationEnum.OffHand, 10000).Guid;
            myData.RightFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Defense, ItemLocationEnum.RightFinger, 100000).Guid;
            myData.LeftFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Defense, ItemLocationEnum.LeftFinger, 1000000).Guid;
            myData.Feet = ItemHelper.AddItemForAttribute(AttributeEnum.Defense, ItemLocationEnum.Feet, 10000000).Guid;

            var Actual = myData.GetItemBonus(AttributeEnum.Defense);
            var Expected = 11111110; // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemBonus_Correct_CurrentHealth_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            myData.Head = ItemHelper.AddItemForAttribute(AttributeEnum.CurrentHealth, ItemLocationEnum.Head, 10).Guid;
            myData.Necklass = ItemHelper.AddItemForAttribute(AttributeEnum.CurrentHealth, ItemLocationEnum.Necklass, 100).Guid;
            myData.PrimaryHand = ItemHelper.AddItemForAttribute(AttributeEnum.CurrentHealth, ItemLocationEnum.PrimaryHand, 1000).Guid;
            myData.OffHand = ItemHelper.AddItemForAttribute(AttributeEnum.CurrentHealth, ItemLocationEnum.OffHand, 10000).Guid;
            myData.RightFinger = ItemHelper.AddItemForAttribute(AttributeEnum.CurrentHealth, ItemLocationEnum.RightFinger, 100000).Guid;
            myData.LeftFinger = ItemHelper.AddItemForAttribute(AttributeEnum.CurrentHealth, ItemLocationEnum.LeftFinger, 1000000).Guid;
            myData.Feet = ItemHelper.AddItemForAttribute(AttributeEnum.CurrentHealth, ItemLocationEnum.Feet, 10000000).Guid;

            var Actual = myData.GetItemBonus(AttributeEnum.CurrentHealth);
            var Expected = 11111110; // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemBonus_Correct_MaxHealth_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            myData.Head = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.Head, 10).Guid;
            myData.Necklass = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.Necklass, 100).Guid;
            myData.PrimaryHand = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.PrimaryHand, 1000).Guid;
            myData.OffHand = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.OffHand, 10000).Guid;
            myData.RightFinger = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.RightFinger, 100000).Guid;
            myData.LeftFinger = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.LeftFinger, 1000000).Guid;
            myData.Feet = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.Feet, 10000000).Guid;

            var Actual = myData.GetItemBonus(AttributeEnum.MaxHealth);
            var Expected = 11111110; // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_DropAllItems_FullyLoaded_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            myData.Head = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.Head, 10).Guid;
            myData.Necklass = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.Necklass, 100).Guid;
            myData.PrimaryHand = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.PrimaryHand, 1000).Guid;
            myData.OffHand = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.OffHand, 10000).Guid;
            myData.RightFinger = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.RightFinger, 100000).Guid;
            myData.LeftFinger = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.LeftFinger, 1000000).Guid;
            myData.Feet = ItemHelper.AddItemForAttribute(AttributeEnum.MaxHealth, ItemLocationEnum.Feet, 10000000).Guid;

            // Now drop them all...
            var DroppedList = myData.DropAllItems();

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            // Should have a list of each item
            Assert.AreEqual(7, DroppedList.Count(), "List Count " + TestContext.CurrentContext.Test.Name);

            // All locations should be null.
            Assert.AreEqual(null, myData.Head, "Head " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(null, myData.Necklass, "Necklass " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(null, myData.PrimaryHand, "PrimaryHand " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(null, myData.OffHand, "OffHand " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(null, myData.RightFinger, "RightFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(null, myData.LeftFinger, "LeftFinger " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(null, myData.Feet, "Feet " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetDamage_Correct_ForSword_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItem = new Item
            {
                Attribute = AttributeEnum.Attack,
                Location = ItemLocationEnum.PrimaryHand,
                Damage  = 10
            };
            ItemsViewModel.Instance.AddAsync(myItem).GetAwaiter().GetResult();  // Register Item to DataSet
            myData.PrimaryHand = myItem.Guid;

            // Turn off random numbers
            GameGlobals.SetForcedRandomNumbers(1, 20);

            var Actual = myData.GetDamageRollValue();
            var Expected = 1 + myData.GetLevelBasedDamage(); // 10 + the character level damage (should be 1 for a level 1 character...)

            // Reset
            GameGlobals.ToggleRandomState();

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public async Task Model_Character_GetDamage_FormatOutput_ForSword_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItem = new Item
            {
                Attribute = AttributeEnum.Attack,
                Location = ItemLocationEnum.PrimaryHand,
                Damage = 10,
                Value = 1
            };
            await ItemsViewModel.Instance.AddAsync(myItem);  // Register Item to DataSet
            myData.PrimaryHand = myItem.Guid;

            var Actual = myData.FormatOutput();
            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Speed : 1 , Defense : 1 , Attack : 1 , CurrentHealth : 1 , MaxHealth : 1 , Items : Head : None , Necklass : None , PrimaryHand : 1 , OffHand : None , RightFinger : None , LeftFinger : None , Feet : None , Damage : 10";

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }


        #endregion Items

        #region ItemLocation
        [Test]
        public void Model_Character_GetItemByLocation_Correct_Head_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.Head;
            myData.Head = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, myItemLocationEnum, 10).Guid;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            var Expected = ItemsViewModel.Instance.GetItem(myData.Head); // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemByLocation_Correct_Necklass_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.Necklass;
            myData.Necklass = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, myItemLocationEnum, 10).Guid;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            var Expected = ItemsViewModel.Instance.GetItem(myData.Necklass); // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemByLocation_Correct_PrimaryHand_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.PrimaryHand;
            myData.PrimaryHand = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, myItemLocationEnum, 10).Guid;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            var Expected = ItemsViewModel.Instance.GetItem(myData.PrimaryHand); // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemByLocation_Correct_OffHand_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.OffHand;
            myData.OffHand = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, myItemLocationEnum, 10).Guid;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            var Expected = ItemsViewModel.Instance.GetItem(myData.OffHand); // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemByLocation_Correct_RightFinger_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.RightFinger;
            myData.RightFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, myItemLocationEnum, 10).Guid;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            var Expected = ItemsViewModel.Instance.GetItem(myData.RightFinger); // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemByLocation_Correct_LeftFinger_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.LeftFinger;
            myData.LeftFinger = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, myItemLocationEnum, 10).Guid;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            var Expected = ItemsViewModel.Instance.GetItem(myData.LeftFinger); // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemByLocation_Correct_Feet_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.Feet;
            myData.Feet = ItemHelper.AddItemForAttribute(AttributeEnum.Attack, myItemLocationEnum, 10).Guid;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            var Expected = ItemsViewModel.Instance.GetItem(myData.Feet); // 0 at the end because that is for character base for attack

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Description, Actual.Description, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Value, Actual.Value, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Attribute, Actual.Attribute, TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected.Damage, Actual.Damage, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Character_GetItemByLocation_Correct_Unknown_Should_Pass()
        {
            // Need to set Attack Items, on all the locations.
            // Then calculate the total score.

            MockForms.Init();

            // Get State of the DataStore, and set to run on the Mock
            var myDataStoreEnum = MasterDataStore.GetDataStoreMockFlag();
            MasterDataStore.ToggleDataStore(DataStoreEnum.Mock);

            var myData = DefaultModels.CharacterDefault();

            var myItemLocationEnum = ItemLocationEnum.Unknown;

            var Actual = myData.GetItemByLocation(myItemLocationEnum);
            string Expected = null;

            // Return state
            MasterDataStore.ToggleDataStore(myDataStoreEnum);

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        
        #endregion ItemLocation
    }
}
