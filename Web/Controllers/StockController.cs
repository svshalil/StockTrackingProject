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
        private readonly ILogger<StockController> _logger;
        public StockController(IStockService stockService, IStockUnitService stockUnitService, IStockTypeService stockTypeService, IStockClassService stockClassService, ILogger<StockController> logger)
        {
            _stockService = stockService;
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _stockClassService = stockClassService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<InsertStockResponseModel> stockRespnseModel = new List<InsertStockResponseModel>();
            try
            {
                TempData["Stopen"] = "open";
                List<Stock> stocks = await _stockService.GetAll();

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
                _logger.LogInformation("Stock Index list Count: " + stockRespnseModel.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError("Stock Index list :" + ex.ToString());
            }
            return View(stockRespnseModel);
        }

        public async Task<IActionResult> InsertStock()

        {
            try
            {
                ViewBag.stockUnits = await _stockUnitService.GetAll();
                ViewBag.stocktypes = await _stockTypeService.GetAll();
                ViewBag.stockclass = await _stockClassService.GetAll();
            }
            catch (Exception ex )
            {
                _logger.LogError("Stock Insert GetAll :" + ex.ToString());
            }
            return View(new InsertStockRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStock(InsertStockRequestModel requestModel)
        {
            try
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
            }
            catch (Exception ex)
            {
                _logger.LogError("Stock Insert :" + ex.ToString());
            }
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateStock(long id)
        {
            UpdateStockResponseModel updateStock = new UpdateStockResponseModel();

            try
            {
                ViewBag.stockUnits = await _stockUnitService.GetAll();
                ViewBag.stocktypes = await _stockTypeService.GetAll();
                ViewBag.stockclass = await _stockClassService.GetAll();
                var getstock = await _stockService.GetById(id);

                updateStock.Amount = getstock.Amount;
                updateStock.CriticalAmount = getstock.CriticalAmount;
                updateStock.RecordDate = getstock.RecordDate;
                updateStock.ShelfInformation = getstock.ShelfInformation;
                updateStock.ID = getstock.ID;
                updateStock.StockClassID = getstock.StockClassID;
                updateStock.CabinetInformation = getstock.CabinetInformation;
                updateStock.StockTypeID = getstock.StockTypeID;
                updateStock.StockUnitID = getstock.StockUnitID;
                updateStock.Status = getstock.Status;
            }
            catch (Exception ex)
            {
                _logger.LogError("Stock Update GetById :" + ex.ToString());
            }

            return View(updateStock);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock(UpdateStockRequestModel updateStock)
        {
            try
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
            }
            catch (Exception ex)
            {
                _logger.LogError("Stock Update:" + ex.ToString());
            }
          

            return View(updateStock);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteStock(DeleteRequestModel delete)
        {
            try
            {
                await _stockService.Delete(new Stock { ID = delete.ID });
            }
            catch (Exception ex)
            {

                _logger.LogError("Stock Delete:" + ex.ToString());
            }

            return Json("Success");
        }
    }
}
