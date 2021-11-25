using System;
using System.Reflection;

class Program
{
    public static int _field; // Must be public!
    
    static void Main()
    {
        // Get FieldInfo on Program type.
        FieldInfo info = typeof(Program).GetField("_field");
        
        // Set static field to this value.
        info.SetValue(null, 1969);
        
        // Now see what _field equals.
        Console.WriteLine(_field);
    }
}
// OUTPUT : 1969