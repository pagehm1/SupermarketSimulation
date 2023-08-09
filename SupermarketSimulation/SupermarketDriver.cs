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
            menu = menu + "Edit the Number of Customers" + "Edit the Hours of Operation" + "Edit the Number of Registers" + "Edit the Average Amount of Time" 
                        + "Run the simulation" + "Re-Display the statistics (after simulation has ran)" + "Quit"; //NOTE: remove the display stats and place it after the simulation has run

            Choices choice = (Choices)menu.GetChoice();

            //initializes Supermarket instance to record user data
            Supermarket supermarketInstance = new Supermarket();

            //Calls new supermarket so that user input can be used for the simulation
            Supermarket supermarketSimulation = new Supermarket();

            //run until user quits the application
            while (choice != Choices.QUIT)
            {
                switch(choice)
                {
                    case Choices.CUSTOMERS:
                        Console.Title = "Number of Customers";
                        Console.WriteLine("You selected to change the number of Customers. Current: " + supermarketInstance.NumberOfCustomers.ToString());
                        Console.WriteLine("\n\nHow many customers would you like?");
                        string numOfCustomers = Console.ReadLine();  //allows user to edit the expected customer count

                        try
                        {
                            //stores new count in the supermarket instance
                            supermarketInstance.NumberOfCustomers = int.Parse(numOfCustomers);
                        }
                        catch(Exception) //catches input that is not a number
                        {
                            Console.WriteLine("The input is not a number. Try again.");
                            Console.ReadKey();
                        }                        
                        break;

                    case Choices.HOURS:
                        Console.Title = "Hours of Operation";
                        Console.WriteLine("You selected to change the starting hour of operation. Current: " + supermarketInstance.TimeStoreOpens.ToString());
                        Console.WriteLine("\n\nWhat hours would you like?: ");
                        string newHour = Console.ReadLine();  //allows the user to edit the hour the store opens

                        try
                        {
                            //stores new opening time in the supermarket instance
                            supermarketInstance.TimeStoreOpens = DateTime.Parse(newHour);
                        }
                        catch(Exception)  //catches if the date is not in the correct format
                        {
                            Console.WriteLine("The value entered is not in the correct format. Please try again.");
                            Console.ReadKey();

                        }
                        break;

                    case Choices.REGISTERS:
                        Console.Title = "Number of Registers";
                        Console.WriteLine("You selected to change the number of registers. Current: " + supermarketInstance.NumberOfRegisters.ToString());
                        Console.WriteLine("\n\nHow many registers would you like?: ");
                        string newRegister = Console.ReadLine(); //allows user to edit the number of registers

                        try
                        {
                            //stores new register count in the supermarket instance
                            supermarketInstance.NumberOfRegisters = int.Parse(newRegister);
                        }
                        catch(Exception) //catches if the input is not a number
                        {
                            Console.WriteLine("The value entered is not in the correct format. Please try again.");
                            Console.ReadKey();

                        }
                        break;
                    case Choices.AVERAGE:
                        Console.Title = "Average Time in Line";
                        Console.WriteLine("You selected to change the Average time Customers will be in line (in seconds). Current: " + supermarketInstance.AverageTime.ToString());
                        Console.WriteLine("\n\nWhat time would you like?: ");
                        string newAverage = Console.ReadLine(); //allows user to change the average checkout time

                        try
                        {
                            //stores the new average checkout time in the supermarket instance
                            supermarketInstance.AverageTime = double.Parse(newAverage);
                        }
                        catch(Exception) //catches if the input is not valid
                        {
                            Console.WriteLine("The value you entered is not valid, please try again.");
                            Console.ReadKey();

                        }
                        break;

                    case Choices.RUN:
                        //creates a new instance of the supermarket with the edited information
                        supermarketSimulation = new Supermarket(supermarketInstance.NumberOfCustomers, supermarketInstance.TimeStoreOpens, supermarketInstance.NumberOfRegisters, supermarketInstance.AverageTime);
                        supermarketSimulation.CreateRegisters(); //creates the registers
                        supermarketSimulation.Simulation();  //runs the simulation
                        break;

                    case Choices.DISPLAY:
                        Console.WriteLine(supermarketSimulation.ToString()); //prints all of the statistics from the simulation ran
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
