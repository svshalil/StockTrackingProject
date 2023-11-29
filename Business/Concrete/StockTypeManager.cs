using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StockTypeManager : IStockTypeService
    {
        private readonly IStockTypeDal _stockTypeDal;

        public StockTypeManager(IStockTypeDal stockTypeDal)
        {
            _stockTypeDal = stockTypeDal;
        }
        public void Delete(StockType request)
        {
            _stockTypeDal.Delete(request);
        }

        public List<StockType> GetAll()
        {
            return _stockTypeDal.GetAll();
        }

        public StockType GetById(long id)
        {
            return _stockTypeDal.GetById(id);
        }

        public void Insert(StockType request)
        {
            _stockTypeDal.Insert(request);
        }

        public void Update(StockType request)
        {
            _stockTypeDal.Update(request);
        }
    }
}
