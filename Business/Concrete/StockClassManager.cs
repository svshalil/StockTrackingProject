using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockClassManager : IStockClassService
    {
        private readonly IStockClassDal _stockClassDal;

        public StockClassManager(IStockClassDal stockClassDal)
        {
            _stockClassDal = stockClassDal;
        }
        public void Delete(StockClass request)
        {
            _stockClassDal.Delete(request);
        }

        public List<StockClass> GetAll()
        {
            return _stockClassDal.GetAll();
        }

        public StockClass GetById(long id)
        {
            return _stockClassDal.GetById(id);
        }

        public void Insert(StockClass request)
        {
            _stockClassDal.Insert(request);
        }

        public void Update(StockClass request)
        {
            _stockClassDal.Update(request);
        }
    }
}
