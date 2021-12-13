// C# program to illustrate
// ThreadStart constructor
using System;
using System.Threading;

public class MXThread {

	// Non-static method
	public void mythr()
	{
		for (int J = 0; J < 2; J++) {

			Console.WriteLine("My Thread is"+
						" in progress...!!");
		}
	}
}

// Driver Class
public class GFG {

	// Main Method
	public static void Main()
	{
		// Creating object of ExThread class
		MXThread obj = new MXThread();

		// Creating and initializing thread
		// Using thread class and
		// ThreadStart constructor
		Thread t = new Thread(new ThreadStart(obj.mythr));
		t.Start();
	}
}

/* OUTPUT
My Thread is in progress...!!
My Thread is in progress...!!
*/