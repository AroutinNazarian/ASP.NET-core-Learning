
using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkybookname.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
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
                _db.Add(obj);
                _db.Save();
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
            var categoryFromDbFirst = _db.GetFirstOrDefault(u => u.Id == id);
            
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
                _db.Update(obj);
                _db.Save();
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
            var categoryFromDbFirst = _db.GetFirstOrDefault(u => u. Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u. Id == id);
            if (obj == null) 
            {
                return NotFound();
            }
                _db.Remove(obj);
                _db.Save();
                TempData["Success"] = "Deleted successfully";
                return RedirectToAction("Index");
        }
    }
}
