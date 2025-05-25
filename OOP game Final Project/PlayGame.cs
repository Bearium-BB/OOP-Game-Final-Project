using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class PlayGame
    {
        private Party Party { get; set; }
        private Map Map { get; set; }
        private GameState State { get; set; } = new GameState();
        private MasterGameObject MasterGameObject { get; set; } = new MasterGameObject();

        public PlayGame(Party party)
        {
            Party = party;
            Map = new Map(40, party);
        }

        public void StartLoop()
        {
            while (PartyIsAlive())
            {
                Map.PrintMap();
                Console.WriteLine("press ESC to open the menu");
                ConsoleKeyInfo keyInfo = Map.MovePlayer();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    InGameMenu();
                }
                Map.BeatBoss();

            }
            Console.WriteLine(@"
  _____ _     _                                            _                                       _    __                               
 |_   _| |   | |                                          | |                                     | |  / _|                              
   | | | |_  | |__   __ _ ___    ___ ___  _ __ ___   ___  | |_ ___     __ _ _ __     ___ _ __   __| | | |_ ___  _ __   _   _  ___  _   _ 
   | | | __| | '_ \ / _` / __|  / __/ _ \| '_ ` _ \ / _ \ | __/ _ \   / _` | '_ \   / _ \ '_ \ / _` | |  _/ _ \| '__| | | | |/ _ \| | | |
  _| |_| |_  | | | | (_| \__ \ | (_| (_) | | | | | |  __/ | || (_) | | (_| | | | | |  __/ | | | (_| | | || (_) | |    | |_| | (_) | |_| |
 |_____|\__| |_| |_|\__,_|___/  \___\___/|_| |_| |_|\___|  \__\___/   \__,_|_| |_|  \___|_| |_|\__,_| |_| \___/|_|     \__, |\___/ \__,_|
                                                                                                                        __/ |            
                                                                                                                       |___/             
");
            Thread.Sleep(5000);
            State.StartGame();
        }

        private bool PartyIsAlive()
        {
            foreach (Player P in Party.Players)
            {
                if (P.IsAlive == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void InGameMenu()
        {
            switch(MasterGameObject.GetMenuByName("In-game menu").RunMenu())
            {
                case 0:
                    PlayerMenu(MasterGameObject.GetMenuByName("Select a player").RunDynamicMenu(Party.Players));
                    break;
                case 1:
                    break;
                case 2:
                    State.StartGame();
                    break;
                default:
                    break;
            }
        }
        private void PlayerMenu(Player P)
        {
            switch (MasterGameObject.GetMenuByName("Player menu").RunMenu())
            {
                case 0:
                    MasterGameObject.GetMenuByName("Show Inventory").RunDynamicMenu(P.Inventory.ToList());
                    PlayerMenu(P);
                    break;
                case 1:
                    EquippingMenu(P);
                    break;
                case 2:
                    P.PlayerStats();
                    PlayerMenu(P);
                    break;
                case 3:
                    InGameMenu();
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
                    PlayerMenu(P);
                    break;
                case 1:
                    P.Equip((Weapon)MasterGameObject.GetMenuByName("Equipping W or A").RunDynamicMenu(P.GetAllWeaponInInventory()));
                    PlayerMenu(P);
                    break;
                case 2:
                    PlayerMenu(P);
                    break;
                default:
                    break;
            }
        }


    }
}
