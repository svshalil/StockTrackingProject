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
        public IActionResult Index()
        {
            TempData["Sttopen"] = "open";
            List<StockType> StockTypes = _stockTypeService.GetAll();

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
        public IActionResult InsertStockType(InsertStockTypeRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                _stockTypeService.Insert(new StockType
                {
                    ID = requestModel.ID,
                    StockTypeName = requestModel.StockTypeName,
                    Status = true
                });
                return RedirectToAction("Index");
            }
            return View(requestModel);
        }

        public IActionResult UpdateStockType(long id)
        {
            var getStockType = _stockTypeService.GetById(id);
            UpdateStockTypeResponseModel updateStockType = new UpdateStockTypeResponseModel
            {
                ID = getStockType.ID,
                StockTypeName = getStockType.StockTypeName

            };

            return View(updateStockType);
        }

        [HttpPost]
        public IActionResult UpdateStockType(UpdateStockTypeRequestModel updateStockType)
        {

            if (ModelState.IsValid)
            {
                _stockTypeService.Update(new StockType
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
        public JsonResult DeleteStockType([FromBody] DeleteRequestModel delete)
        {
            _stockTypeService.Delete(new StockType { ID = delete.ID });

            return Json("Success");
        }
    }
}
