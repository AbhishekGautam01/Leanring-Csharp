using System;
using System.Reflection;

class Program
{
    public void Win()
    {
        Console.WriteLine("{You're a winner}");
    }
    
    public void Lose()
    {
    }
    
    public void Draw()
    {
    }
    
    static void Main()
    {
        // Instance used for Invoke.
        Program program = new Program();
        
        // Get methods.
        MethodInfo[] methods = typeof(Program).GetMethods();
        foreach (MethodInfo info in methods)
        {
            Console.WriteLine(info.Name);
            
            // Call Win method.
            if (info.Name == "Win")
            {
                info.Invoke(program, null);
            }
        }
    }
}
Win
{You're a winner}
Lose
Draw
ToString
Equals
GetHashCode
GetType