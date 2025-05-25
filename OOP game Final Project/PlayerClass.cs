using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class PlayerClass
    {
        public string Name { get; set; }
        public int[] StartingStats { get; private set; }
        public Armour StartingArmour { get; private set; }
        public Weapon StartingWeapon { get; private set; }
        public int StartingGold { get; private set; }
        public float StartingMaxHealth { get; private set; }

        public PlayerClass(string name, int[] startingStats,Armour startingArmour, Weapon startingWeapon, int startingGold,float startingMaxHealth )
        {
            Name = name;
            StartingStats = startingStats;
            StartingArmour = startingArmour;
            StartingWeapon = startingWeapon;
            StartingGold = startingGold;
            StartingMaxHealth = startingMaxHealth;
        }
    }
}
