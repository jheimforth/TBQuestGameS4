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
using static TBQuestGame.Models.BattleModeEnum;

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
        private NPC _currentNPC;
       

        






        private Random random = new Random();





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
            set {
                    _currentGameItem = value;
                    OnPropertyChanged(nameof(CurrentGameItem));
                    if (_currentGameItem.GameItem is Weapons)
                    {
                    _player.CurrentWeapon = _currentGameItem.GameItem as Weapons;
                    }
                }
        }

        public NPC CurrentNPC
        {
            get { return _currentNPC; }
            set { _currentNPC = value; }
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

        public void OnPlayerTalkTo()
        {
            if (CurrentNPC != null && CurrentNPC is ISpeak)
            {
                ISpeak speakingNpc = CurrentNPC as ISpeak;
                CurrentLocationName = speakingNpc.Speak();
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
            _player.Stamina += potions.StaminaChange;
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

        private BattleModeName NPCBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.Retreat;

            switch (DieRoll(3))
            {
                case 1:
                    npcBattleResponse = BattleModeName.Attack;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.Defend;
                    break;
                case 3:
                    npcBattleResponse = BattleModeName.Retreat;
                    break;
                default:
                    break;
            }
            return npcBattleResponse;
        }

        private int CalculatePlayerHitPoints()
        {
            int playerHitPoints = 0;

            switch (_player.BattleMode)
            {
                case BattleModeName.Attack:
                    playerHitPoints =_player.Attack();
                    break;
                case BattleModeName.Defend:
                    playerHitPoints = _player.Defend();
                    break;
                case BattleModeName.Retreat:
                    playerHitPoints = _player.Defend();
                    break;
                default:
                    break;
            }
            return playerHitPoints;
        }

        private int CalculateNPCHitPoints(IBattle battleNPC)
        {
            int battleNPCHitPoints = 0;

            switch (NPCBattleResponse())
            {
                case BattleModeName.Attack:
                    battleNPCHitPoints = battleNPC.Attack();
                    break;
                case BattleModeName.Defend:
                    battleNPCHitPoints = battleNPC.Defend();
                    break;
                case BattleModeName.Retreat:
                    battleNPCHitPoints = battleNPC.Retreat();
                    break;
                default:
                    break;
            }
            return battleNPCHitPoints;
        }
        #endregion

        #region BATTLE METHOD
        private void Battle()
        {
            //
            // check to see if an NPC can battle
            //
            if (_currentNPC is IBattle)
            {
                IBattle battleNpc = _currentNPC as IBattle;
                int playerHitPoints = 0;
                int battleNpcHitPoints = 0;
                string battleInformation = "";

                
                if (_player.CurrentWeapon != null)
                {
                    playerHitPoints = CalculatePlayerHitPoints();
                }
                else
                {
                    battleInformation = "It appears you are entering into battle without a weapon." + Environment.NewLine;
                }

                if (battleNpc.CurrentWeapon != null)
                {
                    battleNpcHitPoints = CalculateNPCHitPoints(battleNpc);
                }
                else
                {
                    battleInformation = $"It appears you are entering into battle with {_currentNPC.Name} who has no weapon." + Environment.NewLine;
                }

              
                battleInformation +=
                    $"Player: {_player.BattleMode}     Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNpc.BattleMode}     Hit Points: {battleNpcHitPoints}" + Environment.NewLine;

               
              
                if (playerHitPoints >= battleNpcHitPoints)
                {
                    battleInformation += $"You have slain {_currentNPC.Name}.";
                    _currentLocation.Npc.Remove(_currentNPC);
                    _player.ExperiencePoints += 10;
                }
                else
                {
                    battleInformation += $"You have been slain by {_currentNPC.Name}.";
                    _player.Lives--;
                }

                CurrentLocationName = battleInformation;
                if (_player.Lives <= 0) OnPlayerDies("You have been slain and have no lives left.");
            }
            

        }
        
        private void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.Attack;
            Battle();
        }

        private void OnPlayerDefend()
        {
            _player.BattleMode = BattleModeName.Defend;
            Battle();
        }

        private void OnPlayerRetreat()
        {
            _player.BattleMode = BattleModeName.Retreat;
            Battle();
        }
        #endregion

        #region HELPER METHODS 



        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }


        #endregion
    }


}
