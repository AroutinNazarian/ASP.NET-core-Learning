using bulkybookname.Data;
using bulkybookname.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkybookname.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBcontext _db;

        public CategoryController(ApplicationDBcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "They cannot be dup");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); 
        }

        //GET

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryDb = _db.categories.Find(id);
            
            if(categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }

        //POST

        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "They cannot be dup");
            }

            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
