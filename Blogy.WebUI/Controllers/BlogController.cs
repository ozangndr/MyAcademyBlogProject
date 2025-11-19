using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.AiServices;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Blogy.WebUI.Controllers
{
    public class BlogController(IBlogService _blogService, ICategoryService _categoryService, IMapper _mapper, ICommentService _commentService,UserManager<AppUser> _userManager,AIService _aiService) : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {

            var blogs = await _blogService.GetAllAsync();
            ViewBag.BlogCountByCategory = blogs
                                         .GroupBy(a => a.Category.Name)
                                         .ToDictionary(g => g.Key, g => g.Count());


            ViewBag.Last3Blogs = blogs.OrderByDescending(b => b.Id).Take(3).ToList();            
            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);
            return View(values);
        }


        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            ViewBag.categoryName = category.Name;
            var Blogs = await _blogService.GetBlogsByCategoryIdAsync(id);
            return View(Blogs);
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _blogService.GetSingleByIdAsync(id);
            var blogs = await _blogService.GetAllAsync();
            ViewBag.Last3Blogs = blogs.OrderByDescending(b => b.Id).Take(3).ToList();
            ViewBag.BlogCountByCategory = blogs
                                         .GroupBy(a => a.Category.Name)
                                         .ToDictionary(g => g.Key, g => g.Count());
            return View(blog);
        }




        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            // Kullanıcı giriş yapmamışsa
            if (!User.Identity.IsAuthenticated)
            {
                TempData["CommentError"] = "Yorum yapabilmek için giriş yapmalısınız.";
                return RedirectToAction("BlogDetails", new { id = createCommentDto.BlogId });
            }

            // ModelState ve içerik kontrolü
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(createCommentDto.Content))
            {
                TempData["CommentError"] = "Yorumunuz boş veya geçersiz.";
                return RedirectToAction("BlogDetails", new { id = createCommentDto.BlogId });
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createCommentDto.UserId = user.Id;

            try
            {
                // 1️⃣ Yorumun İngilizceye çevrilmesi
                string englishText = await _aiService.TranslateToEnglish(createCommentDto.Content);
                TempData["DEBUG_TRANSLATION"] = "Çeviri Sonucu: " + englishText;

                // 2️⃣ Toksisite skorunun hesaplanması
                float score = await _aiService.GetToxicityScore(englishText);
                TempData["DEBUG_TOXICITY"] = "Toxicity Score: " + score;

                // 3️⃣ Eğer toksik ise kaydetme
                if (score > 0.5f) // Buradaki eşik değeri ayarlayabilirsin
                {
                    TempData["CommentError"] = "Yorumunuz toksik içerik içeriyor ve kaydedilmedi.";
                    return RedirectToAction("BlogDetails", new { id = createCommentDto.BlogId });
                }

                // 4️⃣ Eğer toksik değilse kaydet
                await _commentService.CreateAsync(createCommentDto);
                TempData["CommentSuccess"] = "Yorumunuz başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                TempData["CommentError"] = "Yorum eklenirken bir hata oluştu: " + ex.Message;
            }

            return RedirectToAction("BlogDetails", new { id = createCommentDto.BlogId });
        }






    }
}
