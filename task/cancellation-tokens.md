# Cancellation Token 
* There are multiple ways to cancel a task which depends on implmentation of task. 
* A cancellation token enables **cooperative cancellation between threads, thread pool work items or Task Objects** 
* A CT can be created by **instantiating a CancellationTokenSource object**, which manages CT retrieved from **Token** property. 
* You then pass the cancellation token to any number of threads, tasks, or operations that should receive notice of cancellation. The token cannot be used to initiate cancellation. 
* When the owning object calls CancellationTokenSource.Cancel, the IsCancellationRequested property on every copy of the cancellation token is set to true. The objects that receive the notification can respond in whatever manner is appropriate.

* In ASPNETCORE we can add a CancellationToken param to our action method in controllers. This can be passed to methods and library method calls(which might handle cancellation). 
* Some libraries can return **TaskCancelledOperation** or **OperationCancelledException**, so put an appropriate catch block and log it 
* All I/O bases libraries should support it. Handle this cancellation gracefully

## Cancellation tokens with Console App
* NET Core has done lots of work on cancellation token in background. 
* Cancellation token is by product of **CancellationTokenSource** and call method on it like **Cancel()** or **CancelAfter(time)** or we can use long polling as below 
```
while(!token.IsCancellationRequested){

}
```
* We can also use token.ThrowIfCancellationRequested() in a loop so see if cancellation is requested. 
> IMP: Always call Dispose method on CancellationTokenSource when you are done with it. 

