using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class GameItem
    {
        #region FIELDS
        private int _id;
        private string _name;
        private int _value;
        private string  _description;
        private int _experiencePoints;
        private string _useMessage;



        #endregion

        #region PROPERTIES
        public string UseMessage
        {
            get { return _useMessage; }
            set { _useMessage = value; }
        }



        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region METHODS
        public virtual string InformationString()
        {
            return $"{Name}: {Description}/nValue: {Value}";
        }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public GameItem(int id, string name, int value, string description, int experiencePoints, string useMessage ="")
        {
            Id = id;
            Name = name;
            Value = value;
            Description = description;
            ExperiencePoints = experiencePoints;
            UseMessage = useMessage;

        }
        #endregion
    }
}
