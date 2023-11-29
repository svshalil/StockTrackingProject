using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockUnitManager : IStockUnitService
    {
        private readonly IStockUnitDal _StockUnitDal;

        public StockUnitManager(IStockUnitDal StockUnitDal)
        {
            _StockUnitDal = StockUnitDal;
        }
        public void Delete(StockUnit request)
        {
            _StockUnitDal.Delete(request);
        }

        public List<StockUnit> GetAll()
        {
            return _StockUnitDal.GetAll();
        }

        public StockUnit GetById(long id)
        {
            return _StockUnitDal.GetById(id);
        }

        public void Insert(StockUnit request)
        {
            _StockUnitDal.Insert(request);
        }

        public void Update(StockUnit request)
        {
            _StockUnitDal.Update(request);
        }
    }
}
