//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		Event.cs
//	Description:	Simulates the customer entering or leaving the register
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
    /// ENTER involves the customer entering the line of the register
    /// LEAVE involves the customer leaving the register after the checkout time has run
    /// </summary>
    public enum EventType { ENTER, LEAVE };

    /// <summary>
    /// Simulates a customer leaving or entering at a specific time
    /// </summary>
    public class Event : IComparable
    {
        /// <summary>
        /// Customer either entering the line or leaving the register
        /// </summary>
        public EventType Type { get; set; }

        /// <summary>
        /// The time the customer either leaves or enters the line
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The customer at the register
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Default constructor for the event
        /// Sets the properties
        /// </summary>
        public Event()
        {
            Type = EventType.ENTER;
            Time = DateTime.Now;
            Customer = new Customer();
        }

        /// <summary>
        /// Parameterized constructor that initializes the properties based off other input than the initial
        /// </summary>
        /// <param name="type">The type of event</param>
        /// <param name="time">Time the user enters the line or leaves </param>
        /// <param name="customer">THe customer object</param>
        public Event(EventType type, DateTime time, Customer customer)
        {
            Type = type;
            Time = time;
            Customer = customer;
        }

        /// <summary>
        /// Compares times to determine an enter or leave event
        /// </summary>
        /// <param name="obj">Event object</param>
        /// <returns>int based off the comparison of two times</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Event))
            {
                throw new ArgumentException("The object is not an Event.");
            }

            Event newEvent = (Event)obj;

            return newEvent.Time.CompareTo(Time);
        }

        /// <summary>
        /// Displays the Customer, the event type and its time of entering or leaving
        /// </summary>
        /// <returns>string displaying the info mentioned above</returns>
        public override string ToString()
        {
            string feedback = "Customer " + Customer.ToString() +
                              "    " + Type + "s " +
                              "at " + Time.ToShortTimeString();

            return feedback;
        }
    }
}
