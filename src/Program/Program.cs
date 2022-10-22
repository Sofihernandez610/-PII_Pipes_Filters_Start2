using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
//SOFIA
namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            PipeNull pipenull = new PipeNull();
            FilterSavePicture filterSavePicture = new FilterSavePicture();
            TwitterFilter twitterFilter = new TwitterFilter();
            FilterNegative filternegative = new FilterNegative();
            PipeSerial pipeserial = new PipeSerial(filternegative, pipenull);
            FilterGreyscale filtergrayscale = new FilterGreyscale();
            PipeSerial pipeserial1 = new PipeSerial(filternegative, pipeserial);
            FilterConditional filterconditional = new FilterConditional(); 
            PipeConditionalFork pipeconditionalfork = new PipeConditionalFork(pipeserial1,filterconditional);
            PipeSerial pipeserial2 = new PipeSerial(filternegative, pipeconditionalfork);
           // PipeFork pipefork = new PipeFork(pipeserial,pipenull);
            //pipefork.Send(picture);
            picture = filtergrayscale.Filter(picture);
            picture = filterconditional.Filter(picture);
            picture = twitterFilter.Filter(picture);
            picture = filternegative.Filter(picture);
            provider.SavePicture(picture, @"luke1.jpg");
            
        }
    }
}
