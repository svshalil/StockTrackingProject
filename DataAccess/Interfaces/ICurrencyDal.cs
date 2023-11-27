using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface ICurrencyDal
    {
        void Insert(Currency request);
        void Delete(Currency request);
        void Update(Currency request);
        Currency GetById(int id);
        List<Currency> GetAll();
    }
}
