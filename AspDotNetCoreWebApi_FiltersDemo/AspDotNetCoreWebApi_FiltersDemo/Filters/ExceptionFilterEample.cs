using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspDotNetCoreWebApi_FiltersDemo.Filters
{
    public class ExceptionFilterEample :  IExceptionFilter
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ExceptionFilterEample(IHostingEnvironment hostingEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }
        public int Order { get; set; }
        public void OnException(ExceptionContext context)
        {

            if (!_hostingEnvironment.IsDevelopment())
            {
                // do nothing
                return;
            }

            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var message = "Server error occurred.";

            var exceptionType = context.Exception.GetType();


            //You can enable logging error

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(new ApiResponse { Message = message, Data = null });
            
        }
    
    }


    public class ExceptionFilterEampleWithAttribute : ExceptionFilterAttribute
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public string ErrorActionName { get; set; } 



        public ExceptionFilterEampleWithAttribute(IHostingEnvironment hostingEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {

            if (!_hostingEnvironment.IsDevelopment())
            {
                // do nothing
                return;
            }

            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var message = "Server error occurred.";

            var exceptionType = context.Exception.GetType();


            //You can enable logging error

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(new ApiResponse { Message = message, Data = null });

        }

    }
}
