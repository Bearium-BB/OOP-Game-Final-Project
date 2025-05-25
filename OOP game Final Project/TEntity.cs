using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal interface TEntity
    {
        public float GetCurrentHealth();
        public void OperateCurrentHealth(float D);
        public Weapon GetWeapon();   
        public Armour GetArmor();
        public string GetName();
        public bool GetIsAlive();
        public void SetIsAlive(bool B);
        public object Clone();

    }
}
