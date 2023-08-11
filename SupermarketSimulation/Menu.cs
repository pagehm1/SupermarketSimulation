//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		Menu.cs
//	Description:	Menu class that creates the menu and its options for the user
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Hunter Page, hunterpage27171@gmail.com
//	Created:		Tuesday, April 14, 2020
//	Copyright:		Hunter Page, 2020
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketSimulation
{
    /// <summary>
    /// Provides a menu for the console application
    /// </summary>
    class Menu
    {
        private List<string> Options = new List<string>();
        public string Title { get; set; }

        #region Constructors
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="title">the title to be displayed above menu</param>
        public Menu(string title)
        {
            Title = title;
        }
        #endregion

        #region Plus and Minus Operators
        /// <summary>
        /// Operator + adds a choice to the menu
        /// </summary>
        /// <param name="m">the menu to which the choice is added</param>
        /// <param name="item">the choice to be added</param>
        /// <returns></returns>
        public static Menu operator +(Menu m, string item)
        {
            m.Options.Add(item);
            return m;
        }

        /// <summary>
        /// Operator  - removes a choice from the menu
        /// </summary>
        /// <param name="m">the menu from which the choice is removed</param>
        /// <param name="item">the number of the choice to be removed</param>
        /// <returns></returns>
        public static Menu operator -(Menu m, int n)
        {
            if (n > 0 && n <= m.Options.Count)
                m.Options.RemoveAt(n - 1);
            return m;
        }
        #endregion

        #region Display and GetChoice methods
        /// <summary>
        /// Display the menu on the console window
        /// </summary>
        public void Display()
        {
            Console.Clear();
            string date = DateTime.Today.ToLongDateString();
            Console.SetCursorPosition(Console.WindowWidth - date.Length, 0);
            Console.WriteLine(date);
            Console.ForegroundColor = ConsoleColor.Red;

            StringBuilder display = new StringBuilder();
            display.AppendLine("\n\n\t   " + Title);
            display.Append("\t   ");
            for (int i = 0; i < Title.Length; i++)
            {
                display.Append("-");
            }
                
            display.Append("\n");
            Console.WriteLine(display.ToString());
            display.Clear();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < Options.Count; i++)
            {
                string str = String.Format("\t{0}. {1}", i + 1, Options[i]);
                display.AppendLine(str);
            }

            Console.WriteLine(display.ToString());
        }

        /// <summary>
        /// Obtain the user's selection, verify it is valid, and return it
        /// </summary>
        /// <returns>the number of the user's valid selection</returns>
        public int GetChoice()
        {
            if (Options.Count < 1)
            {
                throw new Exception("The menu is empty");
            }

            string line;
            while (true)
            {
                Display();
                Console.Write("\n\t   Type the number of your choice from the menu: ");
                Console.ForegroundColor = ConsoleColor.Red;
                line = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                if (!Int32.TryParse(line, out int choice) || (choice < 1 || choice > Options.Count))
                {
                    Console.WriteLine("\n\t   Your choice is not a number between 1 and {0}.  Please try again.", Options.Count);
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    return choice;
                }
            }
        }

        /// <summary>
        /// Inserts a new choice at the specified index
        /// </summary>
        /// <param name="choice">string name of option</param>
        /// <param name="index">where to place it</param>
        public void InsertChoice(string choice, int index)
        {
            Options.Insert(index, choice);
        }

        public int GetChoiceLength()
        {
            return Options.Count;
        }
        #endregion
    }
}
