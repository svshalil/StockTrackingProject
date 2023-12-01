using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Request;
using Web.Models.Response;

namespace Web.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IStockUnitService _stockUnitService;
        private readonly IStockTypeService _stockTypeService;
        private readonly IStockClassService _stockClassService;
        public StockController(IStockService stockService, IStockUnitService stockUnitService, IStockTypeService stockTypeService, IStockClassService stockClassService)
        {
            _stockService = stockService;
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _stockClassService = stockClassService;

        }
        public async Task<IActionResult> Index()
        {
            TempData["Stopen"] = "open";
            List<Stock> stocks = await _stockService.GetAll();

            List<InsertStockResponseModel> stockRespnseModel = new List<InsertStockResponseModel>();

            foreach (var item in stocks)
            {
                var stockunit = await _stockUnitService.GetById(item.StockUnitID);
                var stocktypes = await _stockTypeService.GetById(item.StockTypeID);
                var stockclass = await _stockClassService.GetById(item.StockClassID);
                stockRespnseModel.Add(new InsertStockResponseModel
                {
                    Amount = item.Amount,
                    CriticalAmount = item.CriticalAmount,
                    UnitDescription = stockunit == null ? "" : stockunit.Description,
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

        public async Task<IActionResult> InsertStock()

        {
            ViewBag.stockUnits = await _stockUnitService.GetAll();
            ViewBag.stocktypes = await _stockTypeService.GetAll();
            ViewBag.stockclass = await _stockClassService.GetAll();
            return View(new InsertStockRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStock(InsertStockRequestModel requestModel)
        {
            ViewBag.stockUnits = await _stockUnitService.GetAll();
            ViewBag.stocktypes = await _stockTypeService.GetAll();
            ViewBag.stockclass = await _stockClassService.GetAll();
            if (ModelState.IsValid)
            {
                await _stockService.Insert(new Stock
                {
                    Amount = requestModel.Amount,
                    CabinetInformation = requestModel.CabinetInformation,
                    CriticalAmount = requestModel.CriticalAmount,
                    RecordDate = DateTime.Now,
                    ShelfInformation = requestModel.ShelfInformation,
                    Status = true,
                    StockClassID = requestModel.StockClassID,
                    StockTypeID = requestModel.StockTypeID,
                    StockUnitID = requestModel.StockUnitID
                });
                return RedirectToAction("Index");
            }
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateStock(long id)
        {
            ViewBag.stockUnits = await _stockUnitService.GetAll();
            ViewBag.stocktypes = await _stockTypeService.GetAll();
            ViewBag.stockclass = await _stockClassService.GetAll();
            var getstock = await _stockService.GetById(id);
            UpdateStockResponseModel updateStock = new UpdateStockResponseModel
            {
                Amount = getstock.Amount,
                CriticalAmount = getstock.CriticalAmount,
                RecordDate = getstock.RecordDate,
                ShelfInformation = getstock.ShelfInformation,
                ID = getstock.ID,
                StockClassID = getstock.StockClassID,
                CabinetInformation = getstock.CabinetInformation,
                StockTypeID = getstock.StockTypeID,
                StockUnitID = getstock.StockUnitID,
                Status = getstock.Status
            };

            return View(updateStock);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock(UpdateStockRequestModel updateStock)
        {
            ViewBag.stockUnits = await _stockUnitService.GetAll();
            ViewBag.stocktypes = await _stockTypeService.GetAll();
            ViewBag.stockclass = await _stockClassService.GetAll();

            if (ModelState.IsValid)
            {
                await _stockService.Update(new Stock
                {
                    Amount = updateStock.Amount,
                    CriticalAmount = updateStock.CriticalAmount,
                    RecordDate = updateStock.RecordDate,
                    ShelfInformation = updateStock.ShelfInformation,
                    ID = updateStock.ID,
                    StockClassID = updateStock.StockClassID,
                    CabinetInformation = updateStock.CabinetInformation,
                    StockTypeID = updateStock.StockTypeID,
                    StockUnitID = updateStock.StockUnitID,
                    Status = updateStock.Status
                });
                return RedirectToAction("Index");
            }
          

            return View(updateStock);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteStock(DeleteRequestModel delete)
        {
            await _stockService.Delete(new Stock { ID = delete.ID });

            return Json("Success");
        }
    }
}
