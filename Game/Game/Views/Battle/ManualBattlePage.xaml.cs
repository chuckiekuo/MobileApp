using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Models;
using Game.GameEngine;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Battle
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManualBattlePage : ContentPage
	{
	    private BattleEngine myBattleEngine;
		public ManualBattlePage ()
		{
		    myBattleEngine = new BattleEngine();
		    BattleEngineInit();
		    BindingContext = myBattleEngine;

            InitializeComponent();

        }

	    public void BattleEngineInit()
	    {
	        // Picks 6 Characters
	        if (myBattleEngine.AddCharactersToBattle() == false)
	        {
	            // No characters in db yet
	            // TODO: EXIT with error of no characters
	        }

	        // Start with user battle
	        myBattleEngine.StartBattle(false);

	        Debug.WriteLine("Battle Start" + " Characters :" + myBattleEngine.CharacterList.Count);

	        myBattleEngine.StartRound();

	    }

        public async void BattleEngineStart()
	    {
	        
            RoundEnum RoundResult;
	        

            // Fight Loop. Continue until Game is Over...
            do
	        {
	            PlayerInfo currentPlayer = myBattleEngine.GetNextPlayerInList();

                // Check if character or monster
                if (currentPlayer.PlayerType == PlayerTypeEnum.Character)
	            {
	                string id = "";

	                MonsterSelector myMonsterSelector = new MonsterSelector(myBattleEngine.MonsterList);

	                await Navigation.PushAsync(myMonsterSelector);

	                id = myMonsterSelector.MonsterId;

	                RoundResult = myBattleEngine.RoundNextTurn(id);
	            }

                // else monster turn
	            else
	            {
	                RoundResult = myBattleEngine.RoundNextTurn();

                    // TODO: Display damage to user
                }

                // If the round is over start a new one...
                if (RoundResult == RoundEnum.NewRound)
	            {
	                myBattleEngine.NewRound();
	                Debug.WriteLine("New Round :" + myBattleEngine.BattleScore.RoundCount);
	            }
                
	        } while (RoundResult != RoundEnum.GameOver);

	        myBattleEngine.EndBattle();

	        Debug.WriteLine(
	            "Battle Ended" +
	            " Total Experience :" + myBattleEngine.BattleScore.ExperienceGainedTotal +
	            " Rounds :" + myBattleEngine.BattleScore.RoundCount +
	            " Turns :" + myBattleEngine.BattleScore.TurnCount +
	            " Monster Kills :" + myBattleEngine.BattleScore.MonstersKilledList
	        );


        }
        private async void ManualBattleButton_Command(object sender, EventArgs e)
        {
            
        }
    }
}