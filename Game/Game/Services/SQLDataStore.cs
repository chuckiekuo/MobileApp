using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;

namespace Game.Services
{
    public sealed class SQLDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static SQLDataStore _instance;

        public static SQLDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLDataStore();
                }
                return _instance;
            }
        }

        private SQLDataStore()
        {
            CreateTables();
        }

        // Create the Database Tables
        private void CreateTables()
        {
            App.Database.CreateTableAsync<Item>().Wait();
            App.Database.CreateTableAsync<BaseCharacter>().Wait();
            App.Database.CreateTableAsync<BaseMonster>().Wait();
            App.Database.CreateTableAsync<Score>().Wait();

        }

        // Delete the Datbase Tables by dropping them
        private void DeleteTables()
        {
            App.Database.DropTableAsync<Item>().Wait();
            App.Database.DropTableAsync<BaseCharacter>().Wait();
            App.Database.DropTableAsync<BaseMonster>().Wait();
            App.Database.DropTableAsync<Score>().Wait();
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            MonstersViewModel.Instance.SetNeedsRefresh(true);
            CharactersViewModel.Instance.SetNeedsRefresh(true);
            ScoresViewModel.Instance.SetNeedsRefresh(true);
        }

        public void InitializeDatabaseNewTables()
        {
            // Delete the tables
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitilizeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();
        }

        private async void InitilizeSeedData()
        {

            await AddAsync_Item(new Item { Name = "First item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Name = "Second item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Name = "Third item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Name = "Fourth item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Name = "Fifth item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Name = "Sixth item", Description = "This is an item description." });


            await AddAsync_Character(new Character { Name = "First Character", Description="This is an Character description.", Level = 1 });
            await AddAsync_Character(new Character { Name = "Second Character", Description="This is an Character description." , Level = 1});
            await AddAsync_Character(new Character { Name = "Third Character", Description="This is an Character description." , Level = 2});
            await AddAsync_Character(new Character { Name = "Fourth Character", Description="This is an Character description." , Level = 2});
            await AddAsync_Character(new Character { Name = "Fifth Character", Description="This is an Character description." , Level = 3});
            await AddAsync_Character(new Character { Name = "Sixth Character", Description="This is an Character description." , Level = 3});

            await AddAsync_Monster(new Monster { Name = "First Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Name = "Second Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Name = "Third Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Name = "Fourth Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Name = "Fifth Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Name = "Sixth Monster", Description="This is an Monster description." });

            await AddAsync_Score(new Score { Name = "First Score", ScoreTotal= 111});
            await AddAsync_Score(new Score { Name = "Second Score", ScoreTotal= 222 });
            await AddAsync_Score(new Score { Name = "Third Score", ScoreTotal= 333});
            await AddAsync_Score(new Score { Name = "Fourth Score", ScoreTotal = 444 });
            await AddAsync_Score(new Score { Name = "Fifth Score", ScoreTotal = 555 });
            await AddAsync_Score(new Score { Name = "Sixth Score", ScoreTotal = 666 });

        }

        #region Item
        // Item

        // Add InsertUpdateAsync_Item Method

        // Check to see if the item exists
        // Add your code here.

        // If it does not exist, then Insert it into the DB
        // Add your code here.
        // return true;

        // If it does exist, Update it into the DB
        // Add your code here
        // return true;

        // If you got to here then return false;

        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                // If it does not exist, add it to the DB
                var InsertResult = await AddAsync_Item(data);
                if (InsertResult)
                {
                    return true;
                }

                return false;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            var result = await App.Database.InsertAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            // Need to add a try catch here, to catch when looking for something that does not exist in the db...
            try
            {
                var result = await App.Database.GetAsync<Item>(id);
                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            var result = await App.Database.Table<Item>().ToListAsync();
            return result;
        }
        #endregion Item

        #region Character
        // Character

        // Conver to BaseCharacter and then add it
        public async Task<bool> AddAsync_Character(Character data)
        {
            // Convert Character to CharacterBase before saving to Database
            var dataBase = new BaseCharacter(data);

            var result = await App.Database.InsertAsync(dataBase);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        // Convert to BaseCharacter and then update it
        public async Task<bool> UpdateAsync_Character(Character data)
        {
            var dataBase = new BaseCharacter(data);
            var result = await App.Database.UpdateAsync(dataBase);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        // Pass in the character and convert to Character to then delete it
        public async Task<bool> DeleteAsync_Character(Character data)
        {
            var dataBase = new BaseCharacter(data);

            var result = await App.Database.DeleteAsync(dataBase);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        // Get the Character Base, and Load it back as Character
        public async Task<Character> GetAsync_Character(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var dataBase = await App.Database.GetAsync<BaseCharacter>(id);

            var result = new Character(dataBase);

            return result;
        }

        // Load each character as the base character, 
        // Then then convert the list to characters to push up to the view model
        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            var myResult = new List<Character>();

            var DataResult = await App.Database.Table<BaseCharacter>().ToListAsync();
            foreach (var dataBaseItem in DataResult)
            {
                myResult.Add(new Character(dataBaseItem));
            }

            return myResult;
        }

        #endregion Character

        #region Monster
        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            // Convert Character to CharacterBase before saving to Database
            var dataBase = new BaseMonster(data);

            var result = await App.Database.InsertAsync(dataBase);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            var dataBase = new BaseMonster(data);
            var result = await App.Database.UpdateAsync(dataBase);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {

            var dataBase = new BaseMonster(data);

            var result = await App.Database.DeleteAsync(dataBase);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var dataBase = await App.Database.GetAsync<BaseMonster>(id);

            var result = new Monster(dataBase);

            return result;
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            var myResult = new List<Monster>();

            var DataResult = await App.Database.Table<BaseMonster>().ToListAsync();
            foreach (var dataBaseItem in DataResult)
            {
                myResult.Add(new Monster(dataBaseItem));
            }

            return myResult;
        }

        #endregion Monster

        #region Score
        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            var result = await App.Database.InsertAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<Score> GetAsync_Score(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var result = await App.Database.GetAsync<Score>(id);
            return result;
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            var result = await App.Database.Table<Score>().ToListAsync();
            return result;

        }

#endregion Score
    }
}