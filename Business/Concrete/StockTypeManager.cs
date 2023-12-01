using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StockTypeManager : GenericManager<StockType>, IStockTypeService
    {
        public StockTypeManager(IGenericDal<StockType> genericDal) : base(genericDal)
        {
        }
    }
}
