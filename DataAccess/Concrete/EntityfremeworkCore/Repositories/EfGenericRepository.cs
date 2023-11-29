using DataAccess.Concrete.EntityfremeworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityfremeworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class,ITable, new()
    {
        public void Delete(T request)
        {
            using var db = new Context();
            db.Set<T>().Remove(request);
            db.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var db = new Context();

            return db.Set<T>().ToList();
        }

        public T GetById(long id)
        {
            using var db = new Context();

            return db.Set<T>().Find(id);
        }

        public void Insert(T request)
        {
            using var db = new Context();
            db.Set<T>().Add(request);
            db.SaveChanges();
        }

        public void Update(T request)
        {
            using var db = new Context();
            db.Set<T>().Update(request);
            db.SaveChanges();
        }
    }
}
