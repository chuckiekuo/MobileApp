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
	    private RoundEnum RoundResult;

        public ManualBattlePage ()
		{
		    myBattleEngine = new BattleEngine();
		    BattleEngineInit();
		    BindingContext = myBattleEngine;
		    RoundResult = RoundEnum.Unknown;

		    InitializeComponent();
		}

	    public ManualBattlePage(BattleEngine lastBattleEngine, RoundEnum lastRoundResult)
	    {
	        myBattleEngine = lastBattleEngine;
	        BindingContext = myBattleEngine;
	        RoundResult = lastRoundResult;

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

        // If UI is enabled, there will be popups that guide you through battle as you click the next turn button
        // If not, it will drop you straight to the result page
	    public async void BattleEngineStart_Command(object sender, EventArgs e)
	    {
#if !EnableUI
	        do
	        {
	            // If the round is over start a new one...
	            if (RoundResult == RoundEnum.NewRound)
	            {
	                myBattleEngine.NewRound();
	            }

	            PlayerInfo currentPlayer = myBattleEngine.GetNextPlayerInList();

	            // Check if character or monster
	            if (currentPlayer.PlayerType == PlayerTypeEnum.Character)
	            {
	                string id = null;
	                RoundResult = myBattleEngine.RoundNextTurn(id);
	            }

	            // else monster turn
	            else
	            {
	                RoundResult = myBattleEngine.RoundNextTurn();
	            }

	            Debug.WriteLine(myBattleEngine.TurnMessage);

	        } while (RoundResult != RoundEnum.GameOver);

            
#endif

#if EnableUI
            if (RoundResult != RoundEnum.GameOver)
            {
                // If the round is over start a new one...
                if (RoundResult == RoundEnum.NewRound)
                {
                    myBattleEngine.NewRound();

                    var answer = await DisplayAlert("New Round", "Begin", "Start", "Cancel");

                    if (answer)
                    {
                        await Navigation.PushAsync(new ManualBattlePage(myBattleEngine, RoundResult));
                        return;
                    }
                }

                PlayerInfo currentPlayer = myBattleEngine.GetNextPlayerInList();

                // Check if character or monster
                if (currentPlayer.PlayerType == PlayerTypeEnum.Character)
                {
                    string id = null;

                    var dataset = myBattleEngine.MonsterList.Where(a => a.Alive).ToList();

                    string[] names = new string[dataset.Count];
                    string[] IDs = new string[dataset.Count];

                    int ctr = 0;

                    foreach (var data in dataset)
                    {
                        names[ctr] = data.Name;
                        IDs[ctr] = data.Guid;
                        ctr++;
                    }

                    var action = await DisplayActionSheet("Select Monster", null, null, names);

                    ctr = 0;

                    foreach (var data in dataset)
                    {
                        if (action == data.Name)
                        {
                            id = IDs[ctr];
                            break;
                        }

                        ctr++;
                    }

                  RoundResult = myBattleEngine.RoundNextTurn(id);
                }

                // else monster turn
                else
                {
                    RoundResult = myBattleEngine.RoundNextTurn();
                }

               
                 var response = await DisplayAlert("Turn Result", myBattleEngine.TurnMessage, "Continue", "Quit");

                    if (!response)
                    {
                        await Navigation.PushAsync(new OpeningPage());
                    }
                
            }
            
#endif

            if (RoundResult == RoundEnum.GameOver)
	        {
	            myBattleEngine.EndBattle();

	            string result =
	                "Battle Ended" +
	                " Total Experience :" + myBattleEngine.BattleScore.ExperienceGainedTotal +
	                " Rounds :" + myBattleEngine.BattleScore.RoundCount +
	                " Turns :" + myBattleEngine.BattleScore.TurnCount +
	                " Monster Kills :" + myBattleEngine.BattleScore.MonstersKilledList;

	            var answer = await DisplayAlert("Game Result", result, "Set Name", "Restart");

	            if (answer)
	            {
                    // Link to enter name 
	                await Navigation.PushAsync(new EditScorePage(new ScoreDetailViewModel(myBattleEngine.BattleScore)));
	            }

	            else
	            {
	                await Navigation.PushAsync(new OpeningPage());
	            }
	        }


        }

    }


}