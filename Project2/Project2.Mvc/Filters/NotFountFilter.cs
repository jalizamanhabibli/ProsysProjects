using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project2.Core.Services;

namespace Project2.Mvc.Filters
{
    public class NotFountFilter<T> : IAsyncActionFilter where T:class
    {
        private readonly IService<T> _service;

        public NotFountFilter(IService<T> service)
        {
            _service = service;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var contextData = context.ActionArguments.Values.FirstOrDefault();
            object id = contextData;

            if (contextData == null|| 0.Equals(contextData))
            {
                await next.Invoke();
                return;
            }
            var data = await _service.GetByIdAsync(id);
            if (data != null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new RedirectToActionResult("Error", "Home", new { message = "Belə bir səhifə mövcut deyil" });
        }
    }
}