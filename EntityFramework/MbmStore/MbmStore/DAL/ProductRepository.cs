﻿using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MbmStore.DAL
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        private MbmStoreContext db = new MbmStoreContext();
        private DbSet<T> dbSet;

        public ProductRepository()
        {
            dbSet = db.Set<T>();
        }

        public IEnumerable<T> GetItems()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetItem(int id)
        {
            return dbSet.Find(id);
        }

        public void SaveItem(T t)
        {
            if (t.ProductId == 0)
            {
                t.CreatedDate = DateTime.Now;
                dbSet.Add(t);
                db.SaveChanges();
            }
            else
            {
                db.Entry(t).State = EntityState.Modified;
                db.Entry(t).Property(b => b.CreatedDate).IsModified = false;
                db.SaveChanges();
            }
        }

        public T DeleteItem(int id)
        {
            T t = dbSet.Find(id);
            if (t != null)
            {
                dbSet.Remove(t);
                db.SaveChanges();
            }
            return t;

        }
    }
}