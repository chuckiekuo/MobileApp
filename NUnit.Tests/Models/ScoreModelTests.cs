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
    class ScoreModelTests
    {

        [Test]
        public void Model_Score_Instantiate_Should_Pass()
        {
            var myData = new Score();
            var Actual = myData.AutoBattle;
            bool Expected = false;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_GetSet_Should_Pass()
        {
            var mySetBattleNumber = 1;
            var mySetScoreTotal = 2;
            var mySetGameDate = DateTime.Parse("1/1/2018");
            var mySetAutoBattle = true;
            var mySetTurnCount = 3;
            var mySetRoundCount = 1;
            var mySetMonsterSlainNumber = 4;
            var mySetExperienceGainedTotal = 5;
            var mySetCharacterAtDeathList = "Characters";
            var mySetMonstersKilledList = "Monsters";
            var mySetItemsDroppedList = "Items";

            var myData = new Score
            {
                BattleNumber = 1,
                ScoreTotal = 2,
                GameDate = DateTime.Parse("1/1/2018"),
                AutoBattle = true,
                TurnCount = 3,
                RoundCount = 1,
                MonsterSlainNumber = 4,
                ExperienceGainedTotal = 5,
                CharacterAtDeathList = "Characters",
                MonstersKilledList = "Monsters",
                ItemsDroppedList = "Items",
            };

            var myGetBattleNumber = myData.BattleNumber;
            var myGetScoreTotal = myData.ScoreTotal;
            var myGetGameDate = myData.GameDate;
            var myGetAutoBattle = myData.AutoBattle;
            var myGetTurnCount = myData.TurnCount;
            var myGetRoundCount = myData.RoundCount;

            var myGetMonsterSlainNumber = myData.MonsterSlainNumber;
            var myGetExperienceGainedTotal = myData.ExperienceGainedTotal;
            var myGetCharacterAtDeathList = myData.CharacterAtDeathList;
            var myGetMonstersKilledList = myData.MonstersKilledList;
            var myGetItemsDroppedList = myData.ItemsDroppedList;


            Assert.AreEqual(mySetBattleNumber, myGetBattleNumber, "Battle " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetScoreTotal, myGetScoreTotal, "Score " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetGameDate, myGetGameDate, "Game " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetAutoBattle, myGetAutoBattle, "Auto " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetTurnCount, myGetTurnCount, "Turn " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetRoundCount, myGetRoundCount, "Turn " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetMonsterSlainNumber, myGetMonsterSlainNumber, "Slain " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetExperienceGainedTotal, myGetExperienceGainedTotal, "Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetCharacterAtDeathList, myGetCharacterAtDeathList, "Character " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetMonstersKilledList, myGetMonstersKilledList, "Monsters " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetItemsDroppedList, myGetItemsDroppedList, "Dropped " + TestContext.CurrentContext.Test.Name);

        }

        [Test]
        public void Model_Score_Update_Null_Should_Skip()
        {
            var Expected = new Score();

            var Actual = new Score();
            Actual.Update(null);

            Assert.AreEqual(Expected.Name, Actual.Name, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_Update_Valid_Should_Pass()
        {
            var mySetBattleNumber = 1;
            var mySetScoreTotal = 2;
            var mySetGameDate = DateTime.Parse("1/1/2018");
            var mySetAutoBattle = true;
            var mySetTurnCount = 3;
            var mySetRoundCount = 1;
            var mySetMonsterSlainNumber = 4;
            var mySetExperienceGainedTotal = 5;
            var mySetCharacterAtDeathList = "Characters";
            var mySetMonstersKilledList = "Monsters";
            var mySetItemsDroppedList = "Items";

            var myData = new Score();

            var newScore = new Score
            {
                BattleNumber = 1,
                ScoreTotal = 2,
                GameDate = DateTime.Parse("1/1/2018"),
                AutoBattle = true,
                TurnCount = 3,
                RoundCount = 1,
                MonsterSlainNumber = 4,
                ExperienceGainedTotal = 5,
                CharacterAtDeathList = "Characters",
                MonstersKilledList = "Monsters",
                ItemsDroppedList = "Items",
            };

            myData.Update(newScore);

            var myGetBattleNumber = myData.BattleNumber;
            var myGetScoreTotal = myData.ScoreTotal;
            var myGetGameDate = myData.GameDate;
            var myGetAutoBattle = myData.AutoBattle;
            var myGetTurnCount = myData.TurnCount;
            var myGetRoundCount = myData.RoundCount;
            var myGetMonsterSlainNumber = myData.MonsterSlainNumber;
            var myGetExperienceGainedTotal = myData.ExperienceGainedTotal;
            var myGetCharacterAtDeathList = myData.CharacterAtDeathList;
            var myGetMonstersKilledList = myData.MonstersKilledList;
            var myGetItemsDroppedList = myData.ItemsDroppedList;


            Assert.AreEqual(mySetBattleNumber, myGetBattleNumber, "Battle " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetScoreTotal, myGetScoreTotal, "Score " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetGameDate, myGetGameDate, "Game " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetAutoBattle, myGetAutoBattle, "Auto " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetTurnCount, myGetTurnCount, "Turn " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetRoundCount, myGetRoundCount, "Turn " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetMonsterSlainNumber, myGetMonsterSlainNumber, "Slain " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetExperienceGainedTotal, myGetExperienceGainedTotal, "Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetCharacterAtDeathList, myGetCharacterAtDeathList, "Character " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetMonstersKilledList, myGetMonstersKilledList, "Monsters " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(mySetItemsDroppedList, myGetItemsDroppedList, "Dropped " + TestContext.CurrentContext.Test.Name);
        }

        #region ScoreAddToListCharacter
        [Test]
        public void Model_Score_AddCharacterToList_With_Valid_Should_Pass()
        {
            var myAdd = DefaultModels.CharacterDefault();
            var myData = new Score();

            myData.AddCharacterToList(myAdd);

            var Actual = myData.CharacterAtDeathList;
            var Expected = "Name , Description , Level : 1 , Total Experience : 0 , Speed : 1 , Defense : 1 , Attack : 1 , CurrentHealth : 1 , MaxHealth : 1 , Items : Head : None , Necklass : None , PrimaryHand : None , OffHand : None , RightFinger : None , LeftFinger : None , Feet : None , Damage : 0\n";

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_AddCharacterToList_Two_With_Valid_Should_Pass()
        {
            var myAdd = DefaultModels.CharacterDefault();
            var myData = new Score();

            // do it Twice...
            myData.AddCharacterToList(myAdd);
            myData.AddCharacterToList(myAdd);

            var Actual = myData.CharacterAtDeathList;
            var myValue = "Name , Description , Level : 1 , Total Experience : 0 , Speed : 1 , Defense : 1 , Attack : 1 , CurrentHealth : 1 , MaxHealth : 1 , Items : Head : None , Necklass : None , PrimaryHand : None , OffHand : None , RightFinger : None , LeftFinger : None , Feet : None , Damage : 0\n";
            var Expected = myValue + myValue;

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_AddCharacterToList_With_Null_Add_Should_Skip()
        {
            var myAdd = DefaultModels.CharacterDefault();
            var myData = new Score();
            
            myData.AddCharacterToList(null);

            var Actual = myData.CharacterAtDeathList;
            string Expected = null;

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        #endregion ScoreAddToListCharacter

        #region ScoreAddToListMonster

        [Test]
        public void Model_Score_AddMonsterToList_With_Valid_Should_Pass()
        {
            var myAdd = DefaultModels.MonsterDefault();
            var myData = new Score();

            myData.AddMonsterToList(myAdd);

            var Actual = myData.MonstersKilledList;
            var myValue = "Name , Description , Level : 1 , Total Experience : 0 , Unique Item : None\n";
            var Expected = myValue;

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_AddMonsterToList_Two_With_Valid_Should_Pass()
        {
            var myAdd = DefaultModels.MonsterDefault();
            var myData = new Score();

            // do it Twice...
            myData.AddMonsterToList(myAdd);
            myData.AddMonsterToList(myAdd);

            var Actual = myData.MonstersKilledList;
            var myValue = "Name , Description , Level : 1 , Total Experience : 0 , Unique Item : None\n";
            var Expected = myValue + myValue;

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_AddMonsterToList_With_Null_Add_Should_Skip()
        {
            var myAdd = DefaultModels.MonsterDefault();
            var myData = new Score();

            myData.AddMonsterToList(null);

            var Actual = myData.MonstersKilledList;
            string Expected = null;

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion ScoreAddToListMonster

        #region ScoreAddToListItem
        [Test]
        public void Model_Score_AddItemToList_With_Valid_Should_Pass()
        {
            var myAdd = DefaultModels.ItemDefault(ItemLocationEnum.Feet, AttributeEnum.Attack);
            var myData = new Score();

            myData.AddItemToList(myAdd);

            var Actual = myData.ItemsDroppedList;
            var Expected = "Item for Feet , Auto Created for Feet with Attack+1 , Damage : 1 , Range : 1\n";

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_AddItemToList_Two_With_Valid_Should_Pass()
        {
            var myAdd = DefaultModels.ItemDefault(ItemLocationEnum.Feet, AttributeEnum.Attack);
            var myData = new Score();

            // do it Twice...
            myData.AddItemToList(myAdd);
            myData.AddItemToList(myAdd);

            var Actual = myData.ItemsDroppedList;
            var myValue = "Item for Feet , Auto Created for Feet with Attack+1 , Damage : 1 , Range : 1\n";
            var Expected = myValue + myValue;

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Model_Score_AddItemToList_With_Null_Score_Should_Skip()
        {
            var myAdd = DefaultModels.ItemDefault(ItemLocationEnum.Feet, AttributeEnum.Attack);
            var myData = new Score();

            myData.AddItemToList(null);

            var Actual = myData.ItemsDroppedList;
            string Expected = null;

            // Validate the controller can stand up and has a Title
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        #endregion ScoreAddToListItem
    }
}
