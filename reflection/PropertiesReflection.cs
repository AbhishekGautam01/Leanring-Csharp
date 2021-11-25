using System;
using System.Reflection;

class Program
{
    public int Awesome { get; set; }
    public string Perls { get; set; }
    
    static void Main()
    {
        // Create an instance of Program.
        Program programInstance = new Program();
        programInstance.Awesome = 7;
        programInstance.Perls = "Hello";
        
        // Get type.
        Type type = typeof(Program);
        
        // Loop over properties.
        foreach (PropertyInfo propertyInfo in type.GetProperties())
        {
            // Get name.
            string name = propertyInfo.Name;
            
            // Get value on the target instance.
            object value = propertyInfo.GetValue(programInstance, null);
            
            // Test value type.
            if (value is int)
            {
                Console.WriteLine("Int: {0} = {1}", name, value);
            }
            else if (value is string)
            {
                Console.WriteLine("String: {0} = {1}", name, value);
            }
        }
    }
}
/* OUTPUT
Int: Awesome = 7
String: Perls = Hello
*/ 