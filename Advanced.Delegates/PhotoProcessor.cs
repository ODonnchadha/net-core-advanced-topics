namespace Advanced.Delegates
{
    /// <summary>
    /// With the PhotoFilterHandler, client will define the filters to apply.
    /// </summary>
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);
            //var filters = new PhotoFilters { };
            //filters.ApplyBrightness(photo);
            //filters.ApplyContrast(photo);
            //filters.Resize(photo);

            photo.Save();
        }
    }
}
