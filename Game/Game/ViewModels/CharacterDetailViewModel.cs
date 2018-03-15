using Game.Models;

namespace Game.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        public Character Data { get; set; }
        public CharacterDetailViewModel(Character data = null)
        {
            Title = data?.Name;
            Data = data;
        }
    }
}
