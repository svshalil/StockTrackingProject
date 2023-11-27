using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IStockUnitDal
    {
        void Insert(StockUnit request);
        void Delete(StockUnit request);
        void Update(StockUnit request);
        StockUnit GetById(int id);
        List<StockUnit> GetAll();
    }
}
