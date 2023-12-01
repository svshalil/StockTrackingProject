using Business.Concrete;
using Business.Interfaces;
using DataAccess.Concrete.EntityfremeworkCore.Repositories;
using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Containers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IStockService, StockManager>();
            services.AddScoped<IStockUnitService, StockUnitManager>();
            services.AddScoped<IStockTypeService, StockTypeManager>();
            services.AddScoped<IStockClassService, StockClassManager>();
            services.AddScoped<ICurrencyService, CurrencyManager>();


            services.AddScoped<IStockDal, EfStockRepository>();
            services.AddScoped<IStockUnitDal, EfStockUnitRepository>();
            services.AddScoped<IStockTypeDal, EfStockTypeRepository>();
            services.AddScoped<IStockClassDal, EfStockClassRepository>();
            services.AddScoped<ICurrencyDal, EfCurrencyRepository>();
        }
    }
}
