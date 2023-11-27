using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IStockTypeDal
    {
        void Insert(StockType request);
        void Delete(StockType request);
        void Update(StockType request);
        StockType GetById(int id);
        List<StockType> GetAll();
    }
}
