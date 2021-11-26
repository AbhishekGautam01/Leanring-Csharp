// C# program to illustrate the
// concept of Join() method
using System;
using System.Threading;

public class MYThread {

	// Non-Static method
	public void mythr1()
	{
		Console.WriteLine("1nd thread is Working..!!");
		Thread.Sleep(100);
	}

	// Non-Static method
	public void mythr2()
	{
		Console.WriteLine("2nd thread is Working..!!");
	}
}

// Driver Class
public class ThreadExample {

	// Main method
	public static void Main()
	{
		// Creating instance of MYThread class
		MYThread obj = new MYThread();

		// Creating and initializing threads
		Thread T1 = new Thread(new ThreadStart(obj.mythr1));
		Thread T2 = new Thread(new ThreadStart(obj.mythr2));
		T1.Start();

		// Join thread
		T1.Join();
		T2.Start();
	}
}
