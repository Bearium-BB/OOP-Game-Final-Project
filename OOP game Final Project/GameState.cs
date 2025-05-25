using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_game_Final_Project
{
    internal class GameState
    {
        private MasterGameObject MasterGameObject { get; set; } = new MasterGameObject();
        public GameState()
        {

        }

        public void StartGame()
        {
            Console.SetWindowSize(175, 40);
            switch (MasterGameObject.GetMenuByName("Start menu").RunMenu())
            {
                case 0:
                    GettingPlayGameReady();
                    break;
                default:
                    break;
            }
        }

        private void Dialogue(List<string[]> strings)
        {
            Console.Clear();
            foreach (string[] strArr in strings)
            {
                foreach (string str in strArr)
                {
                    Console.Write(">");
                    foreach (char cha in str)
                    {
                        Console.Write(cha);
                        Thread.Sleep(30);
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }
        }
        private void GettingPlayGameReady()
        {
            List<string[]> strings = "A time-travelling cowboy named Mr Coppens. Has travelled back in time to stop the Russian bears from taking over the world. He has the ability to travel back and forth in space at a rate of about one-millionth of an inch per second. The cowboy is currently on the run from those pesky Russians. Mr Copps is the first man to ever be able to time travel and has managed to get himself back to a time before the bears arrived. If Mr Copps can get back before they arrive, he might have a chance of saving the human race. This is a dangerous mission and we need you to go with him.\r\n".Split(".").Chunk(2).ToList();
            Dialogue(strings);
            Party P = MakeParty();
            Console.WriteLine(@"
  _____ _     _                _           
 |_   _| |   | |              (_)          
   | | | |_  | |__   ___  __ _ _ _ __  ___ 
   | | | __| | '_ \ / _ \/ _` | | '_ \/ __|
  _| |_| |_  | |_) |  __/ (_| | | | | \__ \
 |_____|\__| |_.__/ \___|\__, |_|_| |_|___/
                          __/ |            
                         |___/  
                     
");
            Thread.Sleep(3000);
            Console.Clear();

            PlayGame PG = new PlayGame(P);
            PG.StartLoop();
        }
        private Party MakeParty()
        {
            int totalPlayers = 0;
            switch (MasterGameObject.GetMenuByName("Make party").RunMenu())
            {
                case 0:
                    totalPlayers = 1;
                    break;
                case 1:
                    totalPlayers = 2;
                    break;
                case 2:
                    totalPlayers = 3;
                    break;
                case 3:
                    totalPlayers = 4;
                    break;
                default:
                    break;
            }
            return MakingCharacters(totalPlayers);
        }

        private Party MakingCharacters(int totalPlayers)
        {
            Party p = new Party();
            for (int i = 0; i < totalPlayers; i++)
            {
                Console.Clear();
                Console.WriteLine($"Player {i+1} make a character");
                Thread.Sleep(3000);

                PlayerClass PC = MasterGameObject.GetMenuByName($"Selective class").RunDynamicMenu();
                Console.Clear();

                Console.WriteLine("Please enter a name");
                string Name = Console.ReadLine();
                p.AddToPlayers(new Player(Name, PC.StartingMaxHealth, PC.StartingWeapon, PC.StartingArmour,PC.StartingStats,PC.StartingGold));
            }
            return p;
        }


    }
}
