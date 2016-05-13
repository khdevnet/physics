using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Physics.Api.Filters
{
  
    public class HeaderAllowPaginationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
        }
    }
}