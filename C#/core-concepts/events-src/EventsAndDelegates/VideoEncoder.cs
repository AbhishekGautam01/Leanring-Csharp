namespace EventsAndDelegates
{
    public class VideoEncoder
    {
        // Steps to Implement Events on Encoding Finish
        // 1. Define the delegate - that is contract between publisher and the subcriber 
        // 2. Define an event base on that delegate 
        // 3. Raiie the event 

        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        // Old Way
        public event VideoEncodedEventHandler VideoEncoded;


        // In .net they have a delegate called: 
        // EventHandler
        // EventHandler<TEventArgs>
        // New way and this is equivalent to the above 2line
        public event EventHandler<VideoEventArgs> VideoEncodedNewWay;
        
        



        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000); // to simulate encoding process

            OnVideoEncoded(video);

        }

        // Event publisher method should by virtual and protected and in naming it should start with word On and name of Event by convention
        protected virtual void OnVideoEncoded(Video video)
        {
            // Check if event has any subscriber
            if(VideoEncoded != null)
            {
                // Calling Subscriber
                VideoEncoded(this, new VideoEventArgs() { Video = video});
            }
        }
    }
}
