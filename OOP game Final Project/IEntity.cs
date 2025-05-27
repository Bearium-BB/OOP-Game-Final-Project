using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal interface IEntity
    {
        public float GetCurrentHealth();
        public void OperateCurrentHealth(float damage);
        public Weapon GetWeapon();   
        public Armour GetArmor();
        public string GetName();
        public bool GetIsAlive();
        public void SetIsAlive(bool isAlive);
        public object Clone();

    }
}
