using Blogy.Business.DTOs.AboutDtos;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Business.Services.AboutServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class AboutController(IAboutService _aboutService,UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values =await _aboutService.GetAllAsync();
            var value=values.OrderByDescending(x=>x.Id).FirstOrDefault();
            return View(value);
        }

        
    }
}
