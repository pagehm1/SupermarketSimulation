//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		Customer.cs
//	Description:	A customer that enters the line for the registers at the store
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Hunter Page, hunterpage27171@gmail.com
//	Created:		Tuesday, April 14, 2020
//	Copyright:		Hunter Page, 2020
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    /// <summary>
    /// sets the checkout time and graphic of the customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// The amount of time that the user will stay at the front of the line 
        /// </summary>
        public TimeSpan TimeOfService { get; set; }

        /// <summary>
        /// Customer ID that represents the customer
        /// </summary>
        public int CustomerNumber { get; set; }

        /// <summary>
        /// Random number instance 
        /// </summary>
        Random RandNum;

        /// <summary>
        /// Default constructor for the Customer object
        /// initializes time of service
        /// </summary>
        public Customer()
        {
            //creates random checkout time of at least two minutes
            TimeOfService = new TimeSpan(0, 2, (int)(NegativeExponential(225)));
        }

        /// <summary>
        /// parameterized constructor that creates the average time 
        /// </summary>
        /// <param name="averageTime">average checkout time for the customers</param>
        /// <param name="customerNumber">id for the customer</param>
        public Customer(double averageTime, int customerNumber, Random randomNumber)
        {
            RandNum = randomNumber;

            //creates a checkout time of at least two minutes 
            TimeOfService = new TimeSpan(0, 2, (int)NegativeExponential(averageTime));

            CustomerNumber = customerNumber; //sets customer ID
        }

        /// <summary>
        /// Creates a checkout time using a negative exponential distribution
        /// </summary>
        /// <param name="amountOfTime">Average checkout time</param>
        /// <returns>new checkout time for the customer</returns>
        public double NegativeExponential(double amountOfTime)
        {
            return -amountOfTime * Math.Log(RandNum.NextDouble(), Math.E);
        }

        /// <summary>
        /// Graphic to represent the customer
        /// </summary>
        /// <returns>Customer graphic</returns>
        public override string ToString()
        {
            string customerRepresentation;

            customerRepresentation = "[" + CustomerNumber.ToString() + ", " + TimeOfService.ToString() +"]";

            return customerRepresentation;
        }
    }
}
