using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Weapons : GameItem
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapons(int id, string name, int value, int minDamage, int maxDamage, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            MinDamage = minDamage;
            MaxDamage = MaxDamage;
        }


        public override string InformationString()
        {
            return $"{Name}: {Description}\nDamage: {MinDamage} - {MaxDamage}";
        }
    }
}
