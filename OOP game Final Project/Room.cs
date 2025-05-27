using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Room
    {
        public string Type { get; set; }
        public string IsWalkable { get; set; }
        public List<IEntity> EnemyList { get; set; }
        public List<IItem> Items { get; set; }
        public Room(string isWalkable, string type = "Space")
        {
            IsWalkable = isWalkable;
            EnemyList = new List<IEntity>();
            Items =  new List<IItem>();
            Type = type;
        }

        public void DescriptionOfRoom()
        {
            foreach (Enemy e in EnemyList)
            {
                Console.WriteLine($"{e.Name}");
            }
            Console.WriteLine(EnemyList.Count);

        }

        public void AddEnemy(IEntity  E)
        {
            EnemyList.Add(E);
        }
        public void AddEnemy(List<IEntity> LE)
        {
            foreach(IEntity E in LE)
            {
                EnemyList.Add(E);
            }
        }

        public void AddItems(IItem I)
        {
            Items.Add(I);
        }
        public void AddItems(List<IItem> LI)
        {
            foreach (IItem I in LI)
            {
                Items.Add(I);
            }
        }
    }
}
