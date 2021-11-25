using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Place exe named cwebp.exe at C directory root.
        Process.Start(@"c:\cwebp.exe",
            @"-quiet c:\programs\test.png -o c:\programs\test.webp");
        Console.WriteLine("DONE");
    }
}

/* OUTPUT
DONE
*/