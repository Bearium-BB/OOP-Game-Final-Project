using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal interface TItem
    {
        public string GetName();

        public object Clone();

    }
}
