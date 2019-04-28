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

        #endregion


    }

   
}
