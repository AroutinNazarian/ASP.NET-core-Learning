using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDBcontext _db;
        public ProductRepository(ApplicationDBcontext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN= obj.ISBN;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.FinalPrice = obj.FinalPrice;
                objFromDb.FinalPrice50 = obj.FinalPrice50;
                objFromDb.FinalPrice100 = obj.FinalPrice100;
                objFromDb.Author = obj.Author;
                objFromDb.CategoryID = obj.CategoryID;
                objFromDb.CoverTypeID = obj.CoverTypeID;
                if(obj.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }
        }
    }


}
