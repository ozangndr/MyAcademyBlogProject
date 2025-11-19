using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Blogy.WebUI.ViewComponents
{
    public class UserSummaryViewModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; } // istersen AppUser içinde Name+Surname kullan
        public string ImageUrl { get; set; }
        public string Role { get; set; }
    }

    [ViewComponent(Name = "UserSummaryViewComponent")]
    public class UserSummaryViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserSummaryViewComponent(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Eğer kullanıcı oturum açmamışsa boş view döndür
            if (!_signInManager.IsSignedIn(HttpContext.User))
                return View<UserSummaryViewModel>("Default", null);


            // Giriş yapmış kullanıcıyı al
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return View<UserSummaryViewModel>("Default", null);


            // Roller
            var roles = (await _userManager.GetRolesAsync(user)).ToList();
            var primaryRole = roles.FirstOrDefault() ?? string.Empty;

            // Kullanıcının ismi soyismi ve profil resmini kullan (AppUser içinde alan yoksa uyarlayacaksın)
            var model = new UserSummaryViewModel
            {
                UserName = user.UserName,
                FullName = $"{user?.FirstName ?? ""} {user?.LastName ?? ""}".Trim(), // AppUser'da Name/Surname varsa
                ImageUrl = user?.Imageurl, // AppUser.ProfilePictureUrl var ise
                Role = primaryRole
            };

            return View("Default", model);
        }
    }
}
