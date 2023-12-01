using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, ITable, new()
    {
        private readonly IGenericDal<T> _genericDal;
        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task Delete(T request)
        {
           await _genericDal.Delete(request);
        }

        public async Task<List<T>> GetAll()
        {
           return await _genericDal.GetAll();
        }

        public async Task<T> GetById(long id)
        {
            return await _genericDal.GetById(id);
        }

        public async Task Insert(T request)
        {
            await _genericDal.Insert(request);
        }

        public async Task Update(T request)
        {
            await _genericDal.Update(request);
        }
    }
}
