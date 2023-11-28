using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly EfCurrencyRepository _efCurrencyRepository;

        public CurrencyManager(EfCurrencyRepository efCurrencyRepository)
        {
            _efCurrencyRepository = efCurrencyRepository;
        }
        public void Delete(Currency request)
        {
            _efCurrencyRepository.Delete(request);
        }

        public List<Currency> GetAll()
        {
            return _efCurrencyRepository.GetAll();
        }

        public Currency GetById(int id)
        {
            return _efCurrencyRepository.GetById(id);
        }

        public void Insert(Currency request)
        {
            _efCurrencyRepository.Insert(request);
        }

        public void Update(Currency request)
        {
            _efCurrencyRepository.Update(request);
        }
    }
}
