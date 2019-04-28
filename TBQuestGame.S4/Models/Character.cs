using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.S2;

namespace TBQuestGame.Models
{
    public class Character : ObservableObjects
    {
        #region ENUMS
        public enum RaceType
        {
            Human,
            Elf, 
            Dwarf,
            Orc,
            Spider,
            Troll,
            Goblin, 
        }
        #endregion

        #region Fields
        protected int _id;
        protected string _name;
        protected int _health;
        protected RaceType _race;
        protected int _age;
        protected int _locationId;
        protected int _mana;

        protected Random random = new Random();

        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Health
        {
            get { return _health; }
            set {
                    _health = value;
                OnPropertyChanged(nameof(Health));
                }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public int Mana
        {
            get { return _mana; }
            set {
                    _mana = value;
                OnPropertyChanged(nameof(Mana));
                }
        }

        #endregion

        #region Constructors
        public Character()
        {

        }

        

        public Character(string name, RaceType race, int locationId)
        {
            _name = name;
            _race = race;
            _locationId = locationId;
        }

        public Character(int id, string name, RaceType race)
        {
            Id = id;
            Name = name;
            Race = race;
        }
        #endregion

        #region Methods
        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I am a {_race}";
        }


        
        #endregion
    }
}
