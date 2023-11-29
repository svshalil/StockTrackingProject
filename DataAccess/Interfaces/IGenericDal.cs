using Entities.Concrete;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericDal<T> where T : class, ITable,new()
    {
        void Insert(T request);
        void Delete(T request);
        void Update(T request);
        T GetById(long id);
        List<T> GetAll();
    }
}
