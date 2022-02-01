﻿using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBcontext _db;

        public UnitOfWork(ApplicationDBcontext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Covertype = new CoverTypeRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICovertypeRepository Covertype { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
