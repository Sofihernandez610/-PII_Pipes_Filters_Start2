using System;
using TwitterUCU

namespace CompAndDel.Filters
{
    public class TwitterFilter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,@"PublishedImage.png");
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Imagen transformada", @"PublishedImage.png"));
            return image;
        }
       
    }
}