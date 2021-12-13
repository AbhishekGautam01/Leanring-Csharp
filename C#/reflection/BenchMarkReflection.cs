using System;
using System.Diagnostics;
using System.Reflection;

class Program
{
    public static int _field;
    
    const int _max = 1000000;
    static void Main()
    {
        // Version 1: use reflection to set field by name.
        var s1 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            FieldInfo info = typeof(Program).GetField("_field");
            info.SetValue(null, 1000);
        }
        s1.Stop();
        // Version 2: set field directly.
        var s2 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            _field = 1000;
        }
        s2.Stop();
        Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
        Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
    }
}

/* OUTPUT BENCHMARKING
161.84 ns    GetField, SetValue
0.53 ns      =
*/