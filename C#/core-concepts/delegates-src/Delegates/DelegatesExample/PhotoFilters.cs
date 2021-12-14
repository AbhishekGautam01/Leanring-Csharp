namespace DelegatesExample
{
    internal class PhotoFilters
    {
        public PhotoFilters()
        {
        }

        internal void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Applying Brightness...");
        }

        internal void ApplyConstrast(Photo photo)
        {
            Console.WriteLine("Applying Constrast...");
        }

        internal void Resize(Photo photo)
        {
            Console.WriteLine("Resizing Photo...");
        }
    }
}