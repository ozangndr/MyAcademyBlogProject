using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = Roles.Admin)]
    public class ChartController(ICategoryService _categoryService,IBlogService _blogService,UserManager<AppUser> _userManager ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories =await _categoryService.GetAllAsync();
            var blogs = await _blogService.GetAllAsync();
            var users = await _userManager.Users.ToListAsync();
            var usersWithRoles = new List<dynamic>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user); // List<string>
                usersWithRoles.Add(new
                {
                    User = user,
                    Roles = roles
                });
            }

            ViewBag.UsersWithRoles = usersWithRoles;


            ViewBag.BlogCountByCategory = blogs
                                         .GroupBy(a => a.Category.Name)
                                         .ToDictionary(g => g.Key, g => g.Count());

            ViewBag.LatestBlogs = blogs
                          .OrderByDescending(x => x.CreatedDate)
                          .Take(4)
                          .ToList();
            return View();
        }
    }
}
