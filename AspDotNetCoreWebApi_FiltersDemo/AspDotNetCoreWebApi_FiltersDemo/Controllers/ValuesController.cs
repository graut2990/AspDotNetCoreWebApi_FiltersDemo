using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreWebApi_FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreWebApi_FiltersDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    //[MiddlewareFilter(typeof(HtmlMinificationPipeline))] ,[ServiceFilter(typeof(ActionFilterExample))]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        //[ActionFilterExample(Order =3), ServiceFilter(typeof(ServiceTypeActionFilter),Order =2), AsyncActionFilterExample(Order =1)]
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")] [ResultFilter, ResultFilter1, ResourceFilter,]
        [TypeFilter(typeof(ActionTypeFilter), Arguments = new object[] { 15, "Gaurav" })]
        public ActionResult<string> Get(int id)
        {
            return string.Empty;
            //throw new NotImplementedException();
        }

        // POST api/values
        [HttpGet("{id:alphanumeric}"),]
        [ServiceFilter(typeof(ClassConsoleLogActionOneFilter))]
        public void GetValue(string id)
        {
            var d = id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
