using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class Fight
    {
        public List<TEntity> Entities { get; private set; }
        public List<TItem> Items { get; private set; }
        public Party Party { get; private set; }
        private Queue<KeyValuePair<TEntity, int>> EntitiesOfTurn { get;  set; }
        private List<KeyValuePair<TEntity, int>> Entitiesinitiative { get; set; }
        private MasterGameObject MasterGameObject = new MasterGameObject(); 

        public Fight(List<TEntity> entities, Party party, List<TItem> items)
        {
            Entities = entities;
            Party = party;
            EntitiesOfTurn = new Queue<KeyValuePair<TEntity, int>>();
            Entitiesinitiative = new List<KeyValuePair<TEntity, int>>();
            TurnForPlayer();
            Items = items;
        }
        public void StartFight()
        {
            Console.WriteLine(@"
  ______       _                    _   ____        _   _   _      
 |  ____|     | |                  | | |  _ \      | | | | | |     
 | |__   _ __ | |_ ___ _ __ ___  __| | | |_) | __ _| |_| |_| | ___ 
 |  __| | '_ \| __/ _ \ '__/ _ \/ _` | |  _ < / _` | __| __| |/ _ \
 | |____| | | | ||  __/ | |  __/ (_| | | |_) | (_| | |_| |_| |  __/
 |______|_| |_|\__\___|_|  \___|\__,_| |____/ \__,_|\__|\__|_|\___|
");

            Thread.Sleep(3000);

            do
            {
                if (EntitiesOfTurn.Peek().Key is Player)
                {
                    Player player = (Player)EntitiesOfTurn.Peek().Key;
                    Console.Clear();
                    Console.WriteLine($"{player.Name} turn");
                    Thread.Sleep(1000);
                    FightMenu(player);
                }
                else
                {
                    if (EntitiesOfTurn.Peek().Key is Enemy)
                    {
                        Enemy enemy = (Enemy)EntitiesOfTurn.Peek().Key;
                        Console.Clear();
                        enemy.DoDamage(Party.Players[HelperClass.NumberGenerator(0, Party.Players.Count - 1)]);
                        Thread.Sleep(1000);
                    }
                }
                EntitiesOfTurn.Enqueue(EntitiesOfTurn.Peek());
                EntitiesOfTurn.Dequeue();
                EntitiesIsAlive();
                PlayerDied();
            } while (PartyIsAlive() && Entities.Count > 0);

            GiveLootInRoom();
            Console.Clear();
            Console.WriteLine(@"
  ____        _   _   _        _    _             ______           _          _ 
 |  _ \      | | | | | |      | |  | |           |  ____|         | |        | |
 | |_) | __ _| |_| |_| | ___  | |__| | __ _ ___  | |__   _ __   __| | ___  __| |
 |  _ < / _` | __| __| |/ _ \ |  __  |/ _` / __| |  __| | '_ \ / _` |/ _ \/ _` |
 | |_) | (_| | |_| |_| |  __/ | |  | | (_| \__ \ | |____| | | | (_| |  __/ (_| |
 |____/ \__,_|\__|\__|_|\___| |_|  |_|\__,_|___/ |______|_| |_|\__,_|\___|\__,_|
");
            Thread.Sleep(3000);
            Console.Clear();


        }

        private void GiveLootInRoom()
        {
            Console.Clear();
            if (PartyIsAlive())
            {
                foreach (Player player in Party.Players)
                {
                    player.AddToInventory(Items);
                }
                Console.WriteLine("The party get some loot. Check your inventory!");
                Thread.Sleep(3000);
            }
        }

        private bool PartyIsAlive()
        {
            foreach(Player P in Party.Players)
            {
                if (P.IsAlive == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void PlayerDied()
        {
            List<Player> players = Party.Players;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetCurrentHealth() < 0)
                {
                    for (int j = 0; j < Entitiesinitiative.Count; j++)
                    {
                        if (Entitiesinitiative[j].Key == players[i])
                        {
                            Entitiesinitiative.Remove(Entitiesinitiative[j]);
                        }
                    }
                    players.Remove(players[i]);
                    UpdateTurnForPlayer();
                    Console.WriteLine(Party.Players.Count);
                    Thread.Sleep(5000);
                }
            }
        }
        private void EntitiesIsAlive()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].GetCurrentHealth() < 0)
                {
                    for(int j = 0; j < Entitiesinitiative.Count; j++)
                    {
                        if (Entitiesinitiative[j].Key == Entities[i])
                        {
                            Entitiesinitiative.Remove(Entitiesinitiative[j]);
                        }
                    }
                    Entities.Remove(Entities[i]);
                    UpdateTurnForPlayer();
                }
            }
        }

        private void SetPlayI(List<TEntity> E, List<KeyValuePair<TEntity, int>> playerTurn)
        {
            foreach (TEntity entity in E)
            {
                playerTurn.Add(new KeyValuePair<TEntity, int>(entity, HelperClass.NumberGenerator(0, 20)));
            }
        }
        private void SetPlayI(Party P, List<KeyValuePair<TEntity, int>> playerTurn)
        {
            foreach (TEntity Player in P.Players)
            {
                playerTurn.Add(new KeyValuePair<TEntity, int>(Player, HelperClass.NumberGenerator(0, 20)));
            }
        }
        private void TurnForPlayer()
        {
            SetPlayI(Entities, Entitiesinitiative);
            SetPlayI(Party, Entitiesinitiative);
            Entitiesinitiative.Sort((x, y) => x.Value.CompareTo(y.Value));
            Entitiesinitiative.Reverse();

            foreach (var PI in Entitiesinitiative)
            {
                EntitiesOfTurn.Enqueue(PI);
            }
        }
        public void UpdateTurnForPlayer()
        {
            EntitiesOfTurn.Clear();
            foreach (var PI in Entitiesinitiative)
            {
                EntitiesOfTurn.Enqueue(PI);
            }
        }
        private void FightMenu(Player P)
        {
            switch (MasterGameObject.GetMenuByName("Fight menu").RunMenu())
            {
                case 0:
                    P.DoDamage(MasterGameObject.GetMenuByName("Select enemy").RunDynamicMenu(Entities));
                    Thread.Sleep(1000);
                    break;
                case 1:
                    MasterGameObject.GetMenuByName("Show Inventory").RunDynamicMenu(P.Inventory.ToList());
                    FightMenu(P);
                    break;
                case 2:
                    EquippingMenu(P);
                    break;
                case 3:
                    P.Heal();
                    break;
                case 4:
                    P.PlayerStats();
                    FightMenu(P);
                    break;
                default:
                    break;
            }
        }

        public void EquippingMenu(Player P)
        {
            switch (MasterGameObject.GetMenuByName("Equipping").RunMenu())
            {
                case 0:
                    P.Equip((Armour)MasterGameObject.GetMenuByName("Equipping W or A").RunDynamicMenu(P.GetAllArmourInInventory()));
                    FightMenu(P);
                    break;
                case 1:
                    P.Equip((Weapon)MasterGameObject.GetMenuByName("Equipping W or A").RunDynamicMenu(P.GetAllWeaponInInventory()));
                    FightMenu(P);
                    break;
                case 2:
                    FightMenu(P);
                    break;
                default:
                    break;
            }
        }

    }
}
