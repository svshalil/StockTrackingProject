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

        public StockTypeController(IStockTypeService stockTypeService)
        {
            _stockTypeService = stockTypeService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Sttopen"] = "open";
            List<StockType> StockTypes = await _stockTypeService.GetAll();

            List<InsertStockTypeResponseModel> StockTypeRespnseModel = new List<InsertStockTypeResponseModel>();

            foreach (var item in StockTypes)
            {
                StockTypeRespnseModel.Add(new InsertStockTypeResponseModel
                {
                    ID = item.ID,
                    StockTypeName = item.StockTypeName
                    
                });
            }
            return View(StockTypeRespnseModel);
        }
        public IActionResult InsertStockType()

        {
            return View(new InsertStockTypeRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStockType(InsertStockTypeRequestModel requestModel)
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
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateStockType(long id)
        {
            var getStockType = await _stockTypeService.GetById(id);
            UpdateStockTypeResponseModel updateStockType = new UpdateStockTypeResponseModel
            {
                ID = getStockType.ID,
                StockTypeName = getStockType.StockTypeName

            };

            return View(updateStockType);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStockType(UpdateStockTypeRequestModel updateStockType)
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


            return View(updateStockType);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteStockType([FromBody] DeleteRequestModel delete)
        {
            await _stockTypeService.Delete(new StockType { ID = delete.ID });

            return Json("Success");
        }
    }
}
