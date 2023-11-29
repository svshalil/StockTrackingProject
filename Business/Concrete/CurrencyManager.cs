using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }
        public void Delete(Currency request)
        {
            _currencyDal.Delete(request);
        }

        public List<Currency> GetAll()
        {
            return _currencyDal.GetAll();
        }

        public Currency GetById(long id)
        {
            return _currencyDal.GetById(id);
        }

        public void Insert(Currency request)
        {
            _currencyDal.Insert(request);
        }

        public void Update(Currency request)
        {
            _currencyDal.Update(request);
        }
    }
}
