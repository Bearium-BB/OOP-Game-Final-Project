using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Entity : IEntity
    {
        public string Name { get; private set; }
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }
        public Dictionary<string, int> Stats { get; private set; }
        public Weapon Weapon { get; private set; }
        public Armour Armour { get; private set; }
        public bool IsAlive { get; private set; }


        public Entity(string name, float maxHealth, Weapon weapon, Armour armour,int[] stats)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            GenerateStatsDictionary();
            AddStats(stats);
            Weapon = weapon;
            Armour = armour;
            IsAlive = true;
        }

        public void GenerateStatsDictionary()
        {
            Stats = new Dictionary<string, int>();
            string[] StatsName = "Strength,Dexterity,Intelligence,Wisdom,Constitution,Charisma".Split(",");
            foreach (string str in StatsName)
            {
                Stats.TryAdd(str, 0);
            }
        }
        public void AddStats(int[] stats)
        {
            List<string> Strs = new List<string>();
            foreach (var item in Stats)
            {
                Strs.Add(item.Key);
            }

            for (int i = 0; i < stats.Length; i++)
            {
                Stats[Strs[i]] = stats[i];
            }
        }

        public void DoDamage(IEntity E2)
        {
            Console.Clear();
            if (this.GetWeapon().BonusToHit + HelperClass.NumberGenerator(1,20) >= E2.GetArmor().AC)
            {
                float DamageResistant = this.GetWeapon().Damage * E2.GetArmor().Resistance;
                E2.OperateCurrentHealth(this.GetWeapon().Damage + AddProficiency(Stats["Strength"]) - DamageResistant);
                if (E2 is Enemy)
                {
                    Console.WriteLine($"You hit {E2.GetName()} for {this.GetWeapon().Damage - DamageResistant}");
                }
                else
                {
                    Console.WriteLine($"You get hit {E2.GetName()} for {this.GetWeapon().Damage - DamageResistant}");

                }
            }
            else
            {
                if (E2 is Enemy) {
                    Console.WriteLine("You miss");
                }
                else
                {
                    Console.WriteLine($"{E2.GetName()} Dodged");
                }
            }
            CheckedIsAlive(E2);
        }

        private void CheckedIsAlive(IEntity E2)
        {
            if (E2.GetCurrentHealth() < 0)
            {
                if (E2 is Enemy)
                {
             
                    Console.WriteLine($"You kill {E2.GetName()}");
                }
                else
                {
                    Console.WriteLine($"{E2.GetName()} get kill");
                }
                E2.SetIsAlive(false);
                if (E2 is Enemy)
                {
                    Enemy E = (Enemy)E2;
                    if (this is Player)
                    {
                        Player P = (Player)this;
                        P.OperateCurrentGold(E.DropGold);
                        Console.WriteLine($"{E2.GetName()} drop {E.DropGold} gold");
                        Thread.Sleep(3000);
                    }
                }
            }
        }

        public float GetCurrentHealth()
        {
            return CurrentHealth;
        }

        public Weapon GetWeapon()
        {
            return Weapon;
        }
        public Armour GetArmor()
        {
            return Armour;
        }
        public void OperateCurrentHealth(float D)
        {
            CurrentHealth -= D;
        }

        public string GetName()
        {
            return Name;
        }
        public bool GetIsAlive()
        {
            return IsAlive;
        }
        public void SetIsAlive(bool B)
        {
            IsAlive = B;
        }
        public void SetWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void SetArmour(Armour armour)
        {
            Armour = armour;
        }

        public void Heal()
        {
            float MaxHeal = MaxHealth - CurrentHealth;
            float healed =  HelperClass.NumberGenerator(0, MaxHeal);
            CurrentHealth += healed;
            Console.WriteLine($"You healed {healed}");
            Console.WriteLine($"HP: {CurrentHealth} / {MaxHealth}");
            Thread.Sleep(3000);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int AddProficiency(int num)
        {
            int number = num / 2;
            return number;
        }
    }
}
