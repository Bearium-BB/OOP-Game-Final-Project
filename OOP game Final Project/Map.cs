using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Map
    {
        public List<List<Room>> DisplayMap { get; set; }
        private List<List<Room>> MovementMap { get; set; }
        private List<List<Room>> InformationalMap { get; set; }
        public Party Party;
        public MasterGameObject MasterGameObject = new MasterGameObject();


        public Map(int sizeForMap, Party party)
        {
            DisplayMap = new List<List<Room>>();
            DisplayMap = GenerateMaps(sizeForMap);
            Party = party;
            MovementMap = new List<List<Room>>();
            InformationalMap = new List<List<Room>>();
            RegeneratePlayableArea();
            PopulateRoom();

        }
        public void PopulateRoom()
        {
            foreach (var listRoom in InformationalMap)
            {
                foreach (var Room in listRoom)
                {
                    if (Room.IsWalkable == "|")
                    {
                        int num = HelperClass.NumberGenerator(1, 100);
                        if (num > 75)
                        {
                            Room.AddEnemy(MasterGameObject.GetSomeTEntity(HelperClass.NumberGenerator(1,3)));
                            Room.AddItems(MasterGameObject.GetSomeTItem(HelperClass.NumberGenerator(1, 2)));
                        }
                    } 
                    if (Room.IsWalkable == "B")
                    {
                        Room.AddEnemy(MasterGameObject.GetSomeTEntity(HelperClass.NumberGenerator(1, 3)));
                        Room.AddEnemy(MasterGameObject.GetABoss());
                        Room.AddItems(MasterGameObject.GetSomeTItem(HelperClass.NumberGenerator(2, 4)));
                    }
                    if (Room.IsWalkable == "L")
                    {
                        Room.AddItems(MasterGameObject.GetSomeTItem(HelperClass.NumberGenerator(2, 4)));
                    }
                    if (Room.IsWalkable == "S")
                    {
                        Room.AddItems(MasterGameObject.GetSomeTItem(HelperClass.NumberGenerator(2, 4)));
                    }
                }
            }
        }
        private List<List<Room>> GenerateMaps(int sizeForMap)
        {
            List<List<Room>> row = new List<List<Room>>();
            for (int i = 0; i < sizeForMap; i++)
            {
                row.Add(new List<Room>());
                for (int j = 0; j < sizeForMap; j++)
                {
                    row[i].Add(new Room("*"));
                }
            }
            return row;
        }
       

        public void PrintMap()
        {
            for (int i = 0; i < DisplayMap.Count; i++)
            {

                for (int j = 0; j < DisplayMap.Count; j++)
                {
                    string IW = DisplayMap[i][j].IsWalkable;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (IW == "*")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (IW == "P")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write($" {IW} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

        }
        public KeyValuePair<int, int> MoveDown(KeyValuePair<int, int> Position)
        {
            if (Position.Key + 1 >= 0 && Position.Key + 1 < MovementMap.Count)
            {
                if (MovementMap[Position.Key + 1][Position.Value].IsWalkable == "|")
                {
                    DisplayMap[Position.Key][Position.Value].IsWalkable = InformationalMap[Position.Key][Position.Value].IsWalkable;
                    Position = new KeyValuePair<int, int>(Position.Key + 1, Position.Value);
                    DisplayMap[Position.Key][Position.Value].IsWalkable = "P";
                    return Position;
                }
                
            }
            return Position;
        }

        public KeyValuePair<int, int> MoveUp(KeyValuePair<int, int> Position)
        {
            if (Position.Key - 1 >= 0 && Position.Key - 1 < MovementMap.Count)
            {
                if (MovementMap[Position.Key - 1][Position.Value].IsWalkable == "|")
                {
                    DisplayMap[Position.Key][Position.Value].IsWalkable = InformationalMap[Position.Key][Position.Value].IsWalkable;
                    Position = new KeyValuePair<int, int>(Position.Key - 1, Position.Value);
                    DisplayMap[Position.Key][Position.Value].IsWalkable = "P";
                    return Position;
                }
            }
            return Position;
        }

        public KeyValuePair<int, int> MoveRight(KeyValuePair<int, int> Position)
        {
            if (Position.Value + 1 >= 0 && Position.Value + 1 < MovementMap.Count)
            {
                if (MovementMap[Position.Key][Position.Value + 1].IsWalkable == "|")
                {
                    DisplayMap[Position.Key][Position.Value].IsWalkable = InformationalMap[Position.Key][Position.Value].IsWalkable;
                    Position = new KeyValuePair<int, int>(Position.Key, Position.Value + 1);
                    DisplayMap[Position.Key][Position.Value].IsWalkable = "P";
                    return Position;
                }
            }
            return Position;
        }
        public KeyValuePair<int, int> MoveLeft(KeyValuePair<int, int> Position)
        {
            if (Position.Value - 1 >= 0 && Position.Value - 1 < MovementMap.Count)
            {
                if (MovementMap[Position.Key][Position.Value - 1].IsWalkable == "|")
                {
                    DisplayMap[Position.Key][Position.Value].IsWalkable = InformationalMap[Position.Key][Position.Value].IsWalkable;
                    Position = new KeyValuePair<int, int>(Position.Key, Position.Value - 1);
                    DisplayMap[Position.Key][Position.Value].IsWalkable = "P";
                    return Position;
                }
            }
            return Position;

        }
        public ConsoleKeyInfo MovePlayer()
        {
            KeyValuePair<int, int> Position = Party.Position;
            Console.WriteLine($"Arrow keys to move");
            ConsoleKeyInfo temp = Console.ReadKey(true);
            switch (temp.Key)
            {
                case ConsoleKey.DownArrow:
                    Position = MoveDown(Position);
                    break;
                case ConsoleKey.UpArrow:
                    Position =  MoveUp(Position);
                    break;
                case ConsoleKey.RightArrow:
                    Position = MoveRight(Position);
                    break;
                case ConsoleKey.LeftArrow:
                    Position = MoveLeft(Position);
                    break;
                default:
                    // code block
                    break;
            }
            Party.Position = Position;
            Console.Clear();
            WhatToDo(InformationalMap[Position.Key][Position.Value].IsWalkable);
            return temp;

        }
        private void RegeneratePlayableArea()
        {
            
            List<KeyValuePair<int, int>> XY = MakeXY().ToList();

            KeyValuePair<int,int> xxyy = MakeXXYY(XY);

            int xx = xxyy.Key;
            int yy = xxyy.Value;
            //this makes it so it starts in the centre the three points
            xx /= 3;
            yy /= 3;
            if (xx > DisplayMap.Count-1)
            {
                xx = DisplayMap.Count-1;
            }

            if (yy > DisplayMap.Count-1)
            {
                yy = DisplayMap.Count-1;
            }

            Party.Position = new KeyValuePair<int, int>(xx, yy);

            for (int i = 0; i <= 2; i++)
            {

                int x = xx;
                int y = yy;
                //XCR is the current remainder of what it's trying to get to in the x-axis
                int XCR = x - XY[i].Key;
                //YCR is the current remainder of what it's trying to get to in the x-axis
                int YCR = y - XY[i].Value;
                while (Math.Abs(XCR) != 0 || Math.Abs(YCR) != 0)
                {
                    //This tells it which direction to go in
                    if (Math.Abs(XCR) >= Math.Abs(YCR) && Math.Abs(XCR) != 0)
                    {
                        if (XCR < 0)
                        {
                            x++;
                            XCR++;
                        }
                        else
                        {
                            x--;
                            XCR--;

                        }
                    }
                    else if (Math.Abs(YCR) >= Math.Abs(XCR) && Math.Abs(YCR) != 0)
                    {
                        if (YCR < 0)
                        {
                            y++;
                            YCR++;

                        }
                        else
                        {
                            y--;
                            YCR--;
                        }
                    }
                    //This updates displays Maps information in the room
                    DisplayMap[x][y].IsWalkable = "|";
                }
            }

            //the rest of the function just copies display maps
            DisplayMap[xx][yy].IsWalkable = "|";
            CopyMap(MovementMap);
            //DisplayMap[XY[0].Key][XY[0].Value].IsWalkable = "S";
            DisplayMap[XY[1].Key][XY[1].Value].IsWalkable = "L";
            DisplayMap[XY[2].Key][XY[2].Value].IsWalkable = "B";
            CopyMap(InformationalMap);
            DisplayMap[xx][yy].IsWalkable = "P";
        }
        private void CopyMap(List<List<Room>> map)
        {
            for (int i = 0; i < DisplayMap.Count; i++)
            {
                map.Add(new List<Room>());
                for (int j = 0; j < DisplayMap.Count; j++)
                {
                    map[i].Add(new Room(DisplayMap[i][j].IsWalkable));
                }
            }
        }

        private KeyValuePair<int, int> MakeXXYY(List<KeyValuePair<int, int>> XY)
        {

            int xx = 0;
            int yy = 0;
            foreach (var i in XY)
            {
                xx += i.Key;
                yy += i.Value;
            }
            return new KeyValuePair<int, int>(xx, yy);
        }
        private HashSet<KeyValuePair<int, int>> MakeXY()
        {
            HashSet<KeyValuePair<int, int>> HashSetXY = new HashSet<KeyValuePair<int, int>>();
            while (HashSetXY.Count <= 3)
            {
                HashSetXY.Add(new KeyValuePair<int, int>(HelperClass.NumberGenerator(0, DisplayMap.Count-3), HelperClass.NumberGenerator(0, DisplayMap.Count-3)));
            }
            return HashSetXY;
        }

        private void WhatToDo(string str)
        {
            switch (str)
            {
                case "|":
                    IsEnemy();
                    break;
                case "S":
                    break;
                case "B":
                    IsEnemy();
                    break;
                case "L":
                    GiveLootInRoom(InformationalMap[Party.Position.Key][Party.Position.Value]);
                    break;
            }
        }

        private void IsEnemy()
        {
            List<TEntity> EnemyList = InformationalMap[Party.Position.Key][Party.Position.Value].EnemyList;
            List<TItem> TItemList = InformationalMap[Party.Position.Key][Party.Position.Value].Items;

            if (EnemyList.Count > 0)
            {
                Fight fight = new Fight(EnemyList, Party, TItemList);
                fight.StartFight();
            }
        }

        public void BeatBoss()
        {
            Room room = null;
            foreach (var listRoom in InformationalMap)
            {
                foreach (var Room in listRoom)
                {
                    if (Room.IsWalkable == "B")
                    {
                        room = Room;
                    }
                }
            }
            if (room.EnemyList.Count <= 0)
            {
                int sizeForMap = DisplayMap.Count;
                DisplayMap.Clear();
                DisplayMap = GenerateMaps(sizeForMap);
                MovementMap.Clear();
                InformationalMap.Clear();
                RegeneratePlayableArea();
                PopulateRoom();
            }
        }
        private void GiveLootInRoom(Room room)
        {
            Console.Clear();

            foreach (Player player in Party.Players)
            {
                player.AddToInventory(room.Items);

            }
            room.Items.Clear();
            Console.WriteLine("The party get some loot. Check your inventory!");
            Thread.Sleep(3000);
        }

    }
}
