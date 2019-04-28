using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }

        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }


        public NPC()
        {

        }

        public NPC(int id, string name, RaceType race, string description)
            : base(id, name, race)
        {
            Id = id;
            Name = name;
            Race = race;
            Description = description;
        }







        protected abstract string InformationText();
    }
}
