
using BigonTask.Models.Entities;
using BigonTask.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigonTask.areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        readonly private  DataContext db;

        public ColorsController(DataContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
           List<Color> colors= db.Colors
                .Where(m=>m.DeletedBy==null)
                .ToList();
            return View(colors);
        }
      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color model)
        {      
           db.Colors.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int Id)
        {
        var model=db.Colors.FirstOrDefault(m=> m.Id == Id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Edit(int Id)
        {
            var model = db.Colors.FirstOrDefault(m => m.Id == Id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
          
        }
        [HttpPost]
        public IActionResult Edit(Color model)
        {
            //var EntityModel = db.Colors.FirstOrDefault(m => m.Id == model.Id);
            //EntityModel.Name = model.Name;
            //                EntityModel.HexCode = model.HexCode;
            db.Entry(model).State = EntityState.Modified;
            db.Entry(model).Property(m => m.CreatedAt).IsModified = false;
            db.Entry(model).Property(m => m.CreatedBy).IsModified = false;
          
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var model = db.Colors.FirstOrDefault(m => m.Id == Id);
            if (model == null)
            {
                return Json(new
                {
                    error=true,
                    message="Qeyd movcud deyil"
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
