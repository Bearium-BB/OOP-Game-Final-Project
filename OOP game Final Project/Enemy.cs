using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Enemy : Entity
    {
        public int DropGold { get; private set; }
        public Enemy(string name, float maxHealth, Weapon weapon, Armour armour,int[] stats, int dropGold) : base(name, maxHealth, weapon, armour, stats)
        {
            DropGold = dropGold;
        }


    }
}
