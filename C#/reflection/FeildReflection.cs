using System;
using System.Reflection;

static class ReflectionTest
{
    public static int Height;
    public static int Width;
    public static int Weight;
    public static string Name;
    
    public static void Write()
    {
        Type type = typeof(ReflectionTest);
        // Obtain all fields with type pointer.
        FieldInfo[] fields = type.GetFields();
        foreach (var field in fields)
        {
            string name = field.Name;
            object temp = field.GetValue(null);
            // See if it is an integer or string.
            if (temp is int)
            {
                int value = (int)temp;
                Console.Write(name);
                Console.Write(" (int) = ");
                Console.WriteLine(value);
            }
            else if (temp is string)
            {
                string value = temp as string;
                Console.Write(name);
                Console.Write(" (string) = ");
                Console.WriteLine(value);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Set values.
        ReflectionTest.Height = 100;
        ReflectionTest.Width = 50;
        ReflectionTest.Weight = 300;
        ReflectionTest.Name = "Perl";
        // Invoke reflection methods.
        ReflectionTest.Write();
    }
}

/* OUTPUT
Height (int) = 100
Width (int) = 50
Weight (int) = 300
Name (string) = Perl */