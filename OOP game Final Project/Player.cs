using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Player : Entity
    {
        public int Gold { get; private set; }
        public HashSet<IItem> Inventory { get; private set; }

        public Player(string name, float maxHealth, Weapon weapon, Armour armour, int[] stats,int gold) : base(name,maxHealth,weapon,armour,stats)
        {
            Gold = gold;
            Inventory = new HashSet<IItem>();
            Inventory.Add(weapon);
            Inventory.Add(armour);
        }
        public void OperateCurrentGold(int G)
        {
            Gold += G;
        }



        public void Equip(Weapon weapon)
        {
            string[] StatsName = "Strength,Dexterity,Intelligence,Wisdom,Constitution,Charisma".Split(",");
            bool canEquip = true;
            for (int i = 0; i < Stats.Count; i++)
            {
                //Console.WriteLine($"{Stats[StatsName[i]]} {weapon.MinimumStats[StatsName[i]]} {Stats[StatsName[i]] >= weapon.MinimumStats[StatsName[i]]}");
                if (Stats[StatsName[i]] >= weapon.MinimumStats[StatsName[i]])
                {

                }
                else
                {
                    canEquip = false;
                }
            }
            if (canEquip)
            {
                Inventory.Add(Weapon);
                this.SetWeapon(weapon);
                Console.WriteLine($"You equip {weapon.Name}");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Cant equip your stats are to low");
                Thread.Sleep(2000);
            }
        }

        public void Equip(Armour armour)
        {
            string[] StatsName = "Strength,Dexterity,Intelligence,Wisdom,Constitution,Charisma".Split(",");
            bool canEquip = true;
            for (int i = 0; i < Stats.Count; i++)
            {
                if (Stats[StatsName[i]] <= armour.MinimumStats[StatsName[i]])
                {
                    canEquip = false;

                }
            }
            if (canEquip)
            {
                Inventory.Add(Armour);
                this.SetArmour(armour);
                Console.WriteLine($"You equip {armour.Name}");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Cant equip your stats are to low");
            }
        }

        public List<IItem> GetAllWeaponInInventory()
        {
            List<IItem> listTItem = new List<IItem>();
            foreach(IItem inv in Inventory)
            {
                if (inv is Weapon)
                {
                    listTItem.Add(inv);
                }
            }
            return listTItem;
        }

        public List<IItem> GetAllArmourInInventory()
        {
            List<IItem> listTItem = new List<IItem>();
            foreach (IItem inv in Inventory)
            {
                if (inv is Armour)
                {
                    listTItem.Add(inv);
                }
            }
            return listTItem;
        }

        public void AddToInventory(IItem item)
        {
            Inventory.Add(item);
        }

        public void AddToInventory(List<IItem> items)
        {
            foreach (IItem item in items)
            {
                Inventory.Add(item);
            }
        }

        public void PlayerStats()
        {
            Console.Clear();
            StringBuilder SB = new StringBuilder();
            SB.AppendLine($"Name: {Name}");
            SB.AppendLine($"HP: {CurrentHealth} / {MaxHealth}");
            SB.AppendLine($"Equip Weapon: {Weapon.Name}");
            SB.AppendLine($"Equip Armour: {Armour.Name}");
            SB.AppendLine($"Gold: {Gold}");
            foreach (KeyValuePair<string,int> kvp in Stats)
            {
                SB.AppendLine($"{kvp.Key}: {kvp.Value}");
            }
            SB.AppendLine("Press any key to go back");
            Console.WriteLine(SB);
            Console.ReadKey(true);
        }

    }
}
