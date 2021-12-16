# Dependency Injection

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