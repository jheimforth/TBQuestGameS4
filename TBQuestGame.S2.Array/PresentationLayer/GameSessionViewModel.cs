using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObjects
    {
        #region Fields
        private Player _player;
        private List<string> _messages;
        private Map _gameMap;
        private Location _currentLocation;
        private GameMapCoordinates _initialLocationCoordinates;










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

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }


        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        #endregion

        #region Constructors
        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player,
            List<string> initialMessages,
            Map gameMap, 
            GameMapCoordinates currentLocationCoordinates)
        {
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = gameMap.CurrentLocation;
            _player = player;
            _messages = initialMessages;
        }

        public GameSessionViewModel(Player player)
        {
            _player = player;
        }

        public GameSessionViewModel(Player player, Map gameMap, GameMapCoordinates initialLocationCoordinates) : this(player)
        {
            _gameMap = gameMap;
            _initialLocationCoordinates = initialLocationCoordinates;
        }
        #endregion


    }
}
