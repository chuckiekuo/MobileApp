using NUnit.Framework;

using Game.GameEngine;
using Game.Models;
using Game.ViewModels;
using Game.Services;

using NUnit.Tests.Models.Default;
using Xamarin.Forms.Mocks;

namespace NUnit.Tests.GameEngine
{
    [TestFixture]
    public class BattleEngineTests
    {
        #region BattleBasics
        [Test]
        public void BattleEngine_Instantiate_Should_Pass()
        {
            // Can create a new battle engine...
            var Actual = new BattleEngine();
            Assert.AreNotEqual(null, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_StartBattle_Flag_Should_Pass()
        {
            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();
            myBattleEngine.StartBattle(true);

            var Actual = myBattleEngine.GetAutoBattleState();
            var Expected = true;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_StartBattle_With_One_Character_Should_Pass()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            var myCharacter = new Character(DefaultModels.CharacterDefault());
            myBattleEngine.CharacterList.Add(myCharacter);

            myBattleEngine.StartBattle(true);

            var Actual = myBattleEngine.GetAutoBattleState();
            var Expected = true;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_StartBattle_With_No_Characters_Should_Skip()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            var Actual = myBattleEngine.StartBattle(false);
            var Expected = false;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_StartBattle_With_Six_Characters_Should_Pass()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            var myCharacter = new Character(DefaultModels.CharacterDefault());
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myBattleEngine.CharacterList.Add(myCharacter);

            myBattleEngine.StartBattle(true);

            var Actual = myBattleEngine.GetAutoBattleState();
            var Expected = true;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_EndBattle_Should_Pass()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();
            myBattleEngine.StartBattle(true);
            myBattleEngine.EndBattle();

            var Actual = myBattleEngine.BattleRunningState();
            var Expected = false;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #endregion BattleBasics

        #region AutoBattle
        [Test]
        public void BattleEngine_AutoBattle_With_Six_Characters_Should_Pass()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            // Use 6 existing myCharacter s.  This will go for a few rounds.
            var myCharacter = new Character(DefaultModels.CharacterDefault());
            myCharacter.Name = "Fighter 1";
            myCharacter.ScaleLevel(1);
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myCharacter.Name = "Fighter 2";
            myCharacter.ScaleLevel(2);
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myCharacter.Name = "Fighter 3";
            myCharacter.ScaleLevel(3);
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myCharacter.Name = "Fighter 4";
            myCharacter.ScaleLevel(4);
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myCharacter.Name = "Fighter 5";
            myCharacter.ScaleLevel(5);
            myBattleEngine.CharacterList.Add(myCharacter);

            myCharacter = new Character(DefaultModels.CharacterDefault());
            myCharacter.Name = "Fighter 6";
            myCharacter.ScaleLevel(6);
            myBattleEngine.CharacterList.Add(myCharacter);

            // Use the Existing Characters...

            // Turn off random numbers
            // For a hit on everything...
            GameGlobals.SetForcedRandomNumbers(1, 20);  // Needs to be 20 so monsters always score a hit...

            MasterDataStore.ForceDataRestoreAll();

            myBattleEngine.AutoBattle();

            // Reset
            GameGlobals.ToggleRandomState();

            var Actual = myBattleEngine.BattleScore;
            
            Assert.AreNotEqual(null, Actual, "Score Object " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.ExperienceGainedTotal, "Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.RoundCount, "Round Count " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.TurnCount, "Turn Count " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.ScoreTotal, "Score Total " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.ItemsDroppedList, "Items Dropped " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.MonstersKilledList, "Monsters Killed " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.CharacterAtDeathList, "Character List " + TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_AutoBattle_With_No_Characters_Should_Fail()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            // Clear the dataset...
            CharactersViewModel.Instance.Dataset.Clear();

            var Actual = myBattleEngine.AutoBattle();
            var Expected = false;

            // Reset
            CharactersViewModel.Instance.ForceDataRefresh();

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);

        }

        [Test]
        public void BattleEngine_AutoBattle_With_No_Initial_Characters_Should_Pass()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            // Add new myCharacters in automaticaly
            // Characters are Level 1
            // Monsters are Level 1
            // Monsters will kill Characters in round 1.

            // Turn off random numbers
            // For a hit on everything...
            GameGlobals.SetForcedRandomNumbers(1, 20);  // Needs to be 20 so monsters always score a hit...

            MasterDataStore.ForceDataRestoreAll();

            myBattleEngine.AutoBattle();

            // Reset
            GameGlobals.ToggleRandomState();

            var Actual = myBattleEngine.BattleScore;

            Assert.AreNotEqual(1, Actual.RoundCount, "Round Count " + TestContext.CurrentContext.Test.Name);

            Assert.AreNotEqual(null, Actual, "Score Object " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.ExperienceGainedTotal, "Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.TurnCount, "Turn Count " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.ScoreTotal, "Score Total " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.ItemsDroppedList, "Items Dropped " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.MonstersKilledList, "Monsters Killed " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.CharacterAtDeathList, "Character List " + TestContext.CurrentContext.Test.Name);
        }
        
        [Test]
        public void BattleEngine_AutoBattle_With_Characters_Level_2_Should_Level_Up_Pass()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            // Turn off random numbers
            // For a hit on everything...
            GameGlobals.SetForcedRandomNumbers(1, 20);  // Needs to be 20 so monsters always score a hit...

            MasterDataStore.ForceDataRestoreAll();

            // Add new Characters in automaticaly
            // Characters are Level 2
            // Monsters are Level 1
            // Characters have weapons...
            // Use 6 existing Characters.  This will go for a few rounds.
            var myLevel = 3;
            var myCharacter = myBattleEngine.GetRandomCharacter(myLevel, myLevel);
            myCharacter.Attribute.MaxHealth = 100;
            myCharacter.Attribute.CurrentHealth = 100;

            // Set them just below the next level, so they level up...
            myCharacter.ExperienceTotal = LevelTable.Instance.LevelDetailsList[myLevel + 1].Experience - 1;

            for (var count = 1; count <7; count++)
            {
                var myNewCharacter = new Character(myCharacter);
                myNewCharacter.Name = "Fighter " + count;
                myBattleEngine.CharacterList.Add(myNewCharacter);
            }

            var TempDamageBonusValue = GameGlobals.ForceCharacterDamangeBonusValue;
            // Make myCharacter s hit really really hard...
            GameGlobals.ForceCharacterDamangeBonusValue = 100;  

            myBattleEngine.AutoBattle();

            // Reset
            GameGlobals.ToggleRandomState();
            GameGlobals.ForceCharacterDamangeBonusValue = TempDamageBonusValue;

            var Actual = myBattleEngine.BattleScore;

            Assert.AreNotEqual(1, Actual.RoundCount, "Round Count " + TestContext.CurrentContext.Test.Name);

            Assert.AreNotEqual(null, Actual, "Score Object " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.ExperienceGainedTotal, "Experience " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.TurnCount, "Turn Count " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(0, Actual.ScoreTotal, "Score Total " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.ItemsDroppedList, "Items Dropped " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.MonstersKilledList, "Monsters Killed " + TestContext.CurrentContext.Test.Name);
            Assert.AreNotEqual(string.Empty, Actual.CharacterAtDeathList, "Character List " + TestContext.CurrentContext.Test.Name);
        }

        #endregion AutoBattle

        #region AddCharactersToBattle
        [Test]
        public void BattleEngine_AddCharactersToBattle_With_6_Characters_Should_Skip()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            myBattleEngine.CharacterList.Add(new Character());
            myBattleEngine.CharacterList.Add(new Character());
            myBattleEngine.CharacterList.Add(new Character());
            myBattleEngine.CharacterList.Add(new Character());
            myBattleEngine.CharacterList.Add(new Character());
            myBattleEngine.CharacterList.Add(new Character());

            var Return = myBattleEngine.AddCharactersToBattle();

            var Actual = myBattleEngine.CharacterList.Count;
            var Expected = 6;

            Assert.AreEqual(true, Return, " Pass Fail " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_AddCharactersToBattle_With_Empty_CharacterListView_Should_Fail()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            // Clear the dataset...
            CharactersViewModel.Instance.Dataset.Clear();

            var Return = myBattleEngine.AddCharactersToBattle();

            // Reset
            CharactersViewModel.Instance.ForceDataRefresh();

            Assert.AreEqual(false, Return, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void BattleEngine_AddCharactersToBattle_With_Empty_CharacterList_Should_Create_Characters()
        {
            MockForms.Init();

            // Can create a new battle engine...
            var myBattleEngine = new BattleEngine();

            // Force data for Characters and Items to be loaded and ready...
            ItemsViewModel.Instance.ForceDataRefresh();
            CharactersViewModel.Instance.ForceDataRefresh();

            var myItems = ItemsViewModel.Instance;

            var Return = myBattleEngine.AddCharactersToBattle();

            var Actual = myBattleEngine.CharacterList.Count;
            var Expected = 6;

            Assert.AreEqual(true, Return, " Pass Fail " + TestContext.CurrentContext.Test.Name);
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        #endregion AddCharactersToBattle
    }
};