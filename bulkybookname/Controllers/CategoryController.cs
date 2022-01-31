
using BulkyBook.DataAccess;
using BulkyBook.Models;
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
                TempData["Success"] = "Created successfully";
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
            var categoryFromDbFirst = _db.categories.FirstOrDefault(u => u.Name == "id");
            
            if(categoryFromDbFirst == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "They cannot be dup");
            }

            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Edited successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryDb = _db.categories.Find(id);

            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.categories.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }
                _db.categories.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Deleted successfully";
                return RedirectToAction("Index");
        }
    }
}
