using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IStockUnitService _stockUnitService;
        private readonly IStockTypeService _stockTypeService;
        private readonly IStockClassService _stockClassService;
        public StockController(IStockService stockService, IStockUnitService stockUnitService, IStockTypeService stockTypeService,IStockClassService stockClassService)
        {
            _stockService = stockService;
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _stockClassService = stockClassService;

        }
        public IActionResult Index()
        {
            List<Stock> stocks = _stockService.GetAll();

            List<StockRespnseModel> stockRespnseModel = new List<StockRespnseModel>();

            foreach (var item in stocks)
            {
                var stockunit = _stockUnitService.GetById(item.StockUnitID);
                var stocktypes = _stockTypeService.GetById(item.StockTypeID);
                var stockclass = _stockClassService.GetById(item.StockTypeID);
                stockRespnseModel.Add(new StockRespnseModel
                {
                    Amount = item.Amount,
                    CriticalAmount=item.CriticalAmount,
                    UnitDescription = stockunit == null ? "": stockunit.Description,
                    RecordDate = item.RecordDate,
                    ShelfInformation = item.ShelfInformation,
                    StockID = item.ID,
                    StockTypeName = stocktypes == null ? "" : stocktypes.StockTypeName,
                    StockUnitCode = stockunit == null ? 0 : stockunit.StockUnitCode,
                    StockUnitName = stockunit == null ? "" : stockunit.StockUnitName,
                    StockClassName = stockclass == null ? "" : stockclass.StockClassName,
                    CabinetInformation = item.CabinetInformation
                });
            }
            return View(stockRespnseModel);
        }

        public IActionResult StockInsert()
        {

        }
    }
}
