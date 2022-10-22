using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterSavePicture : IFilter
    {
        public IPicture Filter (IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,"PathToNewImage.jpg");
            return image;
        }
    }
}