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
            
        }
    }


}
