
using System;
using System.Reflection;

class Box
{
}

class Program
{
    static void Main()
    {
        // Get assembly.
        Assembly assembly = Assembly.GetCallingAssembly();
        
        // Get array of types.
        Type[] types = assembly.GetTypes();
        foreach (Type t in types)
        {
            Console.WriteLine(t);
        }
        Console.WriteLine();
        
        // Get type by name.
        string name = "Box";
        Type type = assembly.GetType(name);
        Console.WriteLine(type);
    }
}

/* OUTPUT
Box
Program

Box
*/