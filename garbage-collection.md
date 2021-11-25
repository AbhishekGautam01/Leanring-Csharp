# Garbage Collection

* When working with **managed code** due to GC we dont have to do memroy management tasks. 

### Benefits

* No manual release of memory 
* allocates object on managed heap efficiently 
* reclaims object that are no longer being used and clears their memory. 
* Provides memory safety by making sure that an object cannot use for itself the memory allocated for another object.

### Fundamentals of memory 

* Each **process** has its own, **separate virtual address space**. All processes on the same computer share the same physical memory and the page file, if there is one.

* As an application developer, _you work only with virtual address space and never manipulate physical memory directly_. The garbage collector allocates and frees virtual memory for you on the managed heap.

* Virtual memory can be in three states:
    * **Free**: The block of memory has **no references** to it and is available for allocation.
    * **Reserved**: The block of memory is **available for your use and cannot be used for any other allocation request**. However, you cannot store data to this memory block until it is committed.
    * **Committed**: The block of memory is **assigned to physical storage.**
* Virtual address space can get **fragmented**. This means that there are free blocks, also known as **holes**, in the address space. When a virtual memory allocation is requested, the virtual memory manager has to find a single free block that is large enough to satisfy that allocation request. 
* You can run out of memory if there isn't enough virtual address space to reserve or physical space to commit.

### Memory Allocation 
* When a new process is initialized, _runtime reserves a contiguous region of address space for the process known as **managed heap**
* it maintains a pointer to where next data is present in managed heap . 
* Allocating memory space for new objects is **faster in managed heap as compared to unmanaged memory allocation** becuase runtime allocates **memory to object by adding a value to pointer.** which is as fast as allocating memory from the stack. As objects are **allocated consecutively are stored contiguously in heap so application can access it faster**

### Memory release 
* The GC optimizing engine determines the best time to perform collection based on allocations. 
* During collection, GC determines **which objects that are no longer being used by examining the application's root**. 
* **Application ROOT:** It includes  **static fields, local variables on a thread's stack, CPU registers, GC handles, and the finalize queue**
    * Root either refers to an object on the managed heap or is set to null. 
> **IMPORTANT : GC PROCESS**
> 1. Using this list(Application root graph) GC **creates a graph of all reachable objects from roots**
> 2. As it discoveres each unreachable object, it uses **memory-copying function** to compact the reachable objects in memory, thus freeing up unreachable objects. 
> 3. Once this compaction is completed then nessesary **pointer changes** are made to point to new location. Also managed heaps' **pointer is placed after the last reachable objects**

> **LARGE OBJECTS**: 
    1. For perf concerns Large objects are allocated in seperate heap and to avoid moving large objects in memory no compaction is performed. 

### Conditions for a garbage collection 

* GC occours when one of the following conditions is true: 
    * System has **low physical memory.** either indicated by _memory notif by OS_ or _low memory as indicated by host_
    * Memory use on allocated heap surpasses an **acceptable threshold**
    * The **GC.Collect** is called. 

### Managed Heap

* Each managed process gets a managed heap. 
* GC calls Windows **VirtualAlloc** function and reserves one segment of memory at a time for managed application. 
* GC allocates and releases memory(using **VirtualFree**) as needed. 
* During collection by GC, then **dead space** is removed thus **reducing heap size**
* HEAP = **ACCUMULATION-OF-TWO-HEAPS(Large Object Heap, Small Object Heap)**

# [`Generations-0, 1, 2 link click here`](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals#generations)

### Survival and Promotions
* Objects that are _not reclaimed in a garbage collection_ are known as **survivors** and are _promoted to the next generation_. Object surving generation 2 remains in generation 2. 

### What happens during garbage collection
A garbage collection has following phases: 
1. **marking phase** - Find and create list of **live objects**
2. **Reallocating phase** - The references to the objects that will be compacted 
3. **Compacting Phase** - Reclaim space occupied by dead objects and compact surving objects. 

## Unmanaged resources: 
* Unmanaged resources require explicit cleanup.
* Most Common type of unmanaged resource is **which wraps an operating system resource** such as file handle, window handle, or network connection. 
* GC can track lifetime of **managed resource which wraps the unmanaged resource** but it doesnt know how to perform the cleanup. 
* it's nessesary to provide **public Dispose** method

### Memrory leak 
* A memory leak occours when an application does not release that memory thus preventing it from being reallocated. 
* Classes which reference unmanaged resources directly should ensure that those resources are correctly deallocated. 
> **EXAMPLE** 


public void ManagedObject : IDisposable
{
    //A handle to some native resource.
    int* handle;

    public ManagedObject()
    {
        //AllocateHandle is a native method called via P/Invoke.
        handle = AllocateHandle();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            //deal with managed resources here
            FreeHandle(handle);
        }
    }

    ~ManagedType()
    {
        Dispose(false);
    }
}

* **disposing** parameter is false when called from a *finalizer*. This is to prevent managed resources being used within the finalizer as managed references should be considered invalid at that stage. 
* The **Dispose()** method calls **GC.SuppressFinalize(this)** which prevents the finalizer from running for that instance. This is done because the resources that would have been deallocated in the finalizer were deallocated in the dispose call making **finalizer invocation unnescessary**

> **IMPORTANT** : Client code that makes use of classes that handle unmanaged resources (or any class that implements IDisposable) should do so within a using block to ensure that the IDisposable.Dispose is called when access to the resource is no longer needed as this will take care of both managed and unmanaged resources