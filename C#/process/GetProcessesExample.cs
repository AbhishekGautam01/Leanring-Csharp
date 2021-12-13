using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Show all processes on the local computer.
        Process[] processes = Process.GetProcesses();
        // Display count.
        Console.WriteLine("Count: {0}", processes.Length);
        // Loop over processes.
        foreach (Process process in processes)
        {
            Console.WriteLine(process.Id);
        }
    }
}

/* OUTPUT
Count: 70
388
5312
1564
972
2152
936
3132....
*/