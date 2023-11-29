using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StockManager: IStockService
    {
        private readonly IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }
        public void Delete(Stock request)
        {
            _stockDal.Delete(request);
        }

        public List<Stock> GetAll()
        {
            return _stockDal.GetAll();
        }

        public Stock GetById(long id)
        {
            return _stockDal.GetById(id);
        }

        public void Insert(Stock request)
        {
            _stockDal.Insert(request);
        }

        public void Update(Stock request)
        {
            _stockDal.Update(request);
        }
    }
}
