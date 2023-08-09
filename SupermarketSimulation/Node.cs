//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		Node.cs
//	Description:	Class that represents the Objects in the priority queue
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
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    /// <summary>
    /// Properties and  constructor of the Objects within the priority queue
    /// </summary>
    /// <typeparam name="T">Object within the node</typeparam>
    public class Node<T> where T : IComparable
    {
        /// <summary>
        /// An object T within the Node
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// The next object within the PQ
        /// </summary>
        public Node<T> NextNode { get; set; }

        /// <summary>
        /// Default constructor for the Node that sets the properties
        /// </summary>
        /// <param name="item">Object to represent the Node</param>
        /// <param name="link">The next item in the PQ</param>
        public Node(T item, Node<T> link)
        {
            Item = item;
            NextNode = link;
        }
    }
}
