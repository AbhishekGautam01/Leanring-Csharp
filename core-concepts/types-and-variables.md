# C# Types and variables
* There are 2 types in C#:
    * 	__Reference Type__
    * 	__Value Type__
### Reference Type
* Variable of reference type store reference to their data(objects)
* 2 variables can reference same object, so their operations will reflect
* Class, Interface & Delegate is used to generate reference types
* C# provides build in reference types dynamic, object and string
* Reference types are stored in managed GC heap
* Reference type extends System.Object & point to location where data is actually stored
* Eg of Objects : strings , arrays, objects of class
* When we copy reference type to another only reference is copied
* List is also a class so it is reference type
### Value Types
*  A value type is derived from System.Value type & store data in own memory location.
* All fundamental datatype in C# are value type. Bool, data , structs , enum
* Null values cant be directly assigned to value types , we should use nullable types
* When we copy value type actual value is copied
* If a value type is part of   reference type it is stored in heap otherwise stored in stack but   this depends on JIT implementation
    * Simple Value Types: 	Signed integral: sbyte, short, int, long
