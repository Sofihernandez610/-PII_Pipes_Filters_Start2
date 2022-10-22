using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;
using CognitiveCoreUCU;

namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        protected FilterConditional filter;
        protected IPipe nextPipe;
        public PipeConditionalFork(IPipe nextPipe, FilterConditional filter)
        {
            this.nextPipe = nextPipe;
            this.filter = filter;
        
        }
        public IPicture Send(IPicture image)
        {
            if(this.filter.hasFace)
            {
                FilterGreyscale filterGrayScale = new FilterGreyscale();
                image = filterGrayScale.Filter(image);
                return this.nextPipe.Send(image);

            }
            else
            {
                FilterNegative filterNegative = new FilterNegative();
                image = filterNegative.Filter(image);
                return this.nextPipe.Send(image);
            }
           
            

        }
    }
}