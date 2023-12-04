using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Request;
using Web.Models.Response;

namespace Web.Controllers
{
    public class StockTypeController : Controller
    {
        private readonly IStockTypeService _stockTypeService;
        private readonly ILogger<StockTypeController> _logger;

        public StockTypeController(IStockTypeService stockTypeService, ILogger<StockTypeController> logger)
        {
            _stockTypeService = stockTypeService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<InsertStockTypeResponseModel> stockTypeRespnseModel = new List<InsertStockTypeResponseModel>();

            try
            {
                TempData["Sttopen"] = "open";
                List<StockType> StockTypes = await _stockTypeService.GetAll();


                foreach (var item in StockTypes)
                {
                    stockTypeRespnseModel.Add(new InsertStockTypeResponseModel
                    {
                        ID = item.ID,
                        StockTypeName = item.StockTypeName

                    });
                }
                _logger.LogInformation("Currency Index list Count: " + stockTypeRespnseModel.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError("StockType Index list :" + ex.ToString());
            }
            return View(stockTypeRespnseModel);
        }
        public IActionResult InsertStockType()

        {
            return View(new InsertStockTypeRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStockType(InsertStockTypeRequestModel requestModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _stockTypeService.Insert(new StockType
                    {
                        ID = requestModel.ID,
                        StockTypeName = requestModel.StockTypeName,
                        Status = true
                    });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("StockType Insert :" + ex.ToString());
            }
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateStockType(long id)
        {
            UpdateStockTypeResponseModel updateStockType = new UpdateStockTypeResponseModel();
            try
            {
                var getStockType = await _stockTypeService.GetById(id);
                getStockType.ID = getStockType.ID;
                getStockType.StockTypeName = getStockType.StockTypeName;
            }
            catch (Exception ex)
            {

                _logger.LogError("StockType Update GetById :" + ex.ToString());
            }

            return View(updateStockType);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStockType(UpdateStockTypeRequestModel updateStockType)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _stockTypeService.Update(new StockType
                    {
                        ID = updateStockType.ID,
                        StockTypeName = updateStockType.StockTypeName,
                        Status = true
                    });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("StockType Update :" + ex.ToString());
            }


            return View(updateStockType);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteStockType([FromBody] DeleteRequestModel delete)
        {
            try
            {
                await _stockTypeService.Delete(new StockType { ID = delete.ID });
            }
            catch (Exception ex)
            {
                _logger.LogError("StockType Delete :" + ex.ToString());
            }

            return Json("Success");
        }
    }
}
