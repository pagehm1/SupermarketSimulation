//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		PriorityQueue.cs
//	Description:	Queue that places a object based off its priority compared to the other objects in the list
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Hunter Page, hunterpage27171@gmail.com
//	Created:		Tuesday, April 14, 2020
//	Copyright:		Hunter Page, 2020
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace SupermarketSimulation
{
    /// <summary>
    /// Places object in a queue based on it priority
    /// </summary>
    /// <typeparam name="T">An event for the customer</typeparam>
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        /// <summary>
        /// the node at the top of the queue
        /// </summary>
        private Node<T> TopNode;

        /// <summary>
        /// number of objects in the queue
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Modified Enqueue to fit the Priority Queue
        /// </summary>
        /// <param name="item">Event object</param>
        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                TopNode = new Node<T>(item, null);
            }
            else
            {
                Node<T> currentNode = TopNode;
                Node<T> previousNode = null;

                //compares Nodes to determine placement in the queue
                while (currentNode != null && currentNode.Item.CompareTo(item) >= 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.NextNode;
                }

                Node<T> newNode = new Node<T>(item, currentNode);

                if (previousNode != null)
                {
                    previousNode.NextNode = newNode;
                }
                else
                {
                    TopNode = newNode;
                }
            }
            Count++;
        }

        /// <summary>
        /// Modified Dequeue to fit priority Queue standards
        /// </summary>
        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from empty Queue.");
            }
            else //removes the top node from the Queue
            {
                Node<T> oldNode = TopNode;

                TopNode = TopNode.NextNode;

                Count--;

                oldNode = null;
            }
        }

        /// <summary>
        /// Clears the Priority Queue
        /// </summary>
        public void Clear()
        {
            TopNode = null;
            Count = 0;
        }

        /// <summary>
        /// Captures the top object in the PQ
        /// </summary>
        /// <returns>Object on top of PQ</returns>
        public T Peek()
        {
            if (!IsEmpty())
            {
                return TopNode.Item;
            }
            else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue");
            }
        }

        /// <summary>
        /// Checks to see if the PQ is empty
        /// </summary>
        /// <returns>true if empty, false if not empty</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    
    }
}
