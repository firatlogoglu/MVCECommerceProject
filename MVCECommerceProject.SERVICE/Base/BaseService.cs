using MVCECommerceProject.CORE.Entity;
using MVCECommerceProject.CORE.Service;
using MVCECommerceProject.MODEL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace MVCECommerceProject.SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private static ProjectContext _db;
        public static ProjectContext db
        {
            get
            {
                if (_db == null)
                {
                    _db = new ProjectContext();
                }
                return _db;
            }
        }

        public void Add(T item)
        {
            db.Set<T>().Add(item);
            Save();
        }

        public void AddList(List<T> item)
        {
            db.Set<T>().AddRange(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return db.Set<T>().Where(x => x.Status == CORE.Enums.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetStatus(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Status = CORE.Enums.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetStatus(exp))
            {
                item.Status = CORE.Enums.Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = db.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }
    }
}