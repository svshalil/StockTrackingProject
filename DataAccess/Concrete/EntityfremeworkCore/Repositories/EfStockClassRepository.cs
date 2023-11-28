using DataAccess.Concrete.EntityfremeworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityfremeworkCore.Repositories
{
    public class EfStockClassRepository : EfGenericRepository<StockClass>, IStockClassDal
    {
       
    }
}
