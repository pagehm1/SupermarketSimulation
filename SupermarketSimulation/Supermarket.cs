//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		Supermarket.cs
//	Description:	Simulates a Supermarket with several properties 
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Hunter Page, pagehm1@etsu.edu
//	Created:		Tuesday, April 14, 2020
//	Copyright:		Hunter Page, 2020
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    /// <summary>
    /// Sets the properties of the Supermarket and runs a simulation
    /// </summary>
    public class Supermarket
    {
        /// <summary>
        /// PriorityQueue of the ENTER and LEAVE events of every customer object
        /// </summary>
        public PriorityQueue<Event> QueueOfEvents { get; set; }

        /// <summary>
        /// The number of expected customers
        /// </summary>
        public int NumberOfCustomers { get; set; }

        /// <summary>
        /// The time the store will open for the day 
        /// </summary>
        public DateTime TimeStoreOpens { get; set; }

        /// <summary>
        /// Number of Registers open in the store
        /// </summary>
        public int NumberOfRegisters { get; set; }

        /// <summary>
        /// Average check out time for the Customer objects
        /// </summary>
        public double AverageTime { get; set; }

        /// <summary>
        /// A List of the Customer Objects in each Queue (register)
        /// </summary>
        public List<Queue<Customer>> Registers { get; set; }

        /// <summary>
        /// Provides the Average time recorded after all checkout times for the Customer objects have been made
        /// </summary>
        public double EndAverageServiceTime { get; set; }

        /// <summary>
        /// The customer that had the smallest checkout time
        /// </summary>
        public TimeSpan MinimumServiceTime { get; set; }

        /// <summary>
        /// The customer time that had the longest amount of time
        /// </summary>
        public TimeSpan MaximumServiceTime { get; set; }

        /// <summary>
        /// Displays the Time of Day based off the Customer ENTER and LEAVE events
        /// </summary>
        DateTime CurrentTime { get; set; }

        /// <summary>
        /// Default Constructor that initializes the properties for the simulator
        /// </summary>
        public Supermarket()
        {
            //sets an expected number of customers
            NumberOfCustomers = Poisson(600);

            //new Priority Queue holding the enter and leave events
            QueueOfEvents = new PriorityQueue<Event>();

            //sets time of day to 8:00 AM
            TimeStoreOpens = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            NumberOfRegisters = 3;

            //sets average time to 345 seconds (5 minutes, 45 seconds)
            AverageTime = 345;

            Registers = new List<Queue<Customer>>(NumberOfRegisters);
            MinimumServiceTime = new TimeSpan(0, 10, 0);
        }

        /// <summary>
        /// Parameterized Constructor that sets info based off of user input
        /// </summary>
        /// <param name="numberOfCustomers">number of customers to visit store</param>
        /// <param name="timeStoreOpens">Time the store opens in the morning</param>
        /// <param name="numberOfRegisters">Number of Registers used for the day</param>
        /// <param name="averageTime">Average Checkout time</param>
        public Supermarket(double numberOfCustomers, DateTime timeStoreOpens, int numberOfRegisters, double averageTime)
        {
            Random randNum = new Random();
            Customer NewCustomer;

            //New *expected* number of customers from input
            NumberOfCustomers = Poisson(numberOfCustomers);

            //new Priority Queue holding the enter and leave events
            QueueOfEvents = new PriorityQueue<Event>();

            //sets time of day to user input
            TimeStoreOpens = timeStoreOpens;

            //Takes the hours that the user wants to open and converts it for the ENTER event
            int operatingHours = 24 - TimeStoreOpens.Hour;

            //sets number of registers to user input
            NumberOfRegisters = numberOfRegisters;

            //sets average time to user input
            AverageTime = averageTime;

            //sets List of Registers 
            Registers = new List<Queue<Customer>>(NumberOfRegisters);

            //used to determine the smallest checkout time
            MinimumServiceTime = new TimeSpan(0, 10, 0);

            //creates the customer objects and their ENTER and LEAVE events
            for (int customer = 1; customer <= NumberOfCustomers; customer++)
            {
                NewCustomer = new Customer(AverageTime, customer);
                QueueOfEvents.Enqueue(new Event(EventType.ENTER, TimeStoreOpens.Add(new TimeSpan(0, randNum.Next(operatingHours * 60), 0)), NewCustomer));

                //finds the minimum and maximum times of service
                if (MinimumServiceTime > NewCustomer.TimeOfService)
                {
                    MinimumServiceTime = NewCustomer.TimeOfService;
                }

                if (MaximumServiceTime < NewCustomer.TimeOfService)
                {
                    MaximumServiceTime = NewCustomer.TimeOfService;
                }

                //Average after all customers have been made
                EndAverageServiceTime += NewCustomer.TimeOfService.TotalMinutes;

                //pauses program so it does not immediately start when user runs simulation
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Runs a pseudo-graphical representation of the supermarket registers and their customers
        /// </summary>
        public void Simulation()
        {
            //String of the registers and the information pertaining to it
            StringBuilder registerRepresentation = new StringBuilder();
            registerRepresentation.Append("    Registers\n" + "--------------------");

            //counts ENTER events ran
            int arrivalCount = 0;

            //counts LEAVE events ran
            int departureCount = 0;

            //records longest line of customers
            int longestLine = 0;

            //runs until all ENTER and LEAVE events are used and removed
            while (QueueOfEvents.Count > 0)
            {
                //Clears screen to show new info
                registerRepresentation.Clear();
                Console.Clear();

                //updates current time
                CurrentTime = QueueOfEvents.Peek().Time;

                //register that the new Customer object is going into
                int registerUsed = 0;

                //holds the amount of customers in the register that is being checked
                int registerAmount = 0;

                //Adds a customer into a line if the event is an ENTER event
                if (QueueOfEvents.Peek().Type == EventType.ENTER)
                {
                    //updates how many ENTER events have ran
                    arrivalCount++;

                    //runs through each register and finds the register with the smallest customer count
                    for (int i = 0; i < Registers.Count; i++)
                    {
                        
                        if (Registers[i].Count == 0)   //enters customer into the first empty register
                        {                            
                            registerUsed = i;
                            break;
                        }
                        else if(Registers[i].Count < registerAmount) //uses the register if its count is smaller than the amount being checked
                        {
                            registerUsed = i;
                            registerAmount = Registers[i].Count;
                        }
                        else //edit the count for the next register being checked
                        {
                            registerAmount = Registers[i].Count;
                        }
                    }

                    //Enqueues the Customer to the appropriate line
                    Registers[registerUsed].Enqueue(QueueOfEvents.Peek().Customer);  

                    //creates the LEAVE event if the Customer is the only one in the line
                    if(Registers[registerUsed].Count == 1)
                    {
                        QueueOfEvents.Enqueue(new Event(EventType.LEAVE, CurrentTime + QueueOfEvents.Peek().Customer.TimeOfService, QueueOfEvents.Peek().Customer));
                    }
                    
                }

                //LEAVE event is the on top of the queue
                else
                {
                    //adds to the Customers leaving count
                    departureCount++;

                    //runs through the registers to find the Customer leaving the store
                    for (int i = 0; i < NumberOfRegisters; i++)
                    {
                        try //finds the Customer object in the registers
                        {
                            if (QueueOfEvents.Peek().Customer == Registers[i].Peek())
                            {

                                Registers[i].Dequeue(); //removes the Customer from the register
                                QueueOfEvents.Enqueue(new Event(EventType.LEAVE, CurrentTime + Registers[i].Peek().TimeOfService, Registers[i].Peek())); //Enqueues the LEAVE event for that customer
                                break;
                            }
                        }
                        catch (InvalidOperationException) //catches if register is empty
                        {
                            continue;
                        }
                    }
                }

                for (int i = 0; i < Registers.Count; i++)
                {
                    //finds the longest line
                    if(Registers[i].Count > longestLine)
                    {
                        longestLine = Registers[i].Count;
                    }
                    
                    registerRepresentation.Append(String.Format("\n\n\n    [" + i + "]"));  //adds Register representation

                    //prints customer representation for the registers
                    foreach (object obj in Registers[i])
                    {
                        registerRepresentation.Append(String.Format(obj.ToString()));
                    }
                }

                registerRepresentation.Append(String.Format("\n\nCurrent Longest Line of the Day: " + longestLine.ToString()));  //Longest line count as of this loop
                registerRepresentation.Append(String.Format("\nCurrent Time: " + CurrentTime.ToString()));  //The time of the last event ran
                registerRepresentation.Append(String.Format("\nArrivals: " + arrivalCount.ToString() + "    Departures: " + departureCount.ToString()));  //Arrival and Departure count of Customers
                Console.WriteLine(registerRepresentation); //prints String Builder
                QueueOfEvents.Dequeue(); //gets rid of Queue ran
                Thread.Sleep(10); //pauses so information is readable
            } //end of Events while loop

            //calculates the actual average of the Customer objects
            EndAverageServiceTime /= NumberOfCustomers;

            Console.WriteLine("\n\nAverage Check-out Time: " + TimeSpan.FromMinutes(EndAverageServiceTime));  //prints average time
            Console.WriteLine("\n\nShortest Check-out Time: " + MinimumServiceTime.ToString() + "    Longest Check-Out Time: " + MaximumServiceTime.ToString());  //prints the quickest and longest checkout times            
            Console.ReadKey();  
        }

        /// <summary>
        /// Initializes the registers for the simulation
        /// </summary>
        public void CreateRegisters()
        {
            for (int i = 0; i < NumberOfRegisters; i++)
            {
                Registers.Add(new Queue<Customer>());
            }
        }

        /// <summary>
        /// Provides the Poisson distribution for the "expected" Customer count
        /// </summary>
        /// <param name="expectedNumber">expected customer count</param>
        /// <returns>actual customer count</returns>
        private int Poisson(double expectedNumber)
        {
            Random randNum = new Random();
            double limit = -expectedNumber;
            double sum = Math.Log(randNum.NextDouble());
            int actualCount;

            //adds customers until the sum of random numbers exceed the limit of expected customers
            for (actualCount = 0; limit < sum; actualCount++)
            {
                sum += Math.Log(randNum.NextDouble());
            }

            return actualCount;
        }

        /// <summary>
        /// Provides all information pertaining to the simulation
        /// </summary>
        /// <returns>output of information</returns>
        public override string ToString()
        {
            string output = "\n\nAverage Check-out Time: " + TimeSpan.FromMinutes(EndAverageServiceTime);
            output += "\n\nShortest Check-out Time: " + MinimumServiceTime.ToString() + "\nLongest Check-Out Time: " + MaximumServiceTime.ToString();
            output += "\nCustomers: " + NumberOfCustomers.ToString();
            output += "\nNumber of Registers: " + NumberOfRegisters.ToString();
            output += "\nInitial Average Checkout time: " + AverageTime.ToString();
            output += "\nTime the store opened: " + TimeStoreOpens.ToString();

            return output;
        }
    }
}
