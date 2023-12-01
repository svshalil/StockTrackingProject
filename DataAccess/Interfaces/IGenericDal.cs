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
        Task Insert(T request);
        Task Delete(T request);
        Task Update(T request);
        Task<T> GetById(long id);
        Task<List<T>> GetAll();
    }
}
