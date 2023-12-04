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
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ICurrencyService currencyService, ILogger<CurrencyController> logger)
        {
            _currencyService = currencyService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<InsertCurrencyResponseModel> currencyRespnseModel = new List<InsertCurrencyResponseModel>();
            try
            {
                TempData["Cropen"] = "open";
                List<Currency> currencys = await _currencyService.GetAll();



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
                _logger.LogInformation("Currency Index list Count: " + currencyRespnseModel.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError("Currency Index list :" + ex.ToString());
            }
            return View(currencyRespnseModel);
        }
        public IActionResult InsertCurrency()

        {
            return View(new InsertCurrencyRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertCurrency(InsertCurrencyRequestModel requestModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _currencyService.Insert(new Currency
                    {
                        Name = requestModel.Name,
                        Status = true,
                        Symbol = requestModel.Symbol
                    });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Currency Insert :" + ex.ToString());
            }
            return View(requestModel);
        }

        public async Task<IActionResult> UpdateCurrency(long id)
        {
            UpdateCurrencyResponseModel updateCurrency = new UpdateCurrencyResponseModel();
            try
            {
                var getCurrency = await _currencyService.GetById(id);

                updateCurrency.ID = getCurrency.ID;
                updateCurrency.Name = getCurrency.Name;
                updateCurrency.Status = getCurrency.Status;
                updateCurrency.Symbol = getCurrency.Symbol;
            }
            catch (Exception ex)
            {

                _logger.LogError("Currency Update GetById :" + ex.ToString());
            }

            return View(updateCurrency);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCurrency(UpdateCurrencyRequestModel updateCurrency)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _currencyService.Update(new Currency
                    {
                        ID = updateCurrency.ID,
                        Name = updateCurrency.Name,
                        Status = updateCurrency.Status,
                        Symbol = updateCurrency.Symbol
                    });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Currency Update :" + ex.ToString());
            }


            return View(updateCurrency);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteCurrency([FromBody] DeleteRequestModel delete)
        {
            try
            {
                await _currencyService.Delete(new Currency { ID = delete.ID });
            }
            catch (Exception ex)
            {

                _logger.LogError("Currency Delete :" + ex.ToString());
            }

            return Json("Success");
        }
    }
}
