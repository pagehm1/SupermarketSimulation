# SupermarketSimulation

## Original Assignment Specs

Write a C# program to simulate the operation of the check-out lanes at the new supermarket.  
You may assume that customers arrive at the check-out lines at the supermarket according to a uniform distribution throughout the entire day’s hours of operation.  
The time required to process a given customer once he or she has reached the front of the checkout line is determined from a (negative) exponential distribution.  
Create classes for Customer and Event.  For the purposes of this assignment, an Event is a customer entering a line waiting at a register or a customer leaving the register line when he/she has been processed.  A customer does not begin to check out, obviously, until reaching the front of the register line.  
The Supermarket class should manage the simulation using the Customer and Event classes and the data structures needed.  
Though the supermarket’s management expects a certain number of customers per day and a certain number of hours of operation each day, they want your solution to be flexible enough to be able to answer “what if” questions such as: <br/>
⦁	What if we stayed open a half-hour less? <br/>
⦁	What if we expected a different number of customers on the average? <br/>
⦁	What if the expected service time or the minimum service time at a register changes? <br/>

## Original specifications

Use a PriorityQueue to manage the Events, and use a Queue of Customers to simulate a single line of customers at a register.  Use a List < Queue <Customer> > to simulate the collection of lines at the registers.  The goal is to find the smallest number of Queues the List must have to be sure the individual register lines do not exceed two customers in length.  You may make these assumptions.
⦁	Customers always enter the shortest line and that, once in a line, they do not change lines.  <br/>
⦁	The supermarket will remain open until the last person completes his/her service, but no one will enter a checkout line after closing time.  <br/>
⦁	During execution, you should display enough information in sufficient detail to show that your simulation is working and that you are tracking the proper pieces of information.  This should include (but is not limited to) pseudo-graphical information showing the simulation in progress.  <br/>
⦁	The design of the user interface is up to you, but it must be such that you are able to convince your customer that your answer is correct and not just some numbers you made up. <br/>
Your program should be flexible enough so that if the supermarket decided to stay open longer, close earlier, handle more (or fewer) customers, or deal with a situation in which the expected service time changes, you could provide a reasonably quick solution to the problem for the modified set of parameters.  You may use a Windows Forms solution or a menu-driven console application for your project.
