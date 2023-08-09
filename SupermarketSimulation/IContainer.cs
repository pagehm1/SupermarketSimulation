//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 4 - Supermarket Simulation
//	File Name:		IContainer.cs
//	Description:	Interface for the Container of the data
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
    /// methods for the Container of the data
    /// </summary>
    /// <typeparam name="T">Object within the Container</typeparam>
    public interface IContainer<T>
    {
        //clears objects from container
        void Clear();

        //checks to see if it is empty
        bool IsEmpty();

        //count of items in container
        int Count { get; set; }
    }
}
