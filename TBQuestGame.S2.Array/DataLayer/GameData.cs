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

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 5;
            int columns = 5;

            Map GameMap = new Map(rows, columns);

            GameMap.MapLocations[0, 0] = new Location()
            {
                ID = 1,
                Name = "Central Park",
                Description = "Central Park is the largest park in New York City itself." +
                    "In the current year of 2029, it is now but shell of its former self." +
                    "The park now only sees visitors that number in the single digits," +
                    "thanks to a boom in technology. It is here that you receive the Emergency" +
                    "Alert declaring a terrorist attack on the largely populated city",
                Accessible = true,
                ModifyExperiencePoints = 0,
                ModifyHealth = 0
            };

            GameMap.MapLocations[0, 1] = new Location()
            {
                ID = 2,
                Name = "Times Square",
                Description = "One of the most popular sights in all of the world, it is often a calm," +
                    "but busy area. Today it is filled with panick as people rush home to their loved ones",
                Accessible = true,
                ModifyExperiencePoints = 15,
                ModifyHealth = 0
            };


            return GameMap;
        }
    }
}
