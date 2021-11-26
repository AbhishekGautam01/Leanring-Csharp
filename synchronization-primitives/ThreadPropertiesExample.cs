// C# program to illustrate how to
// set and get the priority of threads
using System;
using System.Threading;

class GFG {

	// Main Method
	static public void Main()
	{

		// Creating and initializing threads
		Thread THR1 = new Thread(work);
		Thread THR2 = new Thread(work);
		Thread THR3 = new Thread(work);

		// Set the priority of threads
		THR2.Priority = ThreadPriority.Lowest;
		THR3.Priority = ThreadPriority.AboveNormal;
		THR1.Start();
		THR2.Start();
		THR3.Start();

		// Display the priority of threads
		Console.WriteLine("The priority of Thread 1 is: {0}",
											THR1.Priority);

		Console.WriteLine("The priority of Thread 2 is: {0}",
											THR2.Priority);

		Console.WriteLine("The priority of Thread 3 is: {0}",
											THR3.Priority);
	}

	public static void work()
	{
		// Sleep for 1 second
		Thread.Sleep(1000);
	}
}
