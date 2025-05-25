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
        public List<TEntity> EnemyList { get; set; }
        public List<TItem> Items { get; set; }
        public Room(string isWalkable, string type = "Space")
        {
            IsWalkable = isWalkable;
            EnemyList = new List<TEntity>();
            Items =  new List<TItem>();
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

        public void AddEnemy(TEntity  E)
        {
            EnemyList.Add(E);
        }
        public void AddEnemy(List<TEntity> LE)
        {
            foreach(TEntity E in LE)
            {
                EnemyList.Add(E);
            }
        }

        public void AddItems(TItem I)
        {
            Items.Add(I);
        }
        public void AddItems(List<TItem> LI)
        {
            foreach (TItem I in LI)
            {
                Items.Add(I);
            }
        }
    }
}
