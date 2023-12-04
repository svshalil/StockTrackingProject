using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Request;
using Web.Models.Response;

namespace Web.Controllers
{
    public class StockUnitController : Controller
    {
        private readonly IStockUnitService _stockUnitService;
        private readonly IStockTypeService _stockTypeService;
        private readonly ICurrencyService _currencyService;
        private readonly ILogger<StockUnitController> _logger;
        public StockUnitController(IStockUnitService stockUnitService, IStockTypeService stockTypeService, ICurrencyService currencyService, ILogger<StockUnitController> logger)
        {
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _currencyService = currencyService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<InsertStockUnitResponseModel> stockUnitRespnseModel = new List<InsertStockUnitResponseModel>();

            try
            {
                TempData["Stuopen"] = "open";
                List<StockUnit> stockUnits = await _stockUnitService.GetAll();


                foreach (var item in stockUnits)
                {
                    var stocktypes = await _stockTypeService.GetById(item.StockTypeID);
                    var salePriceCurrencyName = await _currencyService.GetById(item.SalePriceCurrencyID);
                    var PurchasePriceCurrencyName = await _currencyService.GetById(item.PurchasePriceCurrencyID);
                    stockUnitRespnseModel.Add(new InsertStockUnitResponseModel
                    {
                        AmountUnit = item.AmountUnit,
                        Description = item.Description,
                        ID = item.ID,
                        PaperWeight = item.PaperWeight,
                        PurchasePrice = item.PurchasePrice,
                        PurchasePriceCurrencyName = salePriceCurrencyName == null ? "" : salePriceCurrencyName.Name,
                        SalePrice = item.SalePrice,
                        SalePriceCurrencyName = PurchasePriceCurrencyName == null ? "" : PurchasePriceCurrencyName.Name,
                        StockUnitCode = item.StockUnitCode,
                        StockUnitName = item.StockUnitName,
                        StockTypeName = stocktypes == null ? "" : stocktypes.StockTypeName,
                        Status = item.Status,
                        RecordDate = item.RecordDate,
                    });
                }
                _logger.LogInformation("StockUnit Index list Count: " + stockUnitRespnseModel.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError("StockUnit Index list :" + ex.ToString());
            }
            return View(stockUnitRespnseModel);
        }

        public IActionResult InsertStockUnit()
        {
            try
            {
                ViewBag.stocktypes = _stockTypeService.GetAll();
                ViewBag.currency = _currencyService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("StockUnit Insert GetAll :" + ex.ToString());
            }
            return View(new InsertStockRequestModel());
        }

        [HttpPost]
        public IActionResult InsertStockUnit(InsertStockUnitRequestModel requestModel)
        {
            try
            {
                ViewBag.stocktypes = _stockTypeService.GetAll();
                ViewBag.currency = _currencyService.GetAll();
                if (ModelState.IsValid)
                {
                    _stockUnitService.Insert(new StockUnit
                    {
                        SalePrice = requestModel.SalePrice,
                        RecordDate = DateTime.Now,
                        StockUnitName = requestModel.StockUnitName,
                        StockUnitCode = requestModel.StockUnitCode,
                        PurchasePriceCurrencyID = requestModel.PurchasePriceCurrencyID,
                        SalePriceCurrencyID = requestModel.SalePriceCurrencyID,
                        AmountUnit = requestModel.AmountUnit,
                        Description = requestModel.Description,
                        ID = 0,
                        PaperWeight = requestModel.PaperWeight,
                        PurchasePrice = requestModel.PurchasePrice,
                        Status = true,
                        StockTypeID = requestModel.StockTypeID,
                    });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("StockUnit Insert :" + ex.ToString());
            }
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateStockUnit(long id)
        {
            UpdateStockUnitResponseModel updateStock = new UpdateStockUnitResponseModel();

            try
            {
                ViewBag.stocktypes = await _stockTypeService.GetAll();
                ViewBag.currency = await _currencyService.GetAll();
                var getstockUnit = await _stockUnitService.GetById(id);


                updateStock.StockTypeID = getstockUnit.StockTypeID;
                updateStock.PurchasePrice = getstockUnit.PurchasePrice;
                updateStock.PaperWeight = getstockUnit.PaperWeight;
                updateStock.ID = getstockUnit.ID;
                updateStock.Description = getstockUnit.Description;
                updateStock.AmountUnit = getstockUnit.AmountUnit;
                updateStock.PurchasePriceCurrencyID = getstockUnit.PurchasePriceCurrencyID;
                updateStock.SalePrice = getstockUnit.SalePrice;
                updateStock.SalePriceCurrencyID = getstockUnit.SalePriceCurrencyID;
                updateStock.StockUnitCode = getstockUnit.StockUnitCode;
                updateStock.StockUnitName = getstockUnit.StockUnitName;
            }
            catch (Exception ex)
            {
                _logger.LogError("StockUnit Update GetById :" + ex.ToString());
            }

            return View(updateStock);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStockUnit(UpdateStockUnitRequestModel updateStockUnit)
        {
            try
            {
                ViewBag.stocktypes = _stockTypeService.GetAll();
                ViewBag.currency = _currencyService.GetAll();

                if (ModelState.IsValid)
                {
                    await _stockUnitService.Update(new StockUnit
                    {
                        StockUnitName = updateStockUnit.StockUnitName,
                        StockUnitCode = updateStockUnit.StockUnitCode,
                        SalePriceCurrencyID = updateStockUnit.SalePriceCurrencyID,
                        SalePrice = updateStockUnit.SalePrice,
                        PurchasePriceCurrencyID = updateStockUnit.PurchasePriceCurrencyID,
                        AmountUnit = updateStockUnit.AmountUnit,
                        Description = updateStockUnit.Description,
                        ID = updateStockUnit.ID,
                        PaperWeight = updateStockUnit.PaperWeight,
                        PurchasePrice = updateStockUnit.PurchasePrice,
                        RecordDate = DateTime.Now,
                        Status = true,
                        StockTypeID = updateStockUnit.StockTypeID,
                    });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("StockUnit Update :" + ex.ToString());
            }


            return View(updateStockUnit);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteStockUnit(DeleteRequestModel delete)
        {
            try
            {
                await _stockUnitService.Delete(new StockUnit { ID = delete.ID });
            }
            catch (Exception ex)
            {
                _logger.LogError("StockUnit Delete :" + ex.ToString());
            }

            return Json("Success");
        }
    }
}
