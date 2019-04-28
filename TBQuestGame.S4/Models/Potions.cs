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
        public int StaminaChange { get; set; }
        public Potions(int id, string name, int value, int healthChange, int staminaChange, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            HealthChange = healthChange;
            StaminaChange = staminaChange;
        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else if (StaminaChange != 0)
            {
                return $"{Name}: {Description}\nStamina: {StaminaChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
}
