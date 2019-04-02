using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi_FiltersDemo.Filters
{
    public class ActionFilterExample : Attribute, IActionFilter, IOrderedFilter
    {
            public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }

    public class AsyncActionFilterExample : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int a = 10;
            // execute any code before the action executes
            var result = await next();
            // execute any code after the action executes
            a = 20;
        }
    }
    
    public class ServiceTypeActionFilter : IActionFilter, IOrderedFilter   
    {
        private ILogger _logger;

        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(_logger !=null)
            _logger.LogInformation("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        if (_logger != null)
            _logger.LogInformation("OnActionExecuting");
        }
    }

    public class ActionTypeFilter : ActionFilterAttribute
    {
        int a = 10;
        string name = "asd";
        public ActionTypeFilter(int d, string h)
        {
            a = d;
            name = h;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            int f = a;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string j = name;
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
        }
    }
}
