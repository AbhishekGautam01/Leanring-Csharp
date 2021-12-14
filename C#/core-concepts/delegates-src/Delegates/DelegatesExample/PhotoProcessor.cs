using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExample
{
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        // Client will be responsible for passing the filters. 
        public void Process(string path, PhotoFilterHandler filterHandler)
        {

            //System.Action<> -- points to method which doesnt return value.
            //System.Func<> -- points to method which return value.

            var photo = Photo.Load(path);
            
            filterHandler(photo);
            
            photo.Save();
        }

        public void ProcessWithAction(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path); 

            filterHandler(photo);

            photo.Save();
        }
    }
}
