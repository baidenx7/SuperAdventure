﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        // create lists
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();
        //Link quests with IDs for them
        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;
        //Link monsters with IDs for them
        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;
        //Link items with IDs for them
        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
        //Link locations with IDs for them
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMIST_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;
        public const int LOCATION_ID_BLACKSMITH = 10;

        static World()
        {
            //populates lists at the startup of the game
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            //adds items to the Item list, as well as some information pertaining to said items
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty_sword", "Rusty swords" , 0, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat tail", "Rat tails "));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake fang", "Snake fangs"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins"));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing potions", "Healing potion", 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG,  "Spider fang", "Spider fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK,  "Spider silk", "Spider silks"));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer pass", "Adventurer passes")); 
        }
         private static void PopulateMonsters()
         {
             //this part has some information pertaining to said monsters
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 5, 3, 10, 3, 3);
             rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
             rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));
            
            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 5, 3, 10, 3, 3);
             snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
             snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));
             
            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant spider", 20, 5, 40, 10, 10);
             giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
             giantSpider.LootTable.Add(new LootItem( ItemByID(ITEM_ID_SPIDER_SILK), 25, false));
            //this part adds them to the list
            Monsters.Add(rat);
            Monsters.Add(snake); 
            Monsters.Add(giantSpider);    
    }
            private static void PopulateQuests()
            {   

                //this part creates quests
                Quest clearAlchemistGarden = new Quest(QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden", 
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);
                
                clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));
                
                clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);
                
                Quest clearFarmersField = new Quest(QUEST_ID_CLEAR_FARMERS_FIELD, "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);
                
                clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));
                
                clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS); 
                //this part adds them to the list
                Quests.Add(clearAlchemistGarden);
                Quests.Add(clearFarmersField);      
            }

          private static void PopulateLocations()
          { 
              // Create each location
              Location home = new Location(LOCATION_ID_HOME, "Home",
                  "Your house. You really need to clean up the place.");

              Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square",
                  "You see a fountain.");

              Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut",
                  "There are many strange plants on the shelves."); 
              alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN); 
              
              Location alchemistGarden = new Location(LOCATION_ID_ALCHEMIST_GARDEN, "Alchemist's garden", 
                  "Many plants are growing here.");
              alchemistGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT); 
              
              Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse",
                  "There is a small farmhouse, with a farmer in front."); 
              farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD); 
              
              Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", 
                  "You see rows of vegetables growing here.");
              farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);
 
              Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", 
                  "There is a large, tough-looking guard here.", 
                  ItemByID(ITEM_ID_ADVENTURER_PASS)); 

              Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge",
                  "A stone bridge crosses a wide river.");
              
              Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest",
                  "You see spider webs covering covering the trees in this forest."); 
              spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

              Location blackSmith = new Location(LOCATION_ID_BLACKSMITH, "Blacksmith",
                  "You see A burly man pounding on a mishappen peice of glowing metal");
              ItemByID(ITEM_ID_ADVENTURER_PASS); 
              
              // Link the locations together
              home.LocationToNorth = townSquare;
              home.LocationToSouth = blackSmith;

              townSquare.LocationToNorth = alchemistHut;
              townSquare.LocationToSouth = home; 
              townSquare.LocationToEast = guardPost;
              townSquare.LocationToWest = farmhouse; 

              farmhouse.LocationToEast = townSquare;
              farmhouse.LocationToWest = farmersField;
              
              farmersField.LocationToEast = farmhouse; 
              
              alchemistHut.LocationToSouth = townSquare; 
              alchemistHut.LocationToNorth = alchemistGarden; 
              
              alchemistGarden.LocationToSouth = alchemistHut; 
              
              guardPost.LocationToEast = bridge; 
              guardPost.LocationToWest = townSquare;
              
              bridge.LocationToWest = guardPost; 
              bridge.LocationToEast = spiderField; 
             
              spiderField.LocationToWest = bridge;

              blackSmith.LocationToNorth = home;
              
              // Add the locations to the static list
              
              Locations.Add(home); 
              Locations.Add(townSquare);
              Locations.Add(guardPost);
              Locations.Add(alchemistHut);
              Locations.Add(alchemistGarden);
              Locations.Add(farmhouse); 
              Locations.Add(farmersField);
              Locations.Add(bridge);
              Locations.Add(spiderField);
              Locations.Add(blackSmith);
          }
        //the following functions take the id pushing into their individual page/class (.cs), which was converted into ID, and return a list of those items
        public static Item ItemByID(int id)
        {
            foreach(Item item in Items) 
            {
                if(item.ID == id)
                { 
                    return item; 
                }
            } 
            
            return null;
        } 
        
        public static Monster MonsterByID(int id) 
        {
            foreach(Monster monster in Monsters) 
            {
                if(monster.ID == id)
                {
                    return monster; 
                } 
            } 
            return null; 
        }
        public static Quest QuestByID(int id)
        {
            foreach(Quest quest in Quests) 
            {
                if(quest.ID == id)
                {
                    return quest;
                } 
            } 
            
            return null; 
        } 
        
        public static Location LocationByID(int id) 
        { 
            foreach(Location location in Locations) 
            {
                if(location.ID == id)
                {
                    return location; 
                }
            }
            
            return null; 
        
        } 
    } 
}