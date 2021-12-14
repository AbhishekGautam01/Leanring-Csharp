# Events
* It is a mechanism for communication between objects. 
* Used in building loosely coupled applications which helps in extending application without much effort or changes.

```
public class VideoEncoder{
    public void Encode(Video video){
        //Encoding Logic
        //...

        //Initial notification code
        _mailService.Send(new mail());
        // at later stage we add a message notification as well - But this 
        // violate OCP and we will need changes in dependent classes
        _messageService.Send(new Text());
    }
}
```

* but we can solve this problem, by making VideoEncoder Class as **publisher** of event VideoEncoded and MailService and Message Service can become **subscriber** to this published event.
* We need a contract between publisher and subscriber which can be then invoked by publisher to notify the subscriber. 
* Delegates are used to determine signature of method in the subscriber. 
* Steps to Implement Events on Encoding Finish
    1. Define the delegate - that is contract between publisher and the subscriber 
    >         public delegate void VideoEncodedEventHandler(object source, EventArgs args);
    2. Define an event base on that delegate 
    >        public event VideoEncodedEventHandler VideoEncoded;

    3. Raise the event 
        ```
        public void Encode(Video video)
                {
                    Console.WriteLine("Encoding Video...");
                    Thread.Sleep(3000); // to simulate encoding process

                    OnVideoEncoded();

                }

                // Event publisher method should by virtual and protected and in naming it should start with word On and name of Event by convention
                protected virtual void OnVideoEncoded()
                {
                    // Check if event has any subscriber
                    if(VideoEncoded != null)
                    {
                        VideoEncoded(this, EventArgs.Empty);
                    }
                }
        ```
* Another Example 
    ```
    public class Boomer{
        public event EventHandler Boom;
        public void Start(){

            // firing event
            OnBoom();
            OnBoom();
            OnBoom();
        }

        protected virtual void OnBoom(){
            Boom?.Invoke(this, EventArgs.Empty);
        }
    }

    // Program.cs
    class Program {
        static void Main(string[] args){
            var boomer = new Boomer();
            boomer.Boom += boomer_Boom;
            boomer.Start();
        }

        private static void boomer_Boom(object sender, EventArgs e){
            Console.WriteLine("Boom");
        }
    }
    ```

# [The updated .NET Core Event Pattern](https://docs.microsoft.com/en-us/dotnet/csharp/modern-events)


# Event vs Delegates 
* They both offer a late binding scenario: they enable scenarios where a component communicates by calling a method that is only known at run time.
* They both support single(single cast) and multiple subscriber(multi cast) methods.
* They both support Invoke() and use of ?.

### Listening to events is Optional
* If your code must call the code supplied by the subscriber, you should use a design based on delegates when you need to implement callback. If your code can complete all its work without calling any subscribers, you should use a design based on events.

### Return values Require Delegates
* the delegates used for events all have a void return type.

### Events have private Invocation
* Classes other than the one in which an event is contained can only add and remove event listeners; only the class containing the event can invoke the event.