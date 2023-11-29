using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGenericService<T> where T : class, ITable,new()
    {
        void Insert(T request);
        void Delete(T request);
        void Update(T request);
        T GetById(long id);
        List<T> GetAll();
    }
}
