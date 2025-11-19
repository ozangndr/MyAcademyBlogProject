using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultAddCommentComponent(IBlogService _blogService, ICategoryService _categoryService, UserManager<AppUser> _userManager) : ViewComponent
    {

        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.Id.ToString()
                                  }).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await GetCategoriesAsync();
            return View();
        }
    }
}
