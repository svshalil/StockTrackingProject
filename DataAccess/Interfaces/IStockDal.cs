using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IStockDal
    {
        void Insert(Stock request);
        void Delete(Stock request);
        void Update(Stock request);
        Stock GetById(int id);
        List<Stock> GetAll();
    }
}
