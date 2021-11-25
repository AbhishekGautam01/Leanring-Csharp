using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        // Start notepad.
        Process process = Process.Start("notepad.exe");
        // Wait one second.
        Thread.Sleep(1000);
        // End notepad.
        process.Kill();
    }
}