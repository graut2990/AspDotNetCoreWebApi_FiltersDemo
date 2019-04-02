using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspDotNetCoreWebApi_FiltersDemo.Filters
{
    //Using ResultFilterAttribute Class 
    public class ResultFilter : ResultFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            //Implementation
            //throw new NotImplementedException();
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //Required Implementation
        }
    }

    // IResultFilter
    public class ResultFilter1 : Attribute, IResultFilter
    {
        public  void OnResultExecuted(ResultExecutedContext context)
        {
            //Required Implementation
        }

        public  void OnResultExecuting(ResultExecutingContext context)
        {
            //Required Implementation
        }
    }
}
