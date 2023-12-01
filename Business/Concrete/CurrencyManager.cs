using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CurrencyManager : GenericManager<Currency>, ICurrencyService
    {
        public CurrencyManager(IGenericDal<Currency> genericDal) : base(genericDal)
        {
        }
    }
}
