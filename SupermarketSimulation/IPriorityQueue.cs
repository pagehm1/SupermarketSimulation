//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		IPriorityQueue.cs
//	Description:	Interface for the Priority Queue
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
    /// interface for the priority queue where the object is IComparable
    /// </summary>
    /// <typeparam name="T">An Event Object</typeparam>
    public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
    {
        //inserts an item based on priority
        void Enqueue(T item);

        //removes first item in the queue
        void Dequeue();

        //Checks top item in queue
        T Peek();
    }
}
