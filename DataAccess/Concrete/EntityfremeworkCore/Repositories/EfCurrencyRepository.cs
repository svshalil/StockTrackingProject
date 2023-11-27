using DataAccess.Concrete.EntityfremeworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityfremeworkCore.Repositories
{
    public class EfCurrencyRepository : ICurrencyDal
    {
        public void Delete(Currency request)
        {
            using var db = new Context();
            db.Currencys.Remove(request);
            db.SaveChanges();
        }

        public List<Currency> GetAll()
        {
            using var db = new Context();

            return db.Currencys.ToList();
        }

        public Currency GetById(int id)
        {
            using var db = new Context();

            return db.Currencys.Find(id);
        }

        public void Insert(Currency request)
        {
            using var db = new Context();
            db.Currencys.Add(request);
            db.SaveChanges();
        }

        public void Update(Currency request)
        {
            using var db = new Context();
            db.Currencys.Update(request);
            db.SaveChanges();
        }
    }
}
