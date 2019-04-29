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
                Health = 100,
                Lives = 3,
                //
                //Change Mana to Stamina, make the game drain stamina everytime you walk through
                //the dungeon to a different location. Potion type to recharge stamina. 
                //Add in a revitalizing stones in place of lives.
                //
                Stamina = 100,
                ExperiencePoints = 0,
                SkillLevel = 5,
                LocationId = 0,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(202),1),
                    new GameItemQuantity(GameItemById(201),1),
                    new GameItemQuantity(GameItemById(301),1)
                }

            };
        }

        public static List<NPC> Npcs()
        {
            return new List<NPC>
            {
                new Adventurer()
                {
                    Id= 1001,
                    Name= "Jorge",
                    Age=42,
                    Health = 100,
                    Race = Character.RaceType.Dwarf,
                    SkillLevel=10,
                    Description="A lone dwarf adventurer who is short in stature but makes up for it in strength.",
                    Messages = new List<string>
                    {
                        "Ye shouldn'tve come here by yer self",
                        "Beware of this dungeon, it's not safe to go alone",
                        "The further you travel down here, the more danger that is to come."
                    }
                },
                
                new Adventurer()
                {
                    Id= 1002,
                    Name = "Vael",
                    Age = 306,
                    Health= 100,
                    Race = Character.RaceType.Elf,
                    SkillLevel = 6,
                    Description = "An ancient elven warrior who has lived to see the passing of many years.",
                    Messages = new List<string>
                    {
                        "Hello fellow adventurer!",
                        "It has been many ages since I've been in this dungeon",
                        "Good luck"
                    },
                    CurrentWeapon = GameItemById(103) as Weapons
                },

                new Monster()
                {
                    Id= 2001,
                    Name = "Gork",
                    Race= Character.RaceType.Orc,
                    Description= "A Towering monster that is able to decimate even the mightiest of mortals",
                    Messages = new List<string>
                    {
                        "Turn away now!",
                        "The Orcs have made claim to this dungeon, leave!",
                        "If you step any further I will cut you down"
                    },
                    SkillLevel = 8,
                    CurrentWeapon = GameItemById(107) as Weapons,
                    
                },

                new Monster()
                {
                    Id = 2002,
                    Name = "Sethris the Bleak",
                    Age = 232,
                    Race = Character.RaceType.Spider,
                    Description = "An ancient spider that was thought to be a legend. She has made her home in the darkest depths of this dungeon",
                    Messages = new List<string>
                    {
                        "[Clicking Noises]"
                    },
                    SkillLevel = 7,
                    CurrentWeapon = GameItemById(106) as Weapons,
                },


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
                    Name="Dungeon Entrance",
                    Description="The entrance to the dungeon lays deep in the tunnels of the old Sindoreil mountains. It is here where our adventurer's journey begins.",
                    Accessible=true,
                    ModifyExperiencePoints=0,
                    ModifyStamina =10,
                    ModifyHealth=0,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(101),1),
                        new GameItemQuantity(GameItemById(201),1),
                        new GameItemQuantity(GameItemById(303),10)
                    },
                    Npc = new ObservableCollection<NPC>
                    {
                        NPCById(1002)
                    }


                },

                new Location()
                {
                    ID = 2,
                    Name="Dungeon Main Room",
                    Description="As you enter the ancient dungeon torches light ablaze with life, illuminating the long forgotten labrynth. Surrounding you are numerous doors, but where could they lead?",
                    Accessible=true,
                    ModifyExperiencePoints=15,
                    ModifyStamina= 10,
                    ModifyHealth=0,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(104),1),
                        new GameItemQuantity(GameItemById(201),1),
                        new GameItemQuantity(GameItemById(302),3)
                    },
                    Npc = new ObservableCollection<NPC>
                    {
                        NPCById(2001),
                        NPCById(1001)

                    }
                },

                new Location()
                {
                    ID =3,
                    Name="Armory",
                    Description="The room to the right of the entrance contains archaic weapons of the past. The room is safe, but does not offer the adventurer much value",
                    ModifyExperiencePoints= 15,
                    ModifyHealth = 0,
                    ModifyStamina = 10,
                    Accessible = true,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(101),1),
                        new GameItemQuantity(GameItemById(107),1),
                        new GameItemQuantity(GameItemById(202),1)
                    },
                },

                new Location()
                {
                    ID=4, 
                    Name= "Lounge",
                    Description="The room to the left of the entrance is a room that has been revamped to become a rest area for adventurers.",
                    ModifyExperiencePoints = 15,
                    ModifyHealth = 0,
                    ModifyStamina = 10,
                    Accessible = true,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(202),1),
                        new GameItemQuantity(GameItemById(201),1)
                    }
                },

                new Location()
                {
                    ID = 5,
                    Name= "Crypts",
                    Description="As you explore deeper into the dungeon you come upon the crypts of fallen adventurers before you. As you walk through the door way, the light behind you fades and a sillhouette of a large spider appears.",
                    ModifyExperiencePoints =15,
                    ModifyHealth = 0,
                    ModifyStamina =10,
                    Accessible=true,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(106),1),
                        new GameItemQuantity(GameItemById(108),1),
                        new GameItemQuantity(GameItemById(206),1)
                    },
                    Npc = new ObservableCollection<NPC>
                    {
                        NPCById(2002)
                    }
                    
                },

                new Location()
                {
                    ID=6,
                    Name ="Dilapidated Alchemist Lab",
                    Description="You wander into an old alchemy lab that was formerly used to create potions. Due to it's location, it was most likely used to create potions that were not regulated by the kingdom due to their instability. As you wold through the archway, your bags knock a beaker to floor causing a purple gas to spread. You have been severely injured as a result.",
                    ModifyExperiencePoints = 0,
                    ModifyHealth = 50,
                    ModifyStamina = 10,
                    Accessible = true,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(203),1),
                        new GameItemQuantity(GameItemById(204),1),
                        new GameItemQuantity(GameItemById(205),1)
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
                Name = "Dungeon Entrance",
                Description = "The entrance to the dungeon lays deep in the tunnels of the old Sindoreil mountains. It is here where our adventurer's journey begins.",
                Accessible = true,
                ModifyExperiencePoints = 0,
                ModifyStamina = 10,
                ModifyHealth = 0,
                GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(101),1),
                        new GameItemQuantity(GameItemById(201),1),
                        new GameItemQuantity(GameItemById(303),10)
                    },
                Npc = new ObservableCollection<NPC>
                    {
                        NPCById(1002)
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
                new Weapons(106, "Venomous Fang", 10, 15, 20, "A venomous fang from the ancient races of spiders. Obtaining one can be quite difficult.", 10),
                new Weapons(107, "Rusted Shortsword", 7, 10, 15, "A long forgotten sword that has been damaged beyond repair. Although Damaged, it can still be of use", 5),
                new Weapons(108, "Bastard Sword", 20, 25,35, "A hulking sword in size. It requires the mightiest of warriors to wield.", 15),
                new Potions(201, "Lesser Health Potion", 10, 15, 0, 0, "A potion that is capable of replenishing a small amount of health. Made by the elves who are known for their great knowledge of healing medicines.", 5),
                new Potions(202, "Lesser Stamina Potion", 10, 0, 20, 0, "A potion that has the ability to replenish a small amount of stamina. Made by recovering ancient magical waters from the Illithi Forest's hidden spring.", 5),
                new Potions(203, "Greater Health Potion", 20, 40, 0, 0,"A potion that is much more potent than its weaker counterpart.", 10),
                new Potions(204, "Greater Stamina Potion", 20, 0, 40, 0, "A potion that replenishes much more stamina than its weaker counterpart.",10),
                new Potions(205, "Rejuvenating Waters", 40, 40, 40, 0, "An Extremely rare and potent potion that is able to double up by replenishing significant stamina and health.", 20),
                new Potions(206, "Revitalizing Stone", 50, 0, 0, 1, "Another rare object of this world that is able to bring one back to life if it's life should be lost.", 20),
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

        public static NPC NPCById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

    }


}
