using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            // Omit the exe part.
            Process[] chromes = Process.GetProcessesByName("chrome");
            Console.WriteLine("{0} chrome processes", chromes.Length);
            Thread.Sleep(5000);
        }
    }
}

/* OUTPUT 
0 chrome processes
3 chrome processes
4 chrome processes
5 chrome processes
5 chrome processes
5 chrome processes
*/