using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultLastFiveBlogsComponent(IBlogService _blogService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value=_blogService.GetAllAsync().Result.Take(5).ToList();
            return View(value);
        }
    }
}
