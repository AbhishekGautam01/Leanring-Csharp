using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string inputFile = @"C:\programs\test.png";
        string outputFile = @"C:\programs\test.webp";
        
        // Part 1: use ProcessStartInfo class.
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.CreateNoWindow = false;
        startInfo.UseShellExecute = false;
        startInfo.FileName = @"c:\cwebp.exe";
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        
        // Part 2: set arguments.
        startInfo.Arguments = "-q 30 " + inputFile + " -o " + outputFile;
        
        try
        {
            // Part 3: start with the info we specified.
            // ... Call WaitForExit.
            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }
        }
        catch
        {
            // Log error.
        }
        
        Console.WriteLine("DONE");
    }
}
/* OUTPUT
Saving file 'C:\programs\test.webp'
File:      C:\programs\test.png
Dimension: 300 x 175
Output:    3884 bytes Y-U-V-All-PSNR 35.98 39.98 36.86   36.59 dB
block count:  intra4: 124
              intra16: 85  (-> 40.67%)
              skipped block: 33 (15.79%)
bytes used:  header:            130  (3.3%)
             mode-partition:    530  (13.6%)
 Residuals bytes  |segment 1|segment 2|segment 3|segment 4|  total
    macroblocks:  |       1%|       9%|      51%|      36%|     209
      quantizer:  |      68 |      63 |      55 |      43 |
   filter level:  |      24 |      15 |      11 |       9 |
DONE
*/