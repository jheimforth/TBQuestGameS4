using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.S2.Models;
using System.Collections.ObjectModel;
namespace TBQuestGame.Models
{
    public class Player : Character
    {
        #region Enums
        public enum SocialStatus
        {
            UpperClass,
            MiddleClass,
            LowerClass,
            Servant
        }

        #endregion

        #region Fields
        private SocialStatus _status;
        private int _experiencePoints;
        private int _wealth;

        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _potions;
        private ObservableCollection<GameItemQuantity> _keys;
        private ObservableCollection<GameItemQuantity> _treasure;
        private ObservableCollection<GameItemQuantity> _weapons;



        #endregion

        #region Properties
        public SocialStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public ObservableCollection<GameItemQuantity> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItemQuantity> Treasure
        {
            get { return _treasure; }
            set { _treasure = value; }
        }


        public ObservableCollection<GameItemQuantity> Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }


        public ObservableCollection<GameItemQuantity> Potions
        {
            get { return _potions; }
            set { _potions = value; }
        }

        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }


        public int Wealth
        {
            get { return _wealth; }
            set {
                      _wealth = value;
                OnPropertyChanged(nameof(Wealth));
                }
        }


        #endregion

        #region Methods
        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(_race.ToString().Substring(0, 1))) ;
            {
                article = "an";
            }

            return $"Hello, my name is {_name} and I am {article} {_race}.";
        }

        public void UpdateInventoryCategories()
        {
            Potions.Clear();
            Weapons.Clear();
            Treasure.Clear();
            Keys.Clear();

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Potions) Potions.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Weapons) Weapons.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Treasure) Treasure.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Keys) Keys.Add(gameItemQuantity);
            }
        }

        // Add a game item to inventory 

        public void AddGameItemtoInventory(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }


        //Removes an Item from the players inventory
        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();

        }

        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i.Value);
        }
        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            LocationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _treasure = new ObservableCollection<GameItemQuantity>();
            _potions = new ObservableCollection<GameItemQuantity>();
            _keys = new ObservableCollection<GameItemQuantity>();
        }

        #endregion


    }
}
