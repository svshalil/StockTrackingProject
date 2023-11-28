using DataAccess.Concrete.EntityfremeworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityfremeworkCore.Repositories
{
    public class EfCurrencyRepository : EfGenericRepository<Currency>, ICurrencyDal
    {
        
    }
}
