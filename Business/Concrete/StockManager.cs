using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StockManager : GenericManager<Stock>, IStockService
    {
        public StockManager(IGenericDal<Stock> genericDal) : base(genericDal)
        {
        }
    }
}
