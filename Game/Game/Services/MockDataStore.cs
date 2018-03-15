using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;

namespace Game.Services
{
    public sealed class MockDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        private List<Item> _itemDataset = new List<Item>();
        private List<Character> _characterDataset = new List<Character>();
        private List<Monster> _monsterDataset = new List<Monster>();
        private List<Score> _scoreDataset = new List<Score>();

        private MockDataStore()
        {
            InitilizeSeedData();
        }

        private void InitilizeSeedData(){

            // Load Items.
            _itemDataset.Add(new Item("Gold Sword", "Sword made of Gold, really expensive looking", 
                "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",0,10,10, ItemLocationEnum.PrimaryHand, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Strong Shield", "Enough to hide behind", 
                "http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png",0,10, 0, ItemLocationEnum.OffHand, AttributeEnum.Attack));

            _itemDataset.Add(new Item("Bow", "Fast shooting bow", 
                "http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png", 6, 10, 10, ItemLocationEnum.PrimaryHand, AttributeEnum.Attack));

            _itemDataset.Add(new Item("Blue Ring of Power", "The one to control them all", 
                "http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png", 0,10, -1, ItemLocationEnum.LeftFinger, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Bunny Hat", "Pink hat with fluffy ears", 
                "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png", 0, 10, -1, ItemLocationEnum.Head, AttributeEnum.Speed));

            _itemDataset.Add(new Item("Strong Ring", "Ring of Hitting", 
                "http://www.vectorsland.com/imgd/l29263-brass-knuckles-logo-12136.png", 0, 10, 0, ItemLocationEnum.RightFinger, AttributeEnum.Attack));

            _itemDataset.Add(new Item("Nice Neckless", "Feel safer already", 
                "http://downloadicons.net/sites/default/files/lovely-necklace-icon-7805.png", 0,10, 0, ItemLocationEnum.Necklass, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Shoes", "Stay Away Fashion", 
                "http://www.fordesigner.com/imguploads/Image/cjbc/zcool/png20080526/1211782254.png",0, 10, -1, ItemLocationEnum.Feet, AttributeEnum.Defense));


            var mockCharacters = new List<Character>
            {
                new Character {  Name = "Fighter", Description="Good Friend", Level = 1 },
                new Character { Name = "Warrior", Description="Strong Warrior" , Level = 1},
                new Character { Name = "Thief", Description="Ninja" , Level = 2},
            };

            foreach (var data in mockCharacters)
            {
                _characterDataset.Add(data);
            }

            var mockMonsters = new List<Monster>
            {
                new Monster { Name = "Rat", Description="Small but vicious" },
                new Monster { Name = "Wolf", Description="Loner" },
                new Monster { Name = "Lion", Description="Always Hungry" },
            };

            foreach (var data in mockMonsters)
            {
                _monsterDataset.Add(data);
            }

            var mockScores = new List<Score>
            {
                new Score { Name = "First Score", ScoreTotal = 111},
                new Score { Name = "Second Score", ScoreTotal = 222},
                new Score { Name = "Third Score", ScoreTotal = 333},
            };

            foreach (var data in mockScores)
            {
                _scoreDataset.Add(data);
            }
        }

        private void CreateTables()
        {
            // Do nothing...
        }

        // Delete the Datbase Tables by dropping them
        public void DeleteTables()
        {
            _itemDataset.Clear();
            _characterDataset.Clear();
            _monsterDataset.Clear();
            _scoreDataset.Clear();
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
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitilizeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();
        }

        // Item
        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                _itemDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                await AddAsync_Item(data);
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            _itemDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _itemDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(_itemDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(_itemDataset);
        }


        // Character
        public async Task<bool> AddAsync_Character(Character data)
        {
            _characterDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            var myData = _characterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            var myData = _characterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _characterDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            return await Task.FromResult(_characterDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            return await Task.FromResult(_characterDataset);
        }


        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            _monsterDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            var myData = _monsterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
            var myData = _monsterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _monsterDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            return await Task.FromResult(_monsterDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            return await Task.FromResult(_monsterDataset);
        }

        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            _scoreDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            var myData = _scoreDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            var myData = _scoreDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _scoreDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Score> GetAsync_Score(string id)
        {
            return await Task.FromResult(_scoreDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            return await Task.FromResult(_scoreDataset);
        }

    }
}