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
		public ManualBattlePage ()
		{
			InitializeComponent ();
            var myBattleEngine = new BattleEngine();
        }

        private async void ManualBattleButton_Command(object sender, EventArgs e)
        {
            
        }
    }
}