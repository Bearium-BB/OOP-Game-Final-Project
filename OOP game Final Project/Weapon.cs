using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Weapon : Item
    {
        public float Damage { get; private set; }
        public int BonusToHit { get; private set; }


        public Weapon(string name, int id, float damage, int[] stats,int buyItem) : base(name, id, stats, buyItem)
        {
            Damage = damage;
        }
    }
}
