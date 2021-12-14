namespace DelegatesExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            
            // Example of Multicast delegate
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyConstrast;
            filterHandler += RemoveRedEyeFilter;


            // Example of Action Delegate
            Action<Photo> filterHandlerWithAction = filters.ApplyBrightness;
            filterHandlerWithAction += filters.ApplyConstrast;
            filterHandlerWithAction += filters.Resize;
            filterHandlerWithAction += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);
            processor.ProcessWithAction("photo.jpeg", filterHandlerWithAction);
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Removing Red Eye...");
        }
    }
}
