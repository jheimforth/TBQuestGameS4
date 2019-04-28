using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;


namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "C43-1",
                Age = 9,
                Status = Player.SocialStatus.Servant,
                Race = Character.RaceType.Android,
                Health= 100,
                ExperiencePoints = 0,
                LocationId = 0

            };
        }
    }
}
