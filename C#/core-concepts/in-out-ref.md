# Working of In, Out, and Ref 
## Out 
* It's more like ref with some  modification. 
* Most common built in use cases of this is Try.. methods, which usually returns a boolean and a cast value. 
* Out values can be **pre-initialized**
```
int value = 5;
var couldParse = int.TryParse("hfjkfd", out value); // This code would compile even though 
//we have initialized a value of out variable  but we just remove the int keyword after out keyword
Console.WriteLine(value);
```
> **NOTE** Fundamentally any value type is passed by copying a value so any changes made doesn't reflect the original value of variable however in this the original value of var value is changed even though it is value type this is because out is acting as ref. 

> **NOTE** While doing method overloading we cannot have an overload with Same Name but only differentiate by ref and out however we can have overloads such that one uses out and other is just passByValue. 
    void ExampleOut(out int intValue)
    void ExampleOut(int intValue)
Both of these are valid overloads. 

* Another **limitation** of this is, we cannot use this in async methods or any iterator method which uses yield break or yield break. 

## In Keyword
* In makes your value immutable i.e. you cannot be able to change it. 
* When you do **lowering** on your code you will get to know in keyword is nothing but **[In][IsReadOnly] ref int value** ref with In and IsReadOnly Attributes. 
* when you are passing a big struct which is value type, making a value type copy takes up time, so we make such makes input parameter in to avoid copying and any changes in parent method doesn't effect in child method. 
* Without IN also if to make any property readonly we can declare properties without setter and then initialize these property from a parameterized constructor. 