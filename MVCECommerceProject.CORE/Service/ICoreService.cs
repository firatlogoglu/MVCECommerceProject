using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVCECommerceProject.CORE.Service
{
    public interface ICoreService<T> where T : Entity.CoreEntity
    {
        //Ekleme
        void Add(T item);
        //Liste Halinde Ekleme
        void AddList(List<T> item);
        //Güncelleme
        void Update(T item);
        //Silme
        void Remove(T item);
        //Hepsini Silme
        void RemoveAll(Expression<Func<T, bool>> exp);
        //Tekil Olarak getirme
        T GetById(Guid id);
        //Varsayılan olarak Getirme
        T GetByDefault(Expression<Func<T, bool>> exp);
        //Aktif olanları listeleme
        List<T> GetActive();
        List<T> GetStatus(Expression<Func<T, bool>> exp);
        //Hepsini listeleme
        List<T> GetAll();
        //koşula göre getirme
        bool Any(Expression<Func<T, bool>> exp);
        //kaydetme
        int Save();
    }
}