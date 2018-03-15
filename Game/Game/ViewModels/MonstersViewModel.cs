using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Game.Models;
using Game.Views;
using System.Linq;

namespace Game.ViewModels
{
    public class MonstersViewModel : BaseViewModel
    {
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static MonstersViewModel _instance;

        public static MonstersViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MonstersViewModel();
                }
                return _instance;
            }
        }

        public ObservableCollection<Monster> Dataset { get; set; }
        public Command LoadDataCommand { get; set; }

        private bool _needsRefresh;

        public MonstersViewModel()
        {
            Title = "Monster List";
            Dataset = new ObservableCollection<Monster>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<DeleteMonsterPage, Monster>(this, "DeleteData", async (obj, data) =>
            {
                await DeleteAsync(data);
            });

            MessagingCenter.Subscribe<NewMonsterPage, Monster>(this, "AddData", async (obj, data) =>
            {
                await AddAsync(data);
            });

            MessagingCenter.Subscribe<EditMonsterPage, Monster>(this, "EditData", async (obj, data) =>
            {
                await UpdateAsync(data);
            });
        }

        // Return True if a refresh is needed
        // It sets the refresh flag to false
        public bool NeedsRefresh()
        {
            if (!_needsRefresh)
            {
                return false;
            }

            _needsRefresh = false;
            return true;
        }

        // Sets the need to refresh
        public void SetNeedsRefresh(bool value)
        {
            _needsRefresh = value;
        }

        private async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Dataset.Clear();
                var dataset = await DataStore.GetAllAsync_Monster(true);
                foreach (var data in dataset)
                {
                    Dataset.Add(data);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        public void ForceDataRefresh()
        {
            // Reset
            var canExecute = LoadDataCommand.CanExecute(null);
            LoadDataCommand.Execute(null);
        }

        #region DataOperations

        public async Task<bool> AddAsync(Monster data)
        {
            Dataset.Add(data);
            var myReturn = await DataStore.AddAsync_Monster(data);
            return myReturn;
        }

        public async Task<bool> DeleteAsync(Monster data)
        {
            Dataset.Remove(data);
            var myReturn = await DataStore.DeleteAsync_Monster(data);
            return myReturn;
        }

        public async Task<bool> UpdateAsync(Monster data)
        {
            // Find the Monster, then update it
            var myData = Dataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);
            await DataStore.UpdateAsync_Monster(myData);

            _needsRefresh = true;

            return true;
        }

        // Call to database to ensure most recent
        public async Task<Monster> GetAsync(string id)
        {
            var myData = await DataStore.GetAsync_Monster(id);
            return myData;
        }

        #endregion DataOperations

    }
}