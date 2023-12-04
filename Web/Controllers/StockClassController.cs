using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Request;
using Web.Models.Response;

namespace Web.Controllers
{
    public class StockClassController : Controller
    {
        private readonly IStockClassService _stockClassService;
        private readonly ILogger<StockClassController> _logger;

        public StockClassController(IStockClassService stockClassService, ILogger<StockClassController> logger)
        {
            _stockClassService = stockClassService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<InsertStockClassResponseModel> stockClassRespnseModel = new List<InsertStockClassResponseModel>();

            try
            {
                TempData["Stcopen"] = "open";
                List<StockClass> stockClasss = await _stockClassService.GetAll();



                foreach (var item in stockClasss)
                {
                    stockClassRespnseModel.Add(new InsertStockClassResponseModel
                    {
                        ID = item.ID,
                        StockClassName = item.StockClassName
                    });
                }
                _logger.LogInformation("StockClass Index list Count: " + stockClassRespnseModel.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError("StockClass Index list :" + ex.ToString());
            }
            return View(stockClassRespnseModel);
        }
        public IActionResult InsertStockClass()

        {
            return View(new InsertStockClassRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStockClass(InsertStockClassRequestModel requestModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _stockClassService.Insert(new StockClass
                    {
                        ID = requestModel.ID,
                        StockClassName = requestModel.StockClassName
                    });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("StockClass Insert :" + ex.ToString());
            }
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateStockClass(long id)
        {
            UpdateStockClassResponseModel updateStockClass = new UpdateStockClassResponseModel();
            try
            {
                var getStockClass = await _stockClassService.GetById(id);
                updateStockClass.ID = getStockClass.ID;
                updateStockClass.StockClassName = getStockClass.StockClassName;
            }
            catch (Exception ex)
            {
                _logger.LogError("StockClass Update GetById :" + ex.ToString());
            }

            return View(updateStockClass);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStockClass(UpdateStockClassRequestModel updateStockClass)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _stockClassService.Update(new StockClass
                    {
                        ID = updateStockClass.ID,
                        StockClassName = updateStockClass.StockClassName
                    });
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("StockClass Update :" + ex.ToString());
            }

            return View(updateStockClass);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteStockClass(DeleteRequestModel delete)
        {
            try
            {
                await _stockClassService.Delete(new StockClass { ID = delete.ID });
            }
            catch (Exception ex)
            {
                _logger.LogError("StockClass Delete :" + ex.ToString());
            }

            return Json("Success");
        }
    }
}
