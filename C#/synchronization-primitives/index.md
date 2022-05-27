# Synchronization Techniques 

## Concurrency vs Parallelism vs Asynchronous execution 
* **Concurrent** multiple pieces of work done in overlapping time, which may or may not be parallel (multiple threads sharing same processor core). 
    * The application is making progress on one or more task at same time. 
    * EG: Application processing multiple requests on different threads. 
    * It means doing multiple things at same time but **not specifically using multiple threads** EG; **javScript** uses **Event Loop** to implement concurrency using single thread. 
* Even when we have CPU with one core, we have concurrency as two tasks may complete in overlapping time but not nessesasrily parallel.
> **NOTE** In a single core env, concurrency is achieved using **context switching**
> In **multi core env** concurrency is achieved using **parallelism** 

<br/>
<br>

* **Parallelism**: Means multiple things are done at same point of time unlike concurrency which is in overlapping period of time. 
* EG: Threads running in different processor core. 
* AN app splits a related task into smaller tasks which can be processes parallely. 
> **NOTE**: For true parallelism, an application must have more than 1 threads running or **at least be able to schedule tasks for execution into other threads, processes, CPUs, Graphics card, etc. 

<br/>
<br>

* **Asynchronous Execution**: An operation which is started **out-of-sync in time** which will run on its own and notify us when completed. 
* this may involve threads running in **same or different cores or even in different systems.**
* Async programming model helps us to achieve concurrency by **allowing a single thread to start one task and then do somethign else instead of waiting for first task to complete.**

## Different types of sync and aysnc executions in Single and Multi threaded environment 
### Synchronous 
1. **Single threaded**: Each task gets executed one after another.
![img](./img/1629620180511.jfif)
2. **Multi Threaded Environment**: Tasks get executed in different threads but wait for any other executing tasks on any other thread. 
![img](./img/1629620095502.jfif)
### Asynchronous 
1. **Single Threaded**: Tasks start executing without waiting for a different task to finish. At a given point of time, single task is executed. 
![img](./img/1629620310745.jfif)
2. **Multi Threaded**: Tasks gets executed in different threads without waiting for any tasks independently finsihs of thier executions. 
![img](./img/1629620285914.jfif)


# Threads 
* A basic unit of execution that is allocated processor time by OS. It is sequence of program instructions, that can be managed independently by a scheduler( called **thread scheduler**) which is part of OS. 

* **Application**: Consists of one or more **processes**
* **process**: Executing program for an application. 
* Every single process can have one or more threads running in the context of the process. 
* **Program Executiong Models**: 
    * **Single threaded**: Only one thread has full acess to runnig process. 
    * **Multi Threaded**: Multiple threads exists and run independently but share same resources within the process. 

## Most Common Threading Scenarios
* **Thick client applications**: where there is a UI thread that delegates CPU-bound code on a different thread
* **Divide and conquer algorithms**, which take advantage of multiprocessor computers
* **Scalability** (for web servers), which is the ability to handle large volume of incoming http requests
* **Example**
![img](./img/1629621851006.jfif)