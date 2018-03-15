using Game.Models;

namespace Game.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Data { get; set; }
        public ItemDetailViewModel(Item data = null)
        {
            Title = data?.Name;
            Data = data;
        }
    }
}
