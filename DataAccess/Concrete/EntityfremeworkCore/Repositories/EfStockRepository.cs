using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityfremeworkCore.Repositories
{
    public class EfStockRepository : EfGenericRepository<Stock>, IStockDal
    {
       
    }
}
