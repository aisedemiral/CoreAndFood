﻿using CoreAndFood.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        Context c = new Context();

        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }
        public List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
        public void AddT(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void DeleteT(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public void UpdateT(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public T GetT(int id)
        {
           return c.Set<T>().Find(id);
        }

        public List<T> List(Expression<Func<T,bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }

    }
}
