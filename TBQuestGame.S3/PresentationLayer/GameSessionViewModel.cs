using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.S2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TBQuestGame.S2;
using System.Windows.Data;
using System.Windows;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObjects
    {
        #region Fields
        private Player _player;
        private List<string> _messages;
        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationName;
        private ObservableCollection<Location> _accessibleLocations;
        private GameItemQuantity _currentGameItem;

      








        #endregion

        #region Properties
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
            
        }


        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                
            }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                _currentLocationName = value;
                
                OnPlayerMove();
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        

        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set { _accessibleLocations = value; }
        }

        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        #endregion

        #region Constructors
        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, Map gameMap, Location currentLocation)
        {
            _player = player;
            _gameMap = gameMap;
            _currentLocation = currentLocation;

            InitializeView();
        }

        
        private void InitializeView()
        {
            _accessibleLocations = _gameMap.AccessibleLocations;
            _player.UpdateInventoryCategories();
            _player.CalculateWealth();
        }



        #endregion

        #region METHODS

        private void OnPlayerMove()
        {
            // Sets a new location

            foreach (Location location in AccessibleLocations)
            {
                if (location.Name == _currentLocationName)
                {
                    _currentLocation = location;
                }

            }

            //_currentLocation = AccessibleLocations.FirstOrDefault(l => l.Name == _currentLocationName);

            // Modify experience points

            if (!_player.LocationsVisited.Contains(_currentLocation))
            {
                _player.ExperiencePoints += _currentLocation.ModifyExperiencePoints;
                _player.LocationsVisited.Add(_currentLocation);
            }

            

            
        }

        public void AddItemToInventory()
        {
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity);
                _player.AddGameItemtoInventory(selectedGameItemQuantity);

                OnPlayerPickUp(selectedGameItemQuantity);
            }
        }

        public void RemoveItemFromInventory()
        {
            if (_currentGameItem != null)
            {
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.AddGameItemToLocation(selectedGameItemQuantity);
                _player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }

        public void OnUseGameItem()
        {
            switch (_currentGameItem.GameItem)
            {
                case Potions potions:
                    ProcessPotionUse(potions);
                    break;
                default:
                    break;
            }
        }

        //private void ProcessKeyUse(Keys keys)
        //{
        //    string message;

        //    switch (keys.UseAction)
        //    {
        //        case Keys.UseActionType.OPENLOCATION:
        //            message = _gameMap.OpenLocationByKey(keys.Id);
                    
        //            break;
        //        case Keys.UseActionType.DAMAGEPLAYER:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void OnPlayerDies(string message)
        {
            string messagetext = message + "\n\nRestart?";

            string titleText = "Death";

            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuitApplication();
                    break;
                default:
                    break;
            }

        }

        private void ResetPlayer()
        {
            Environment.Exit(0);
        }

        private void QuitApplication()
        {
            Environment.Exit(0);
        }

        private void ProcessPotionUse(Potions potions)
        {
            _player.Health += potions.HealthChange;
            _player.Mana += potions.ManaChange;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }

        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.ExperiencePoints += gameItemQuantity.GameItem.ExperiencePoints;
            _player.Wealth += gameItemQuantity.GameItem.Value;
        }

        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth -= gameItemQuantity.GameItem.Value;
        }
        #endregion

        

    }


}
