using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Models.Request;
using Web.Models.Response;

namespace Web.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public IActionResult Index()
        {
            List<Currency> currencys = _currencyService.GetAll();

            List<InsertCurrencyResponseModel> currencyRespnseModel = new List<InsertCurrencyResponseModel>();

            foreach (var item in currencys)
            {
                currencyRespnseModel.Add(new InsertCurrencyResponseModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    Status = item.Status,
                    Symbol = item.Symbol
                });
            }
            return View(currencyRespnseModel);
        }
        public IActionResult InsertCurrency()

        {
            return View(new InsertCurrencyRequestModel());
        }

        [HttpPost]
        public IActionResult InsertCurrency(InsertCurrencyRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                _currencyService.Insert(new Currency
                {
                    Name = requestModel.Name,
                    Status = true,
                    Symbol = requestModel.Symbol
                });
                return RedirectToAction("Index");
            }
            return View(requestModel);
        }

        public IActionResult UpdateCurrency(long id)
        {
            var getCurrency = _currencyService.GetById(id);
            UpdateCurrencyResponseModel updateCurrency = new UpdateCurrencyResponseModel
            {
                ID = getCurrency.ID,
                Name = getCurrency.Name,
                Status = getCurrency.Status,
                Symbol = getCurrency.Symbol

            };

            return View(updateCurrency);
        }

        [HttpPost]
        public IActionResult UpdateCurrency(UpdateCurrencyRequestModel updateCurrency)
        {

            if (ModelState.IsValid)
            {
                _currencyService.Update(new Currency
                {
                    ID = 0,
                    Name = updateCurrency.Name,
                    Status = updateCurrency.Status,
                    Symbol = updateCurrency.Symbol
                });
                return RedirectToAction("Index");
            }


            return View(updateCurrency);
        }

        [HttpDelete]
        public IActionResult DeleteCurrency(long id)
        {
            _currencyService.Delete(new Currency { ID = id });

            return NoContent();
        }
    }
}
