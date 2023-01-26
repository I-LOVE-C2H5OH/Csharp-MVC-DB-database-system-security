using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using Web_api_tour.Data;

namespace Web_api_tour.Filter
{
    public class ResponseHeaderAttribute : ActionFilterAttribute
    {
        private readonly string _minLevelTrust;

        public ResponseHeaderAttribute(string minLevelTrust) =>
            (_minLevelTrust) = (minLevelTrust);



        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //context.HttpContext.Response.Headers.Add(_name, _value);

            base.OnResultExecuting(context);
        }
        
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //context.HttpContext.Response.Headers.Add(_name, _value);

            //base.OnActionExecuted(context);
        }

        // до
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cookie = context.HttpContext.Request.Cookies;

            var sss = cookie.Keys;
            try
            {
                if (context.HttpContext.Request.Cookies["key"] != null)
                {
                    var value = context.HttpContext.Request.Cookies["key"];
                    if (value != null && Users.Cokies[value] != null)
                    {
                        var levelTrust1 = Auth.levelTrust(_minLevelTrust);
                        var levelTrust2 = Auth.levelTrust(Users.Cokies[value]);

                        if (levelTrust2 <= levelTrust1)
                        {
                            context.HttpContext.Request.Headers.Authorization = "true";
                            return; 
                        }

                        context.Result = new ForbidResult("Forbidden");
                    }
                }
            }
            catch { }

            context.HttpContext.Request.Headers.Authorization = "false";

            //context.HttpContext.Response.Headers.Add(_name, _value);
            //if (_name == "Filter-Header")
            //context.Result = new RedirectResult("login");
            //base.OnActionExecuted(context);
        }
    }
}
