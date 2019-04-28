using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TBQuestGame.Models;

namespace TBQuestGame.S2.Models
{
    public class Location
    {
        #region FIELDS
        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _modifyExperiencePoints;
        private int _modifyHealth;
        private int _requiredKeyId;
        private ObservableCollection<GameItemQuantity> _gameItems;

        







        #endregion

        #region PROPERTIES
        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }


        public int ModifyExperiencePoints
        {
            get { return _modifyExperiencePoints; }
            set { _modifyExperiencePoints = value; }
        }


        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        public int RequiredKeyId
        {
            get { return _requiredKeyId; }
            set { _requiredKeyId = value; }
        }

        public ObservableCollection<GameItemQuantity> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }


        #endregion

        #region CONSTRUCTORS
        public Location()
        {
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }

        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
        }

        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedLocationGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedLocationGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedLocationGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }

        public void AddGameItemToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _gameItems.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateLocationGameItems();
        }

        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _gameItems.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateLocationGameItems();
        }

        #endregion
    }
}
