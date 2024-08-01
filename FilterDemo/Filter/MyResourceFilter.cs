using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class MyResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("OnResourceExecuted() Executed");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("OnResourceExecuting() Executed");
        }
    }
}
