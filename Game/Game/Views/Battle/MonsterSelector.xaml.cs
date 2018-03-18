using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameEngine;
using Game.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Battle
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonsterSelector : ContentPage
	{
	    public string MonsterId { get; set; }
		public MonsterSelector (List<Monster> monsterList)
		{
		    BindingContext = monsterList;
			InitializeComponent ();
		}

	    public async void OnMonsterSelectSubmit(object sender, SelectedItemChangedEventArgs e)
	    {
	        MonsterId = e.ToString();
	        await Navigation.PopAsync();
        }
	}
}