﻿using Microsoft.EntityFrameworkCore;
using MyImages.Data;
using MyImages.Models;
using MyImages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyImages.Repository
{
    public class RepositoryGeneric<T> : Repositories.IRepository<T> where T : class
    {

        ContextApp _context;
        DbSet<T> _dbSet;
        public RepositoryGeneric(ContextApp context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T FindById(string id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}
