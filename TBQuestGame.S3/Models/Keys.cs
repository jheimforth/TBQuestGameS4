using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Keys : GameItem
    {
        public enum UseActionType
        {
            OPENLOCATION,
            DAMAGEPLAYER
        }

        public UseActionType UseAction { get; set; }

        public Keys(int id, string name, int value, UseActionType useAction, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            UseAction = useAction;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }
    }
}

