using DataAccess.Concrete.EntityfremeworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityfremeworkCore.Repositories
{
    public class EfStockClassRepository : IStockClassDal
    {
        public void Delete(StockClass request)
        {
            using var db = new Context();
            db.StockClasss.Remove(request);
            db.SaveChanges();
        }

        public List<StockClass> GetAll()
        {
            using var db = new Context();

            return db.StockClasss.ToList();
        }

        public StockClass GetById(int id)
        {
            using var db = new Context();

            return db.StockClasss.Find(id);
        }

        public void Insert(StockClass request)
        {
            using var db = new Context();
            db.StockClasss.Add(request);
            db.SaveChanges();
        }

        public void Update(StockClass request)
        {
            using var db = new Context();
            db.StockClasss.Update(request);
            db.SaveChanges();
        }
    }
}
