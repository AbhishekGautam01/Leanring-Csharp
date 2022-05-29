# Dependency Injection
* DIP states: 
    1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
    2. Abstractions should not depend on details. Details should depend on abstractions.
## Why we need it?
* It helps to **decouple two classes** that otherwise are tightly coupled, which helps improving and more maintainability. 
* It improves reusability especially when you need to change low level classes. 
* It helps replace implementation on the fly. 

# dependency lifetimes
1. **Transient** : This lifetime definition makes DI to create a new instance whenever requested
2. **Scoped** : This makes DI to create a new instance for each new scope. Here scope refers usually to a new web request.
3. **Singleton**: This creates a new instance only on the first request and the same instance is served to all the consumer class for the rest of the application lifetime.

# Best Practices
1. Scoped service should normally be used by a single web-request/thread. **You should not share service scopes across threads** 
2. Services configured as singleton might cause **Memory Leaks(Memory leak occurs when programmers create a memory in heap and forget to delete it.)** in application. 
3. Memory leaks are generally caused by singleton services. This is because the instance created is not disposed of, it will stay in memory until the end of the application. So it is good to release them once they are not used.
4. With services registered as transient has a shorted lifespan so you might generally don’t care too much about the multi-threading and memory leaks.
* **Do not depend** on a transient or scoped service in a singleton service. Because the transient service becomes a singleton instance when a singleton service injects it and that may cause problems if the transient service is not designed to support such a scenario. ASP.NET Core’s default DI container already throws exceptions in such cases.

# Dependency Injection vs Dependency Inversion vs Inversion of Control 
## Inversion of Control 
* Principle **that inverts the flow of control in an application** 
* In **tradition programming**, main does the instantiation, calls method, asks for user input **where as** in **IoC**, it is the framework that does the instantiation, method calls and trigger use actions, **having full control of flow**
* Introduced in 1988 by Ralph E. Johnson and Brian Foote
* IoC is **achieved** by allowing the framework to do the binding and instantiation of dependencies. 
<br/>

## Dependency Injection 
* It is technique where the creation and binding of dependencies are done outside of the dependent class. 
*  in contrast to the dependent class having to instantiate its dependencies internally, and having to know how to configure them, thus causing coupling.
*  Dependency Injection was the name coined by Martin Fowler in 2004 to have a better, and more specific name for this style, as opposed to the overly generic term Inversion of Control used by many frameworks.
* It can be achieved by : 
    1. **Constructor Injection**: When dependencies are provided through the dependent class constructor
    2. **Interface Injection**: When dependencies are provided directly into a dependent class method as an argument
    3. **Setter Injection**: When dependencies are provided via public property of dependent class. 

* There are other patterns where dependencies can be configured, instantiated and provided to a class for its usage, for example the Service Locator Pattern, in which classes depend on a service locator instance that would wire and provide the dependencies on command.
<br/>

## Dependency Inversion Principle (DIP)
* It was conceived by Uncle Bob(Robert Martin) in 1994 
* High-level modules should not depend on low-level modules. Both should depend on abstractions.
    * A **high-level module**, in this context, is a class that depends on a service, therefore, it is the service’s client. It is the high-level module that contains the important policy decision and business logic of an application. The low-level module is the class that will provide certain functionality to its client, therefore the service.
    * If a client depends on the implementation of a service, then when the service’s interface is changed, by consequence the client must change (and also its tests).
    * If we invert this dependency so that the high-level module determines that the low-level module must implement, then the **low level module can change as long as it's contract is respected**
* Abstractions should not depend on details. Details should depend on abstractions
![img](./img/1_HQ1mQ3gLn1YnCLzzzL6jqg.png)


# Dependency Injection and Delegates

```
// Dependency Resolver

namespace ProjectNamespace{
    public delegate IProcessorService ProcessorServiceResolver(ProcessType key)
    public static class DependencyResolver {


        public static IServiceCollection AddServices(this IServiceCollection services){
            services.AddTransient<TypeAProcessor>();
            services.AddTransient<TypeBProcessor>();
            services.AddTransient<TypeCProcessor>();

            services.AddTransient<ProcessorServiceResolver>(serviceProvider => key => {
                switch(key){
                    case ProcessType.TypeA: 
                        return serviceProvider.GetService<TypeAProcessor>();
                    case ProcessType.TypeB:
                        return serviceProvider.GetService<TypeBProcessor>();
                    case ProcessType.TypeC:
                        return serviceProvider.GetService<TypeCProcessor>();
                    default: 
                        throw new InvalidOperationException("Can not resolve service type);
                }
            });

            return services;
        }
    }
}

// IProcessorService 
public interface IProcessorService{
    Task<Response> Process(Request request);
}

// TypeAProcessor
public class TypeAProcessor : IProcessorService{ }

// TypeBProcessor
public class TypeBProcessor : IProcessorService { }

// TypeCProcessor 
public class TypeCProcessor : IProcessorService { }

// Process Workflow class
public class ProcessWorkflow {
    private readonly ProcessorServiceResolver _processorResolver;

    public ProcessWorkflow(ProcessorServiceResolver processorServiceResolver){
        _processorResolver = processorServiceResolver;
    }

    public async Task<Response> ProcessRequestAsync(Request request, ProcessType type) {
        var response = await _processorResolver(type).Process(request);
        return response;
    }
}
```