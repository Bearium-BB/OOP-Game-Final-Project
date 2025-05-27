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
            
            List<KeyValuePair<int, int>> keyLocations = MakeRandomPositions().ToList();

            KeyValuePair<int,int> totalCoordinates = GetTotalCoordinates(keyLocations);

            int averageX = totalCoordinates.Key;
            int averageY = totalCoordinates.Value;
            //this makes it so it starts in the centre the three points
            averageX /= 3;
            averageY /= 3;
            if (averageX > DisplayMap.Count-1)
            {
                averageX = DisplayMap.Count-1;
            }

            if (averageY > DisplayMap.Count-1)
            {
                averageY = DisplayMap.Count-1;
            }

            Party.Position = new KeyValuePair<int, int>(averageX, averageY);

            for (int i = 0; i <= 2; i++)
            {

                int currentX = averageX;
                int currentY = averageY;
                //XCR is the current remainder of what it's trying to get to in the x-axis
                int remainingX = currentX - keyLocations[i].Key;
                //YCR is the current remainder of what it's trying to get to in the x-axis
                int remainingY = currentY - keyLocations[i].Value;
                while (Math.Abs(remainingX) != 0 || Math.Abs(remainingY) != 0)
                {
                    //This tells it which direction to go in
                    if (Math.Abs(remainingX) >= Math.Abs(remainingY) && Math.Abs(remainingX) != 0)
                    {
                        if (remainingX < 0)
                        {
                            currentX++;
                            remainingX++;
                        }
                        else
                        {
                            currentX--;
                            remainingX--;

                        }
                    }
                    else if (Math.Abs(remainingY) >= Math.Abs(remainingX) && Math.Abs(remainingY) != 0)
                    {
                        if (remainingY < 0)
                        {
                            currentY++;
                            remainingY++;

                        }
                        else
                        {
                            currentY--;
                            remainingY--;
                        }
                    }
                    //This updates displays Maps information in the room
                    DisplayMap[currentX][currentY].IsWalkable = "|";
                }
            }

            //the rest of the function just copies display maps
            DisplayMap[averageX][averageY].IsWalkable = "|";
            CopyMap(MovementMap);
            //DisplayMap[XY[0].Key][XY[0].Value].IsWalkable = "S";
            DisplayMap[keyLocations[1].Key][keyLocations[1].Value].IsWalkable = "L";
            DisplayMap[keyLocations[2].Key][keyLocations[2].Value].IsWalkable = "B";
            CopyMap(InformationalMap);
            DisplayMap[averageX][averageY].IsWalkable = "P";
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

        private KeyValuePair<int, int> GetTotalCoordinates(List<KeyValuePair<int, int>> XY)
        {

            int totalX = 0;
            int totalY = 0;
            foreach (var i in XY)
            {
                totalX += i.Key;
                totalY += i.Value;
            }
            return new KeyValuePair<int, int>(totalX, totalY);
        }
        private HashSet<KeyValuePair<int, int>> MakeRandomPositions()
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
            List<IEntity> EnemyList = InformationalMap[Party.Position.Key][Party.Position.Value].EnemyList;
            List<IItem> TItemList = InformationalMap[Party.Position.Key][Party.Position.Value].Items;

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
