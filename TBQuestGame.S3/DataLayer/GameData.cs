using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.S2.Models;
using System.Collections.ObjectModel;


namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Venn",
                Age = 25,
                Status = Player.SocialStatus.Servant,
                Race = Character.RaceType.Human,
                Health= 85,
                Mana = 85,
                ExperiencePoints = 0,
                LocationId = 0,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(202),1),
                    new GameItemQuantity(GameItemById(201),1),
                    new GameItemQuantity(GameItemById(301),1)
                }

            };
        }
        public static Map GameMap()
        {
            

            Map gameMap = new Map();

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations = new ObservableCollection<Location>()
            {
               
                new Location()
                {
                    ID = 1,
                    Name="Central Park",
                    Description="Central Park is the largest park in New York City itself."+
                    "In the current year of 2029, it is now but shell of its former self." +
                    "The park now only sees visitors that number in the single digits," +
                    "thanks to a boom in technology. It is here that you receive the Emergency"+
                    "Alert declaring a terrorist attack on the largely populated city",
                    Accessible=true,
                    ModifyExperiencePoints=0,
                    ModifyHealth=0,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(101),1),
                        new GameItemQuantity(GameItemById(201),1),
                        new GameItemQuantity(GameItemById(303),10)
                    }
                    
                },

                new Location()
                {
                    ID = 2,
                    Name="Times Square",
                    Description="One of the most popular sights in all of the world, it is often a calm," +
                    "but busy area. Today it is filled with panick as people rush home to their loved ones",
                    Accessible=true,
                    ModifyExperiencePoints=15,
                    ModifyHealth=0,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(104),1),
                        new GameItemQuantity(GameItemById(201),1),
                        new GameItemQuantity(GameItemById(302),3)
                    }
                }
            };
            
            return gameMap;
        }

        public static Location InitialGameMapLocation()
        {
            return new Location()
            {
                ID = 1,
                Name = "Central Park",
                Description = "Central Park is the largest park in New York City itself." +
                    "In the current year of 2029, it is now but shell of its former self." +
                    "The park now only sees visitors that number in the single digits," +
                    "thanks to a boom in technology. It is here that you receive the Emergency" +
                    " Alert declaring a terrorist attack on the largely populated city",
                Accessible = true,
                ModifyExperiencePoints = 0,
                ModifyHealth = 0,
                GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(101),1),
                        new GameItemQuantity(GameItemById(201),1),
                        new GameItemQuantity(GameItemById(303),10)
                    }
            };

        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapons(101, "Rusted Dagger", 5, 5, 10, "A rusted dagger that is past its prime. It can be used, but is beyond repair.", 5),
                new Weapons(102, "Shortsword", 15, 20, 30, "A solid weapon of choice. Its shine in the light of torches shows minimal use, allowing for sufficent damage.", 10),
                new Weapons(103, "Short Staff", 10, 15, 20, "A 3ft rod of solid oak wood with a ruby seated at the top.", 10),
                new Weapons(104, "Steel Dagger", 15, 10, 15, "A compact dagger that is able to inflict more damage than its rusted relative. The dagger is compact enough to be stealthily hidden from the sight of enemies", 10),
                new Weapons(105, "Short Bow", 10, 20, 40, "A short bow made of oak for a sturdy frame. This weapon is capable of massive damage reliant on the area of the body struck.", 10),
                new Potions(201, "Lesser Health Potion", 10, 15, 0, "A potion that is capable of replenishing a small amount of health. Made by the elves who are known for their great knowledge of healing medicines.", 5),
                new Potions(202, "Lesser Mana Potion", 10, 0, 15, "A potion that has the ability to replenish a small amount of mana. Made by recovering ancient magical waters from the Illithi Forest's hidden spring.", 5),
                new Potions(203, "Greater Health Potion", 20, 40, 0, "A potion that is much more potent than its weaker counterpart.", 10),
                new Potions(204, "Greater Mana Potion", 20, 0, 40, "A potion that replenishes much more mana than its weaker counterpart.",10),
                new Potions(205, "Rejunenating Waters", 40, 40, 40, "An Extremely rare and potent potion that is able to double up by replenishing significant mana and health.", 20),
                new Treasure(301, "Gold Schell", 15, Treasure.TreasureType.COIN, "A gold coin that is of the common currency of the land.", 1),
                new Treasure(302, "Silver Schell",5, Treasure.TreasureType.COIN, "A silver coin that is used as a currency.",1),
                new Treasure(303, "Copper Schell", 1, Treasure.TreasureType.COIN, "A copper coin that is much less valuable than the other forms of Schell.",1),
                new Treasure(304, "Blood Ruby", 20, Treasure.TreasureType.JEWLERY, "A small ruby with a blood-red color.", 5),
                new Keys(401, "Skeleton Key", 15, Keys.UseActionType.OPENLOCATION, "A key with a skull on the end of it. It is said that this key can open almost any location. It does however have its restrictions", 5),
                

            };
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

    }


}
