# Indexer
* It is a member of class, if we define an indexer in class then class starts behaving like an virtual array. 
* Example:
```
using System;
namespace IndexerProject {

    public class Employee {
        int Eno; 
        double Salary;
        string EName, Job, DName, Location;

        public Employee(int Eno, string eName, string Job, double Salary, string dName, string location){
            this.Eno = Eno;
            this.eName = eName;
            this.Job = Job;
            this.Salary = Salary;
            this.DName = dName;
            this.Location = location
        }
    }

    //to consume this class we add a new class TestEmployee

    public class TestEmployee {
        static void Main(){
            // here we have to pass all values
            Employee emp = new Employee(1001, "Scott", "manager", 20000, "Sales", "Mumbai");

            //default scope for members of C# class is private so on emp variable we cant access any of the members of class 
            // To access the variables from outside we have 3 options
            
            //Option 1: Declare all variables as public , but we will loose our control over that variable. 

            //Option 2: Use of properties to access this outside class. 

            //Options 3: Using Indexer:
        }
    }
}

```
<br/>

* Implementation of above code using Indexer
* **Syntax**: 

    ```
    [<modifiers>] <type> this[int index]
    {
        [get { <statements> }] // Get Accessor
        [set { <statements>}] // Set Accessor
    }
    ```

```
using System;
namespace IndexerProject {

    public class Employee {
        int Eno; 
        double Salary;
        string EName, Job, DName, Location;

        public Employee(int Eno, string eName, string Job, double Salary, string dName, string location){
            this.Eno = Eno;
            this.eName = eName;
            this.Job = Job;
            this.Salary = Salary;
            this.DName = dName;
            this.Location = location
        }

        //Indexer Implementation 
        //Instead of this int index we can also make string so we can access properties by name
        public object this[int index]{
            get {
                if(index == 0)
                    return Eno;
                else if(index == 1)
                    return EName;
                else if (index == 2)
                    return Job;
                else if(index == 3)
                    return Salary;
                else if(index == 4)
                    return DName;
                else if(index == 5)
                    return Location
                return null; //default case if no index match
            }
            set {
                if(index == 0)
                    Eno = (int)value;
                else if(index == 1)
                    EName = (string)value;
                else if (index == 2)
                    Job = (string)value;
                else if(index == 3)
                    Salary = (double)value;
                else if(index == 4)
                    DName = (string)value;
                else if(index == 5)
                    Location = (string)value;
            }
        } 
    }

    public class TestEmployee {
        static void Main(){
             Employee emp = new Employee(1001, "Scott", "manager", 20000, "Sales", "Mumbai");
             Console.WriteLine(emp[0]);
             Console.WriteLine(emp[1]);
             Console.WriteLine(emp[2]);
             Console.WriteLine(emp[3]);
             Console.WriteLine(emp[4]);
             Console.WriteLine(emp[5]);

             emp[0] = 1002;
             emp[1] = "Peter";


        }
    }
}

```