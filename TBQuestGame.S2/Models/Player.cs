using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.S2.Models;

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
        private List<Location> _locationsVisited;

        







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

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            LocationsVisited = new List<Location>();
        }

        #endregion


    }
}
