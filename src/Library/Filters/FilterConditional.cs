using System;
using System.Drawing;
using CognitiveCoreUCU;

namespace  CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        public bool hasFace;
        public FilterConditional()
        {
            this.hasFace = false;
        }
        
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,@"ImageRecognized");
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(@"ImageRecognized");
            
            if (cog.FaceFound)
                {
                    Console.WriteLine("Face Found!");
                    if (cog.SmileFound)
                    {
                        Console.WriteLine("Found a Smile :)");
                    }
                    else
                    {
                        Console.WriteLine("No smile found :(");
                    }
                    this.hasFace= true;
                }
                else
                {
                    Console.WriteLine("No Face Found");
                    this.hasFace = false;
                } 
            return image;   
            
        }   
   
    }
}