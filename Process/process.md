# Process
* Process is **program that is running on your computer** sucha as a small background task, or systems event handler or full blown application
* **Process.Start()** calls external applications. We can start EXE as a process but to do so `we must pass target command along with desired arguments`
* Process is **platform neutral**. Code is resilient and cross-platform 
* Namespace: **System.Diagnostics** 
* Example: See *ProcessBasic.cs*
* We can run any executable. But we may need to use properties on ProcessStartInfo. See Example *ProcessStartInfoExample.cs*

## Process vs Thread
* Both are **independent sequence of execution**
* Threads(of same process) can be run in a shared memory space while Process run in seperate memory space
*  A thread is a context of execution, while a process is a bunch of resources associated with a computation. A process can have one or many threads.
* Process has **virtual address space, executable code, open handles to system objects, a security context, a unique process identifier, environment variables, a priority class, minimum and maximum working set sizes and at lease one thread of execution**
* Thread is an entity within a process that can be scheduled for execution. 
* Each thread maintains **exception handlers, a scheduling priority, thread local storage, a unique thread identifier and a set of structures the system will use to save the thread context until it is scheduled. 

### GetProcesses 
* Gets an array of all processes currently open on the System. 
* It allows us to **Enumerate the active processes**
* It takes no args or one arg of the **target machine name**
* Example: See **GetProcessesExample.cs**

### GetProcessByName
* It returns **array of process objects**. It's functionality can be dervied by combining other methods such as *GetProcesses*
* Example: See *GetProcessByNameExample.cs*

### RedirectStandardOutput 
* This **property** is found on **ProcessStartInfo** and can be used to **redirect standard output of Process. 
* this can eliminate need of output files. 
* See Example *RedirectStandardOutputExample.cs*

### Kill
* We can kill or terminate a process that we aquire a reference to. The process is not given a chance to continue. 
* See example: KillExample.cs


### ProcessStartInfo.
* This is a class in System.Diagnostics. 
* It stores information about the process—specifically how the process is started and its configuration.

 
### Process FileName. 
* This is a property that indicates the program or file you want to run. It can be a program such as "WINWORD.EXE." Sometimes we can just specify a file name.

### Process Arguments. 
* This property stores the arguments, such as-flags or file name. This is a string property—we can assign a string to it.

### Window properties. 
* CreateNoWindow allows you to silently run a command line program. It does not flash a console window. Use WindowStyle to set windows as hidden.

### Main. 
* We can combine the Process.Start method with a console program that receives a parameter list. The program handles a string args array on invocation.

