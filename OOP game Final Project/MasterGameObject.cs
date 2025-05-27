using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class MasterGameObject
    {
        public List<IItem> MetaDataItem { get; private set; }
        public List<IEntity> MetaDataTEntity { get; private set; }

        public List<Boss> MetaDataBoss { get; private set; }

        public List<PlayerClass> MetaDataPlayerClass { get; private set; }
        public List<Menu> Menus { get; private set; }

        public MasterGameObject()
        {
            MetaDataItem = new List<IItem>();
            MetaDataTEntity = new List<IEntity>();
            MetaDataPlayerClass = new List<PlayerClass>();
            MetaDataBoss = new List<Boss>();
            Menus = new List<Menu>();
            MakeAllMetaData();
        }
        enum NameAndId
        {
            Sword=1,
            Longsword=2,
            Battle_axe=7,
            Heavy_plated_armour=3,
            Light_armour=4,
            Chainmail=5,
            Cloth_armour=6
        }



        public void MakeAllMetaData()
        {

            MetaDataItem.Add(new Weapon("Sword", 1, 25, new int[] { 10, 10, 10, 10, 10, 7 }, 200));
            MetaDataItem.Add(new Weapon("Longsword", 2, 25, new int[] { 15, 13, 10, 10, 12, 7 }, 500));
            MetaDataItem.Add(new Weapon("Battle axe", 7, 35, new int[] { 17, 10, 10, 10, 12, 7 },750));
            MetaDataItem.Add(new Weapon("Canoe", 8, 35, new int[] { 20, 10, 10, 10, 12, 7 }, 750));


            MetaDataItem.Add(new Armour("Heavy plated armour", 3, 0.35f, 15, new int[] { 15, 13, 10, 10, 12, 7 },1000)); 
            MetaDataItem.Add(new Armour("Light armour", 4, 0.1f, 10, new int[] { 12, 10, 10, 10, 10, 7 },500));
            MetaDataItem.Add(new Armour("Chainmail", 5, 0.20f, 12, new int[] { 10, 10, 10, 10, 10, 7 },750));
            MetaDataItem.Add(new Armour("Cloth armour", 6, 0.05f, 8,new int[] { 5, 5, 5, 5, 5, 5 },100));


            //Strength,Dexterity,Intelligence,Wisdom,Constitution,Charisma

            MetaDataPlayerClass.Add(new PlayerClass("Figter", new int[] { 15, 13, 10, 10, 12, 7 }, GetArmourByName("Heavy plated armour"), GetWeaponByName("Longsword"), 1000, 45.0f));

            MetaDataPlayerClass.Add(new PlayerClass("Barbarian", new int[] { 17, 10, 10, 10, 12, 7 }, GetArmourByName("Light armour"), GetWeaponByName("Sword"), 1000, 70.0f));

            MetaDataPlayerClass.Add(new PlayerClass("Voyager", new int[] { 20, 10, 10, 10, 12, 7 }, GetArmourByName("Chainmail"), GetWeaponByName("Canoe"), 1000, 20.0f));


            MetaDataTEntity.Add(new Enemy("Orc", 50.0f, GetWeaponByName("Battle axe"), GetArmourByName("Chainmail"), new int[] { 20, 10, 10, 10, 13, 7 }, 50));
            MetaDataTEntity.Add(new Enemy("Skeleton", 10.0f, GetWeaponByName("Sword"), GetArmourByName("Cloth armour"), new int[] { 20, 10, 10, 10, 13, 7 }, 50));
            MetaDataTEntity.Add(new Enemy("Zombie", 15.0f, GetWeaponByName("Sword"), GetArmourByName("Cloth armour"), new int[] { 20, 10, 10, 10, 13, 7 }, 50));
            MetaDataTEntity.Add(new Enemy("Wolf", 40.0f,GetWeaponByName("Sword"), GetArmourByName("Cloth armour"), new int[] { 20, 10, 10, 10, 13, 7 }, 50));
            MetaDataBoss.Add(new Boss("Mr.Peers", 100.0f, new Weapon("God sword", 2, 120, new int[] { 15, 13, 10, 10, 12, 7 }, 10000000), new Armour("God armourer", 20, 0.95f, 15, new int[] { 15, 13, 10, 10, 12, 7 },10000000), new int[] { 99, 99, 99, 99, 99, 99 }, 50));
            Menus.Add(new Menu("Start menu", @"                                           
                                          :!?!?Y5JJYPPJ!Y#&&P:                                     
                                          ~&@@@@@@@@@@@@@@@@@@Y                                     
                                          7@@@@@@@@@@@@@@@@@@P.                                     
                                          ^@@@@@@@@@@@@@@@@@@P                                      
                                          5@@@@@@@@@@@@@@@@@@@?                                     
                                         ~@@@@@@@@@@@@@@@@@@@@@5                                    
                                        .#@@@@@@@@@@@@@@@@@@@@@@7                                   
                                        !@@@@@@@@@@@@@@@@@@@@@@@G        .                          
                                        ?@@@@@@@@@@@@@@@@@@@@@@@#.     ~B###5?^                     
                                        5@@@@@@@@@@@@@@@@@@@@@@@@7    ^@@@@@@@@Y.                   
                                       ~#@@@@@@@@@@@@@@@@@@@@@@@@&J.  ?@@@@@@@@@Y                   
                                    .?B@@@@@@@@@@@@@@@@@@@@@@@@@@@@&Y5@@@@@@@@@@5                   
                           .       !B@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&^                   
                       :?P##B5?!^^P@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@J.                    
                     ~P&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@J                      
                    ?@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@B~                       
                   ~@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@5.                        
                   Y@@@@&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@7                          
                   :!~7~:.~7?P&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&GPPGP!                           
                              :~5&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@J                                 
                                 :?GGBPB@@@@@@@@@@@@@@@@@@@@@@@@@@~                                 
                                       !@@@@@@@@@@@@@@@@@@@@@@@@@@~                                 
                                       .#@@@@@@@@@@@@@@@@@@@@@@@@&:                                 
                                        Y@@@@@@@@@@@@@@@@@@@@@@@@5                                  
                                        !@@@@@@@@@@@@@@@@@@@@@@@@P                                  
                                        7@@@@@@@@@@@@@@@@@@@@@@@@@J                                 
                                       ^#@@@@@@@@@@@@@@@@@@@@@@@@@@~                                
                                      .G@@@@@@@@@@@@@@@@@@@@@@@@@@@B                                
                                      Y@@@@@@@@@@@@@@@@@@@@@@@@@@@@@^                               
                                     :&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@?                               
                                     ~@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@Y                               
                                     5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@P                               
                                     B@@@@@@@@@@@@@@&PB@@@@@@@@@@@@@@~                              
                                    :&@@@@@@@@@@@&P!.  ^5@@@@@@@@@@@@!                              
                                    .#@@@@@@@@@@J.       ^5@@@@@@@@@@^                              
                                     P@@@@@@@@@Y           Y@@@@@@@@@~                              
                                     Y@@@@@@@@@5           !@@@@@@@@@P                              
                                    7&@@@@@@@@@G           ^@@@@@@@@@@J                             
                                  :G@@@@@@@@@@@J            P@@@@@@@@@@7                            
                                  ^#&&&&&####B5.            .?Y5YJJJJ?!. 


  _______ _            ____                     _____                         _____                    _______                  _             _ 
 |__   __| |          |  _ \                   / ____|                       / ____|                  |__   __|                (_)           | |
    | |  | |__   ___  | |_) | ___  __ _ _ __  | |  __  __ _ _ __ ___   ___  | |  __  ___  _ __   ___     | | ___ _ __ _ __ ___  _ _ __   __ _| |
    | |  | '_ \ / _ \ |  _ < / _ \/ _` | '__| | | |_ |/ _` | '_ ` _ \ / _ \ | | |_ |/ _ \| '_ \ / _ \    | |/ _ \ '__| '_ ` _ \| | '_ \ / _` | |
    | |  | | | |  __/ | |_) |  __/ (_| | |    | |__| | (_| | | | | | |  __/ | |__| | (_) | | | |  __/    | |  __/ |  | | | | | | | | | | (_| | |
    |_|  |_| |_|\___| |____/ \___|\__,_|_|     \_____|\__,_|_| |_| |_|\___|  \_____|\___/|_| |_|\___|    |_|\___|_|  |_| |_| |_|_|_| |_|\__,_|_|                                                                                                                       
            ", new List<string> { "Start new game"}));

            Menus.Add(new Menu("Make party", "How many players", new List<string> { "1", "2", "3", "4" }));

            Menus.Add(new Menu("Selective class", "Selective starting class", MetaDataPlayerClass));

            Menus.Add(new Menu("Fight menu", "Choose An Option", new List<string> { "Attack enemy", "Check inventory", "Equip gear", "Heal","See stats" }));
            Menus.Add(new Menu("Equipping", "Choose An Option", new List<string> { "Equip Armour", "Equip Weapon","Back"}));
            Menus.Add(new Menu("Select enemy", "Select enemy"));
            Menus.Add(new Menu("Show Inventory", "Inventory"));
            Menus.Add(new Menu("Equipping W or A", "Choose An Item"));
            Menus.Add(new Menu("In-game menu", "Choose An Option", new List<string> { "Player Menu","Back to map","Go to main menu"}));
            Menus.Add(new Menu("Select a player", "Select a player"));
            Menus.Add(new Menu("Player menu", "Choose An Option", new List<string> { "Check inventory", "Equip gear", "See stats","Back" }));




        }

        public Menu GetMenuByName(string nameOfTheMenu)
        {
            foreach (Menu M in Menus)
            {
                if (M.Name == nameOfTheMenu)
                {
                    return M;
                }
            }
            return null;
        }

        public Weapon GetWeaponByName(string nameOfTheWeapon)
        {
            foreach (IItem I in MetaDataItem)
            {
                if (I.GetName() == nameOfTheWeapon && I is Weapon)
                {
                    Weapon weapon = (Weapon)I;
                    return weapon;
                }
            }
            return null;
        }

        public Armour GetArmourByName(string nameOfTheArmour)
        {
            foreach (IItem I in MetaDataItem)
            {
                if (I.GetName() == nameOfTheArmour && I is Armour)
                {
                    Armour armour = (Armour)I;
                    return armour;
                }
            }
            return null;
        }

        public Boss GetABoss()
        {
           return MetaDataBoss[HelperClass.NumberGenerator(0,MetaDataBoss.Count-1)];
        }
        public List<IEntity> GetSomeTEntity(int howManyEntity)
        {

            List<IEntity> listShuffle = Shuffle(MetaDataTEntity);
            List<IEntity> List = new List<IEntity>();
            for (int i = 0; i < howManyEntity;i++ )
            {
                List.Add((IEntity)listShuffle[i].Clone());
            }
            return List;
        }

        public List<IItem> GetSomeTItem(int howManyEntity)
        {

            List<IItem> listShuffle = Shuffle(MetaDataItem);
            List<IItem> List = new List<IItem>();
            for (int i = 0; i < howManyEntity; i++)
            {
                List.Add((IItem)listShuffle[i].Clone());
            }
            return List;
        }

        //https://www.dotnetperls.com/fisher-yates-shuffle
        public List<IEntity> Shuffle(List<IEntity> deck)
        {
            Random r = new Random();
            List<IEntity> list = new List<IEntity>(deck);
            for (int n = list.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                IEntity temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;

            }
            return list;
        }

        //https://www.dotnetperls.com/fisher-yates-shuffle
        public List<IItem> Shuffle(List<IItem> deck)
        {
            Random r = new Random();
            List<IItem> list = new List<IItem>(deck);
            for (int n = list.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                IItem temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;

            }
            return list;
        }                

        public void SeeId()
        {
            string[] names = Enum.GetNames(typeof(NameAndId));
            List<int> ints = new List<int>();
            foreach (int name in Enum.GetValues(typeof(NameAndId))){
                ints.Add(name);
            }

            for(int i = 0; i < names.Length; ++i)
            {
                Console.WriteLine($"name: {names[i]} id: {ints[i]}");
            }   

        }
    }
}
