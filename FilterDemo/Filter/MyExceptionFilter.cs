﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string exceptionMessage = context.Exception.Message;
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();

            context.ExceptionHandled = true;

            Console.WriteLine("Exception Occerd");

            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "Home" },
                    {"action", "ErrorView" }
                });
        }
    }
}
