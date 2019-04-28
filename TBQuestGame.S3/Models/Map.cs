using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TBQuestGame.Models;

namespace TBQuestGame.S2.Models
{
    public class Map
    {
        #region FIELDS
        private ObservableCollection<Location> _locations;
        private Location _currentLocation;
        private List<GameItem> _standardGameItems;

       





        #endregion

        #region PROPERTIES

        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        public ObservableCollection<Location> AccessibleLocations
        {
            get
            {
                ObservableCollection<Location> accessibleLocations = new ObservableCollection<Location>();
                foreach (var location in _locations)
                {
                    if (location.Accessible == true)
                    {
                        accessibleLocations.Add(location);
                    }
                }
                return accessibleLocations;
            }
        }

        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }
        #endregion

        #region METHODS
        public void Move(Location location)
        {
            _currentLocation = location;
        }

        public GameItem GetItemById(int id)
        {
            return StandardGameItems.FirstOrDefault(i => i.Id == id);
        }

        public string OpenLocationByKey(int keyId)
        {
            string message = "The key did nothing.";
            Location mapLocation = new Location();

            if (CurrentLocation.RequiredKeyId != keyId)
            {
                
            }
            return message;
        }
        #endregion



    }
}
