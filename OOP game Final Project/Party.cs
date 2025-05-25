using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Party
    {
        public KeyValuePair<int, int> Position { get; set; }
        public List<Player> Players { get; private set; }
        public Party()
        {
            Players = new List<Player>();
        }
        public void AddToPlayers(Player P)
        {
            Players.Add(P);
        }
    }
}
