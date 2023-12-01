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
    public class StockClassManager : GenericManager<StockClass>, IStockClassService
    {
        public StockClassManager(IGenericDal<StockClass> genericDal) : base(genericDal)
        {
        }
    }
}
