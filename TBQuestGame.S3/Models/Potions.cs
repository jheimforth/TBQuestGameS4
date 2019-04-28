using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Potions : GameItem
    {

        public int HealthChange { get; set; }
        public int ManaChange { get; set; }
        public Potions(int id, string name, int value, int healthChange, int manaChange, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            HealthChange = healthChange;
            ManaChange = manaChange;
        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else if (ManaChange != 0)
            {
                return $"{Name}: {Description}\nMana: {ManaChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
}
