using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        //
        // Set up the process with the ProcessStartInfo class.
        //
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = @"C:\7za.exe"; // Specify exe name.
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        //
        // Start the process.
        //
        using (Process process = Process.Start(start))
        {
            //
            // Read in all the text from the process with the StreamReader.
            //
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.Write(result);
            }
        }
    }
}

/* OUTPUT
7-Zip (A)  4.60 beta  Copyright (c) 1999-2008 Igor Pavlov  2008-08-19

Usage: 7za <command> [<switches>...] <archive_name> [<file_names>...]
       [<@listfiles...>]
    */
