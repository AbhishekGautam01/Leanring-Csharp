# Reflection

* Code using reflection can **examine it's own surface** - *fields, methods and types*
* There is **significant performance loss** and code becomes **hard to maintain**

## Important questions to ask before using reflection 
1. Is there a way to solve the problem using genericity or class/interface inheritance?
2. Can I solve the problem using dynamic invocations (only .NET 4.0 and above)?
3. Is performance important, i.e. will my reflected method or instantiation call be called once, twice or a million times?
4. Can I combine technologies to get to a smart but workable/understandable solution?
5. Am I ok with losing compile time type safety?

## When to use Reflection 
* Dynamically create instance of a type. Using *Activator.CreateInstance*
* Bind type to existing object. 
* Get type of existing objects, invoke methods, access properties and fields. 
* reflection can be used to find properties that have been marked with attributes. **Use GetCustomAttributes() on each PropertyInfo to see if any of them have the <CUSTOM_ATTR_NAME> Attribute type.** . See **GetCustomAttributeReflection.cs** for example
    * I've written attributes that mark which properties in my classes should be indexed using Lucene. At runtime, I can look at any class, and figure out what fields need to get indexed by just querying the class for "marked" properties.

### Activator.CreateInstance
* Creates an instance of the specified type using that **type's parameterless constructor**.
> var handle = Activator.CreateInstance("AssemblyName", 
                "Full name of the class including the namespace and class name");
var obj = handle.Unwrap();

* if you dont pass AssemblyName then you can pass **null** , so it will create type in current assembly
> string rawLoggerType = configurationService.GetLoggerType();
Type loggerType = Type.GetType(rawLoggerType);
ILogger logger = Activator.CreateInstance(loggerType.GetType()) as ILogger;

### Feilds 
* We loop through fields and display thier names and values. **System.Reflection** provides a way to **enumerate fields and properties**. We can access **fields by name**. 
* See *FeildReflection.cs* for example

### SetValue
* This **accesses fields by their names**. This is used to **change the actual value of feilds** 
* The first argument of *SetValue* is object instance you want to mutate. For *static fields* this can be left as *null*. 
* See *SetValueReflection.cs* for example

### Methods 
* If we have name of method in *string* format but still want to call it then we can use **GetMethod** . This would return us **MethodInfo** type on which we can call **Invoke** method to make actual method call. 
* See *MethodRelection.cs* for example

    #### Instance Method Invoking
    * An instance method can be called by name but **we must provide an instance expression**
    * See *InstanceMethodReflection.cs* for example

### Properties 
* We can get *values of properties* and *loop over it.* A property can be referenced by **string**
* To get access to properties we need to first get **Type** and on that call method **GetProperties** which returns **PropertyInfo**
* See *PropertiesReflection.cs* for example

### Assembly 
* Assmebly type contains **many Type Instances** and we can call **GetCallignAssembly** which gives us types and named type array. 
* **GetCallingAssembly** - to get current assembly *returns Assembly*
* **GetTypes** - to get type instances which can be looped. *returns Type[]*
* **GetType** - It takers a string and returns a Type pointer if one of that name is located. This is called on *Assembly* type variable
* See *AssemblyReflection.cs* for example

### Benchmark, reflection 
* Don't be tempted to use reflection as it comes with *performance cost*. 
* The version that uses reflection to look up a field and set it is several hundred times slower.
* See *BenchMarkReflection.cs* for example

### Types 
* We can use **GetType** method that can be found to *object* type which helps us **discover object hierarchy**

### Typeof 
* Returns the type of a variable

### Sizeof
* This operator exposes information about the implementation of types. It doesn't require *System.Reflection* namespace. 

### Default 
*  This operator returns the default value for a type. It is used when developing classes such as generics. Use: **default(T)**