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
        public IActionResult Index()
        {
            List<StockClass> stockClasss = _stockClassService.GetAll();

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
        public IActionResult InsertStockClass(InsertStockClassRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                _stockClassService.Insert(new StockClass
                {
                   ID = requestModel.ID,
                   StockClassName = requestModel.StockClassName
                });
                return RedirectToAction("Index");
            }
            return View(requestModel);
        }

        public IActionResult UpdateStockClass(long id)
        {
            var getStockClass = _stockClassService.GetById(id);
            UpdateStockClassResponseModel updateStockClass = new UpdateStockClassResponseModel
            {
                ID = getStockClass.ID,
                StockClassName = getStockClass.StockClassName

            };

            return View(updateStockClass);
        }

        [HttpPost]
        public IActionResult UpdateStockClass(UpdateStockClassRequestModel updateStockClass)
        {

            if (ModelState.IsValid)
            {
                _stockClassService.Update(new StockClass
                {
                    ID = 0,
                    StockClassName= updateStockClass.StockClassName
                });
                return RedirectToAction("Index");
            }


            return View(updateStockClass);
        }

        [HttpDelete]
        public IActionResult DeleteStockClass(long id)
        {
            _stockClassService.Delete(new StockClass { ID = id });

            return NoContent();
        }
    }
}
