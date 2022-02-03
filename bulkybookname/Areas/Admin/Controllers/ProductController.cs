
using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace bulkybookname.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitofwork _unitOfWork;

        public ProductController(IUnitofwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();

            return View(objCoverTypeList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET

        public IActionResult Upsert(int? id)
        {
            Product product = new Product();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
             ); 
            IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
             );
            //creating product
            if (id == null || id == 0)
            {
                ViewBag.CategoryList = CategoryList;
                ViewData["CoverTypeList"] = CoverTypeList;
                return View(product);
            }
            else
            {
                //updating product


            }
            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
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
            var covertypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (covertypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(covertypeFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
