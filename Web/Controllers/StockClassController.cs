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

        public StockClassController(IStockClassService stockClassService)
        {
            _stockClassService = stockClassService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Stcopen"] = "open";
            List<StockClass> stockClasss = await _stockClassService.GetAll();

            List<InsertStockClassResponseModel> StockClassRespnseModel = new List<InsertStockClassResponseModel>();

            foreach (var item in stockClasss)
            {
                StockClassRespnseModel.Add(new InsertStockClassResponseModel
                {
                    ID=item.ID,
                    StockClassName = item.StockClassName
                });
            }
            return View(StockClassRespnseModel);
        }
        public IActionResult InsertStockClass()

        {
            return View(new InsertStockClassRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStockClass(InsertStockClassRequestModel requestModel)
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
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateStockClass(long id)
        {
            var getStockClass = await _stockClassService.GetById(id);
            UpdateStockClassResponseModel updateStockClass = new UpdateStockClassResponseModel
            {
                ID = getStockClass.ID,
                StockClassName = getStockClass.StockClassName

            };

            return View(updateStockClass);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStockClass(UpdateStockClassRequestModel updateStockClass)
        {

            if (ModelState.IsValid)
            {
               await _stockClassService.Update(new StockClass
                {
                    ID = updateStockClass.ID,
                    StockClassName= updateStockClass.StockClassName
                });
                return RedirectToAction("Index");
            }


            return View(updateStockClass);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteStockClass(DeleteRequestModel delete)
        {
            await _stockClassService.Delete(new StockClass { ID = delete.ID });

            return Json("Success");
        }
    }
}
