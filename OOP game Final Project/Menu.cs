using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace OOP_game_Final_Project
{
    internal class Menu
    {
        public string Name { get; set; }
        private List<string> Options;
        private string Prompt;
        private int selectOption;
        private List<PlayerClass> ListPlayerClass;
        public Menu(string name, string prompt, List<string> str)
        {
            Name = name;
            Options = str;
            Prompt = prompt;

        }

        public Menu(string name, string prompt, List<PlayerClass> listPlayerClass)
        {
            Name = name;
            Prompt = prompt;
            ListPlayerClass = listPlayerClass;
        }
        public Menu(string name, string prompt)
        {
            Name = name;
            Prompt = prompt;
        }

        public void DisplayOptions()
        {
            WriteLine(Prompt);

            for (int i = 0; i < Options.Count; i++)
            {
                string option = Options[i];
                if (i == selectOption)
                {
                    Write($"{i + 1}: {option}",BackgroundColor = ConsoleColor.Magenta);
                    ResetColor();
                    WriteLine();

                }
                else
                {
                    WriteLine($"{i + 1}: {option}");

                }


            }
        }

        public int RunMenu()
        {
            selectOption = 0;
            ConsoleKeyInfo temp;
            do
            {
                Clear();
                DisplayOptions();

                temp = ReadKey(true);
                if (temp.Key == ConsoleKey.UpArrow)
                {
                    selectOption--;
                }
                else if (temp.Key == ConsoleKey.DownArrow)
                {
                    selectOption++;
                }
                InIndex();

            } while (temp.Key != ConsoleKey.Enter);
            return selectOption;
        }

        private void InIndex()
        {
            if (selectOption > Options.Count - 1)
            {
                selectOption = 0;
            }
            else if (selectOption < 0)
            {
                selectOption = Options.Count - 1;
            }
        }

        private void InIndex(List<PlayerClass> LPC)
        {
            if (selectOption > LPC.Count - 1)
            {
                selectOption = 0;
            }
            else if (selectOption < 0)
            {
                selectOption = LPC.Count - 1;
            }
        }

        public void DynamicMenu(List<PlayerClass> LPC)
        {

            WriteLine(Prompt);

            for (int i = 0; i < LPC.Count; i++)
            {
                if (i == selectOption)
                {
                    Write($"{i + 1}: {LPC[i].Name}", BackgroundColor = ConsoleColor.Magenta);
                    ResetColor();
                    WriteLine();

                }
                else
                {
                    WriteLine($"{i + 1}: {LPC[i].Name}");

                }


            }

        }
        public PlayerClass RunDynamicMenu()
        {
            selectOption = 0;
            ConsoleKeyInfo temp;
            do
            {
                Clear();
                DynamicMenu(ListPlayerClass);

                temp = ReadKey(true);
                if (temp.Key == ConsoleKey.UpArrow)
                {
                    selectOption--;
                }
                else if (temp.Key == ConsoleKey.DownArrow)
                {
                    selectOption++;
                }
                InIndex(ListPlayerClass);

            } while (temp.Key != ConsoleKey.Enter);
            return ListPlayerClass[selectOption];
        }







        private void InIndex(List<IEntity> LE)
        {
            if (selectOption > LE.Count - 1)
            {
                selectOption = 0;
            }
            else if (selectOption < 0)
            {
                selectOption = LE.Count - 1;
            }
        }

        public void DynamicMenu(List<IEntity> LE)
        {

            WriteLine(Prompt);

            for (int i = 0; i < LE.Count; i++)
            {
                if (i == selectOption)
                {
                    BackgroundColor = ConsoleColor.Magenta;
                }

                Write($"{i + 1}: {LE[i].GetName()}");
                ResetColor();
                WriteLine();

            }

        }
        public IEntity RunDynamicMenu(List<IEntity> ListTEntity)
        {
            selectOption = 0;
            ConsoleKeyInfo temp;
            do
            {
                Clear();
                DynamicMenu(ListTEntity);

                temp = ReadKey(true);
                if (temp.Key == ConsoleKey.UpArrow)
                {
                    selectOption--;
                }
                else if (temp.Key == ConsoleKey.DownArrow)
                {
                    selectOption++;
                }
                InIndex(ListTEntity);

            } while (temp.Key != ConsoleKey.Enter);

            return ListTEntity[selectOption];
        }

        private void InIndex(List<Player> LE)
        {
            if (selectOption > LE.Count - 1)
            {
                selectOption = 0;
            }
            else if (selectOption < 0)
            {
                selectOption = LE.Count - 1;
            }
        }

        public void DynamicMenu(List<Player> LE)
        {

            WriteLine(Prompt);

            for (int i = 0; i < LE.Count; i++)
            {
                if (i == selectOption)
                {
                    BackgroundColor = ConsoleColor.Magenta;
                }

                Write($"{i + 1}: {LE[i].GetName()}");
                ResetColor();
                WriteLine();

            }

        }
        public Player RunDynamicMenu(List<Player> ListPlayer)
        {
            selectOption = 0;
            ConsoleKeyInfo temp;
            do
            {
                Clear();
                DynamicMenu(ListPlayer);

                temp = ReadKey(true);
                if (temp.Key == ConsoleKey.UpArrow)
                {
                    selectOption--;
                }
                else if (temp.Key == ConsoleKey.DownArrow)
                {
                    selectOption++;
                }
                InIndex(ListPlayer);

            } while (temp.Key != ConsoleKey.Enter);

            return ListPlayer[selectOption];
        }

        private void InIndex(List<IItem> LI)
        {
            if (selectOption > LI.Count - 1)
            {
                selectOption = 0;
            }
            else if (selectOption < 0)
            {
                selectOption = LI.Count - 1;
            }
        }

        public void DynamicMenu(List<IItem> LI)
        {

            WriteLine(Prompt);

            for (int i = 0; i < LI.Count; i++)
            {
                if (i == selectOption)
                {
                    BackgroundColor = ConsoleColor.Magenta;
                }

                Write($"{i + 1}: {LI[i].GetName()}");
                ResetColor();
                WriteLine();

            }

        }

        public IItem RunDynamicMenu(List<IItem> ListTItem)
        {
            selectOption = 0;
            ConsoleKeyInfo temp;
            do
            {
                Clear();
                DynamicMenu(ListTItem);

                temp = ReadKey(true);
                if (temp.Key == ConsoleKey.UpArrow)
                {
                    selectOption--;
                }
                else if (temp.Key == ConsoleKey.DownArrow)
                {
                    selectOption++;
                }
                InIndex(ListTItem);

            } while (temp.Key != ConsoleKey.Enter);
            return ListTItem[selectOption];
        }

    }
}
