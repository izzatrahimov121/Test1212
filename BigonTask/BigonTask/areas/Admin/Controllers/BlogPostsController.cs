using BigonTask.Models.Entities;
using BigonTask.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BigonTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        readonly private DataContext db;
        private readonly IWebHostEnvironment env;

        public BlogPostsController(DataContext db,IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
           var posts = db.BlogPosts
                 .Where(m => m.DeletedBy == null)
                 .ToList();
            return View(posts);
        }

        public IActionResult Create()
        {
            var categories= db.Categories.Where(m=>m.DeletedBy==null)
                .Select(m => new { m.Id, m.Name })
                .ToList(); 
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogPost model,IFormFile file)
        {
            string imageRandomName=Guid.NewGuid().ToString();
            string extension=Path.GetExtension(file.FileName);
            string nameWithExtension = $"{imageRandomName}{extension}";
            string fullPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", nameWithExtension);
            using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fs);
            }
            model.ImagePath = nameWithExtension;
            model.Slug = imageRandomName;
            db.BlogPosts.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int Id)
        {
            var model = db.BlogPosts.FirstOrDefault(m => m.Id == Id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Edit(int Id)
        {
            var model = db.BlogPosts.FirstOrDefault(m => m.Id == Id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(BlogPost model)
        {
   
            db.Entry(model).State = EntityState.Modified;
            db.Entry(model).Property(m => m.CreatedAt).IsModified = false;
            db.Entry(model).Property(m => m.CreatedBy).IsModified = false;

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var model = db.BlogPosts.FirstOrDefault(m => m.Id == Id);
            if (model == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Qeyd movcud deyil"
                });

            }

            db.SaveChanges();
            return Json(new
            {
                error = false,
                message = "Icra edildi"
            });

        }

    }
}
