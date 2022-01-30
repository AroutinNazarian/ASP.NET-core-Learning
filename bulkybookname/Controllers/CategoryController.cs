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
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
