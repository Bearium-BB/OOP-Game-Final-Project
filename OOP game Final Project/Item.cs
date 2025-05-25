using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Item : TItem
    {
        public string Name { get; private set; }    
        public int Id { get; private set; }
        public Dictionary<string, int> MinimumStats { get; private set; }
        public int BuyItem { get; private set; }

        public Item(string name , int id, int[] stats, int buyItem)
        {
            Name = name;
            Id = id;
            GenerateStatsDictionary();
            AddStats(stats);
            BuyItem = buyItem;
        }

        public void GenerateStatsDictionary()
        {
            MinimumStats = new Dictionary<string, int>();
            string[] StatsName = "Strength,Dexterity,Intelligence,Wisdom,Constitution,Charisma".Split(",");
            foreach (string str in StatsName)
            {
                MinimumStats.TryAdd(str, 0);
            }
        }
        public void AddStats(int[] stats)
        {
            List<string> Strs = new List<string>();
            foreach (var item in MinimumStats)
            {
                Strs.Add(item.Key);
            }

            for (int i = 0; i < stats.Length; i++)
            {
                MinimumStats[Strs[i]] = stats[i];
            }
        }
        public string GetName()
        {
            return Name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
