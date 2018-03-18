using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Game.Models;
using Game.ViewModels;

namespace Game.GameEngine
{
    // Battle is the top structure

    // A battle has a score, a character list, and a list of items

   public class BattleEngine : RoundEngine
    {

        // The status of the actual battle, running or not (over)
        private bool isBattleRunning = false;

        // Constructor calls Init
        public BattleEngine()
        {
            BattleEngineInit();
        }

        // Sets the new state for the variables for Battle
        private void BattleEngineInit()
        {
            BattleScore = new Score();
            CharacterList = new List<Character>();
            ItemPool = new List<Item>();
        }

        // Determine if Auto Battle is On or Off
        public bool GetAutoBattleState()
        {
            return BattleScore.AutoBattle;
        }

        // Return if the Battle is Still running
        public bool BattleRunningState()
        {
            return isBattleRunning;
        }

        // Battle is over
        // Update Battle State, Log Score to Database
        public void EndBattle()
        {
            // Set Score
            BattleScore.ScoreTotal = BattleScore.ExperienceGainedTotal;

            // Set off state
            isBattleRunning = false;

            // Save the Score to the DataStore
            ScoresViewModel.Instance.AddAsync(BattleScore).GetAwaiter().GetResult();
        }

        // Initializes the Battle to begin
        public bool StartBattle(bool isAutoBattle)
        {
            // New Battle
            // Load Characters
            BattleScore.AutoBattle = isAutoBattle;
            isBattleRunning = true;

            // Characters not Initialized, so false start...
            if (CharacterList.Count < 1)
            {
                return false;
            }

            return true;
        }

        // Add Characters
        // Scale them to meet Character Strength...
        public bool AddCharactersToBattle()
        {
            // Check to see if the Character list is full, if so, no need to add more...
            if (CharacterList.Count >= 6)
            {
                return true;
            }

            // TODO, determine the character strength
            // add Characters up to that strength...
            var ScaleLevelMax = 2;
            var ScaleLevelMin = 1;

            if (CharactersViewModel.Instance.Dataset.Count < 1)
            {
                return false;
            }

            // Get 6 Characters
            do
            {
                var myData = GetRandomCharacter(ScaleLevelMin, ScaleLevelMax);
                CharacterList.Add(myData);
            } while (CharacterList.Count < 6);

            return true;
        }

        // Grabs a random character from the data store and puts it inbetween scale level min and max
        public Character GetRandomCharacter(int ScaleLevelMin, int ScaleLevelMax)
        {
            var myCharacterViewModel = CharactersViewModel.Instance;

            var rnd = HelperEngine.RollDice(1, myCharacterViewModel.Dataset.Count);

            var myData = new Character(myCharacterViewModel.Dataset[rnd - 1]);

            // Help identify which Character it is...
            myData.Name += " " + (1 + CharacterList.Count).ToString();

            var rndScale = HelperEngine.RollDice(ScaleLevelMin, ScaleLevelMax);
            myData.ScaleLevel(rndScale);

            // Add Items...
            myData.Head = ItemsViewModel.Instance.ChooseRandomItemString(ItemLocationEnum.Head, AttributeEnum.Unknown);
            myData.Necklass = ItemsViewModel.Instance.ChooseRandomItemString(ItemLocationEnum.Necklass, AttributeEnum.Unknown);
            myData.PrimaryHand = ItemsViewModel.Instance.ChooseRandomItemString(ItemLocationEnum.PrimaryHand, AttributeEnum.Unknown);
            myData.OffHand = ItemsViewModel.Instance.ChooseRandomItemString(ItemLocationEnum.OffHand, AttributeEnum.Unknown);
            myData.RightFinger = ItemsViewModel.Instance.ChooseRandomItemString(ItemLocationEnum.RightFinger, AttributeEnum.Unknown);
            myData.LeftFinger = ItemsViewModel.Instance.ChooseRandomItemString(ItemLocationEnum.LeftFinger, AttributeEnum.Unknown);
            myData.Feet = ItemsViewModel.Instance.ChooseRandomItemString(ItemLocationEnum.Feet, AttributeEnum.Unknown);

            return myData;
        }

        // Runs through auto battle until all characters are dead
        public bool AutoBattle()
        {
            // Auto Battle, does all the steps that a human would do.

            // Picks 6 Characters
            if (AddCharactersToBattle() == false)
            {
                // Error, so exit...
                return false;
            }

            // Start
            StartBattle(true);

            Debug.WriteLine("Battle Start" + " Characters :" + CharacterList.Count);

            // Initialize the Rounds
            StartRound();

            RoundEnum RoundResult;

            // Fight Loop. Continue until Game is Over...
            do
            {
                // Do the turn...
                RoundResult = RoundNextTurn();

                // If the round is over start a new one...
                if (RoundResult == RoundEnum.NewRound)
                {
                    NewRound();
                    Debug.WriteLine("New Round :" + BattleScore.RoundCount);
                }

            } while (RoundResult != RoundEnum.GameOver);

            EndBattle();

            Debug.WriteLine(
                "Battle Ended" +
                " Total Experience :" + BattleScore.ExperienceGainedTotal +
                " Rounds :" + BattleScore.RoundCount +
                " Turns :" + BattleScore.TurnCount +
                " Monster Kills :" + BattleScore.MonstersKilledList
                );

            return true;
        }

        // Check Character List, if empty battle over
        // Check Monster List, if empty Round Over, then New Round

        // Round Over
        // Clear Monsters
        // Drop Items to Pool
        // Allow Pickup of Items from Pool

        // New Round
        // Item pool is empty
        // Monster List is new
        // Start Round

        // Start Round
        // Choose Attack Order
        // Walk Attack Order
        // Take Turn A attacks B

    }
}
