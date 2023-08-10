//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		SupermarketDriver.cs
//	Description:	Allows the user to run a simulation of a supermarket and edit the properties to see different results 
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Hunter Page, pagehm1@etsu.edu
//	Created:		Tuesday, April 14, 2020
//	Copyright:		Hunter Page, 2020
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace SupermarketSimulation
{
    /// <summary>
    /// runs a simulation of a supermarket with editing options
    /// </summary>
    class SupermarketDriver
    {
        /// <summary>
        /// records outcome of the simulation
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Choices within the menu are created
            Menu menu = new Menu("Supermarket Simulator");
            menu = menu + "Edit the Number of Customers" + "Edit the Hours of Operation" + "Edit the Number of Registers" + "Edit the Average Amount of Time" +
                       "Edit Execution Speed" + "Run the simulation" + "Quit";

            Choices choice = (Choices)menu.GetChoice();

            //Calls new supermarket so that user input can be used for the simulation
            Supermarket supermarketSimulation = new Supermarket();

            //run until user quits the application
            while (choice != Choices.QUIT)
            {
                switch(choice)
                {
                    case Choices.CUSTOMERS:
                        Console.Title = "Number of Customers";
                        Console.WriteLine("You selected to change the number of Customers. Current: " + supermarketSimulation.NumberOfCustomers.ToString());
                        Console.WriteLine("\n\nHow many customers would you like? Or press 'b' and 'enter' to return:");
                        
                        while(true)
                        {
                            string numOfCustomers = Console.ReadLine();  //allows user to edit the expected customer count
                            if(numOfCustomers == "b")
                            {
                                break;
                            }
                            try
                            {
                                //stores new count in the supermarket instance
                                supermarketSimulation.NumberOfCustomers = supermarketSimulation.Poisson(int.Parse(numOfCustomers));
                                break;
                            }
                            catch (Exception) //catches input that is not a number
                            {
                                Console.WriteLine("The input is not a number. Try again.");
                            }
                        }
                           
                        break;

                    case Choices.HOURS:
                        Console.Title = "Hours of Operation";
                        Console.WriteLine("You selected to change the starting hour of operation. Current: " + supermarketSimulation.TimeStoreOpens.ToString());
                        Console.WriteLine("\n\nWhat hours would you like to start? (Closing time is 12:00 AM). Or press 'b' and 'enter' to return: ");

                        while(true)
                        {
                            string newHour = Console.ReadLine();  //allows the user to edit the hour the store opens
                            if (newHour == "b")
                            {
                                break;
                            }
                            try
                            {
                                //stores new opening time in the supermarket instance
                                supermarketSimulation.TimeStoreOpens = DateTime.Parse(newHour);
                                break;
                            }
                            catch (Exception)  //catches if the date is not in the correct format
                            {
                                while (true)
                                {
                                    Console.WriteLine("The value entered is not in the correct format. Please try again.");
                                }

                            }
                        }
                        
                        break;

                    case Choices.REGISTERS:
                        Console.Title = "Number of Registers";
                        Console.WriteLine("You selected to change the number of registers. Current: " + supermarketSimulation.NumberOfRegisters.ToString());
                        Console.WriteLine("\n\nHow many registers would you like? Or press 'b' and 'enter' to return: ");

                        while(true)
                        {
                            string newRegister = Console.ReadLine(); //allows user to edit the number of registers
                            if (newRegister == "b")
                            {
                                break;
                            }

                            try
                            {
                                //stores new register count in the supermarket instance
                                supermarketSimulation.NumberOfRegisters = int.Parse(newRegister);
                            }
                            catch (Exception) //catches if the input is not a number
                            {
                                Console.WriteLine("The value entered is not in the correct format. Please try again.");
                                Console.ReadKey();
                            }

                            break;
                        }

                        break;

                    case Choices.AVERAGE:
                        Console.Title = "Average Time in Line";
                        Console.WriteLine("You selected to change the Average time Customers will be in line (in seconds). Current: " + supermarketSimulation.AverageTime.ToString());
                        Console.WriteLine("\n\nWhat time would you like? Or press 'b' and 'enter' to return: ");

                        while (true)
                        {
                            string newAverage = Console.ReadLine(); //allows user to change the average checkout time
                            if (newAverage == "b")
                            {
                                break;
                            }
                            try
                            {
                                //stores the new average checkout time in the supermarket instance
                                supermarketSimulation.AverageTime = double.Parse(newAverage);
                                break;
                            }
                            catch (Exception) //catches if the input is not valid
                            {
                                Console.WriteLine("The value you entered is not valid, please try again.");
                            }
                        }
                        
                        break;
                    case Choices.EXECUTION_TIME:
                        Console.Title = "Execution Time of Simulation";
                        Console.WriteLine("You selected to change the speed at which the program will run. Current: " + supermarketSimulation.ExecutionSpeed.ToString());
                        Console.WriteLine("\n\nWhat speed (in milliseconds) would you like? Or press 'b' and 'enter' to return: ");
                        string executionTime = Console.ReadLine(); //allows user to change the average checkout time
                        if (executionTime == "b")
                        {
                            break;
                        }

                        while (true)
                        {
                            try
                            {
                                //stores the new average checkout time in the supermarket instance
                                supermarketSimulation.AverageTime = double.Parse(executionTime);
                                break;
                            }
                            catch (Exception) //catches if the input is not valid
                            {
                                Console.WriteLine("The value you entered is not valid, please try again.");
                            }
                        }
                        break;
                    case Choices.RUN:
                        supermarketSimulation.CreateCustomers();
                        supermarketSimulation.CreateRegisters(); 
                        supermarketSimulation.Simulation();
                        if(menu.GetChoiceLength() < 8)
                        {
                            menu.InsertChoice("Re-Display the statistics", menu.GetChoiceLength() - 1);
                        }
                        break;
                    case Choices.DISPLAY:
                        Console.WriteLine(supermarketSimulation.ToString()); //prints all of the statistics from the simulation ran
                        Console.WriteLine("Press any key to return.\n\n");
                        Console.ReadKey();
                        break;

                    case Choices.QUIT:
                        Environment.Exit(0);  //Exits the program
                        break;
                }

                choice = (Choices)menu.GetChoice();
            }
        }
    }
}
