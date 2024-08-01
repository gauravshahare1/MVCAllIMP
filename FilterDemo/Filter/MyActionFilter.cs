using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted() Executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting() Executed");
        }
    }
}
