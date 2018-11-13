using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        private PrescriptionsDbContext _context;

        protected Repository(PrescriptionsDbContext context)
        {
            _context = context;
        }
        public virtual List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Get(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public virtual T Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public virtual int Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
            return _context.SaveChanges();
        }
    }
}