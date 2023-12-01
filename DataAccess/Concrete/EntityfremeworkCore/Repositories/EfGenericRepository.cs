using DataAccess.Concrete.EntityfremeworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;
using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityfremeworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class,ITable, new()
    {
        public async Task Delete(T request)
        {
            using var db = new Context();
            db.Set<T>().Remove(request);
            await db.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            using var db = new Context();

            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            using var db = new Context();

            return await db.Set<T>().FindAsync(id);
        }

        public async Task Insert(T request)
        {
            using var db = new Context();
            db.Set<T>().Add(request);
            await db.SaveChangesAsync();
        }

        public async Task Update(T request)
        {
            using var db = new Context();
            db.Set<T>().Update(request);
            await db.SaveChangesAsync();
        }

      
    }
}
