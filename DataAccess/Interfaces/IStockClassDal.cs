using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IStockClassDal
    {
        void Insert(StockClass request);
        void Delete(StockClass request);
        void Update(StockClass request);
        StockClass GetById(int id);
        List<StockClass> GetAll();
    }
}
