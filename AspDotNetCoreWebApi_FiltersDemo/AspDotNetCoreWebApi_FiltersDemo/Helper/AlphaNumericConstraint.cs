using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AspDotNetCoreWebApi_FiltersDemo.Helper
{
    public class AlphaNumericConstraint : IRouteConstraint
    {
        private static readonly TimeSpan RegexMatchTimeout = TimeSpan.FromSeconds(10);

        public bool Match(HttpContext httpContext,
            IRouter route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            //validate input params  
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            if (route == null)
                throw new ArgumentNullException(nameof(route));

            if (routeKey == null)
                throw new ArgumentNullException(nameof(routeKey));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            object routeValue;

            if (values.TryGetValue(routeKey, out routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);
                bool value =  new Regex(@"^[a-zA-Z0-9]*$",
                                RegexOptions.CultureInvariant
                                | RegexOptions.IgnoreCase, RegexMatchTimeout).IsMatch(parameterValueString);

                return value;
            }

            return false;
        }

      
    }
}