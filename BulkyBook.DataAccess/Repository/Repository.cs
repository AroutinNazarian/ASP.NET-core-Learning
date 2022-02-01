﻿using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private  ApplicationDBcontext _db;
        private DbSet<T> dbSet;

        public Repository(ApplicationDBcontext db)
        {
            _db = db; 
            this.dbSet = _db.Set<T>();
            
        }
        
        public void add(T entity)
        {
             dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault(); 
        }

        public T GetT(int id)
        {
            throw new NotImplementedException();
        }

        public void remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void removeRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
