using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TBQuestGame.Models.BattleModeEnum;

namespace TBQuestGame.Models
{
    interface IBattle
    {
        int SkillLevel { get; set; }
        Weapons CurrentWeapon { get; set; }
        BattleModeName BattleMode { get; set; }

        int Attack();
        int Defend();
        int Retreat();
    }
}
