# Task vs Threads 
* **THREADS**
    * Lowest level construct of multi-threading. 
    * Basic unit of execution allocated processor time by OS 
    * Working with threads can be challenging and complex to manage it. 
* **TASK**
    * Higher level .NET abstraction that basically represents a promise of a separate work, that will be completed in future.
    * They can return values, chained by using tasks continuation. 
    * Extremely handy for I/O operations and can use thread pool. 
> **NOTE**: Just using a Task in .NET code does not mean there are separate new threads involved.

# When to use task or threads? 
* A thread is a **low-level thing** gives maximum flexibility to control execution and manage some attached resources. 
* **Creating, Starting, Stopping** takes time & consumes resources.
* Whereas a **thread pool** thread is not **created or terminated** once done. 
* **PROBLEM WITH MANUAL CREATION**: As we keep creating more and more threads there can be more threads than CPU Core, due to which **OS will need to do context switching** which is heavy operation. 
* Managing and synchronizing them can be complex.

<br/>

* in **modern .NET programming**, it is recommended to use Task instead
> **NOTE**: The way Task and modern ThreadPool are created, they are pretty much multi-core aware. That means, if there are multiple CPUs available in the system, tasks will try to utilize them in an efficient way.

## Starting new task in our code
1. **new Task(Action).Start()**: Creates a new Task and gives it the Action to run and then it starts it. Avoid generally using this option, as it needs synchronization to avoid race conditions, where multiple threads try to start a task (that is try to call .Start())
2. **Task.Factory.StartNew(Action)**: First starts the task then returns a reference to that task. This is safe and saves the synchronization cost. Generally prefer this option over the first one
3. **Task.Run(Action)**: Task.Run() gives the Action to run on the ThreadPool, which takes a thread from the ThreadPool and runs our code on that thread as per schedule and availability. Once the Action is completed, the thread is released back to the thread-pool. This differs if a Task is marked to be a LongRunning task. For a long-running task, a new thread is used. A long running (usually 0.5 seconds or more) operation should be run as LongRunning as that’ll not block thread pool threads, which can efficiently run smaller tasks and rotate.
![img](./img/1630227943755.jfif)
![img](./img/1630228350228.jfif)

# Cancelling Task 
* To be able to cancel a task, we need to start a task with **cancellation token**. 
* The cancellation token is generated with the use of a **cancellation token source** object. 
* Cancellation can be requested on the token source later. 
> **NOTE**: just requesting a cancellation does not guarantee immediate cancellation of the task, or even any response at all. It is up to the underlying task code to periodically check for cancellation request and respond accordingly,

# TASK Parallel Library
* TPL is a set of public types & APIs in two namespaces: 
    1. System.Threading
    2. System.Threading.Tasks
* **Simplifies** process of adding concurrency and parallelism to application. 
* Keep in Mind: 
    1. Not all code is suitable for parallelization
    2. Threading of any type has an associated overhead. For ef. Function running in few milliseconds using multiple threads might not help the overall performance.
    3. Multi threading may be slower than just simple plain sequential code. 
* Internally **TPL uses Tasks in optimized way**
* We have **Task Parallelism** and **Data Parallelism**

## Task Parallelism 
* One or more independent tasks running concurrently. 
    * More efficient ot use system resources. tasks are queued to thread pool which is optimized. 
    * More programmatic control **( support for task waiting, cancellation, continuations, robust exception handling)** than is possible with thread

## Data Parallelism
* Same operation is performed in parallel on elements ina source collection or array. Source collection is partitioned so that multiple threads can operate on different segments concurrently. 

# Async & Task based asynchronous pattern

* ask-based async APIs and the language-level asynchronous programming model invert this model, making async execution the default one. Async code has the following characteristics:
    * Handles more server requests by yielding threads to handle more requests while waiting for I/O requests to return. 
    * Enables UIs to be more responsive by yielding threads to UI interaction while waiting for I/O requests and by transitioning long running work to other CPU cores. 

* tasks are constructs used to implement what is known as the **promise model of concurrency**
> **NOTE** Tasks are abstractions of work happening asynchronously, and not an abstraction over threading.

## Different asynchronous programming patterns
* **Task based asynchronous pattern (TAP)**
    * Introduced in .net framework 4 and recommended approach to async programming. 
    * async await keywords support TAP 
* **Event based Asynchronous Pattern**
    * Legacy model for providing asynchronous behavior
    * no longer recommended
* **Asynchronous Programming model(APM)**
    * Legacy model that uses IAsyncResult 


## TAP PAttern
1.Be declared with an “Async” suffix 
2. Have a return value of Task or Task\<TResult>
3. Be overloaded to accept a CancellationToken and / or an IProgress<T> to support cancellation or progress reporting
4. Make sure that returns quickly to the caller (the initial synchronous phase should be the smallest possible)
5. Make sure that it frees up the UI thread as quickly as possible if it is an I/O bound task (out-of-process call)