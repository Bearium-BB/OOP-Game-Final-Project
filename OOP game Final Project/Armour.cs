using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOP_game_Final_Project
{
    internal class Armour : Item
    {
        public float Resistance { get; private set; }
        public float AC { get; private set; }
        public Armour(string name, int id, float resistance, float aC, int[] stats, int buyItem) : base(name, id, stats, buyItem)
        {
            Resistance = resistance;
            AC = aC;
        }
    }
}
