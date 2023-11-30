﻿using Business.Interfaces;
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
        public StockUnitController(IStockUnitService stockUnitService, IStockTypeService stockTypeService, ICurrencyService currencyService)
        {
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _currencyService = currencyService;
        }
        public IActionResult Index()
        {
            List<StockUnit> stockUnits = _stockUnitService.GetAll();

            List<InsertStockUnitResponseModel> stockUnitRespnseModel = new List<InsertStockUnitResponseModel>();

            foreach (var item in stockUnits)
            {
                var stocktypes = _stockTypeService.GetById(item.StockTypeID);
                var salePriceCurrencyName = _currencyService.GetById(item.SalePriceCurrencyID);
                var PurchasePriceCurrencyName = _currencyService.GetById(item.PurchasePriceCurrencyID);
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
                    RecordDate= item.RecordDate,
                });
            }
            return View(stockUnitRespnseModel);
        }

        public IActionResult InsertStockUnit()
        {
            ViewBag.stocktypes = _stockTypeService.GetAll();
            ViewBag.currency = _currencyService.GetAll();
            return View(new InsertStockRequestModel());
        }

        [HttpPost]
        public IActionResult InsertStockUnit(InsertStockUnitRequestModel requestModel)
        {
            ViewBag.stocktypes = _stockTypeService.GetAll();
            ViewBag.currency = _currencyService.GetAll();
            if (ModelState.IsValid)
            {
                _stockUnitService.Insert(new StockUnit
                {
                   SalePrice = requestModel.SalePrice,
                   RecordDate= DateTime.Now,
                   StockUnitName= requestModel.StockUnitName,
                   StockUnitCode= requestModel.StockUnitCode,
                   PurchasePriceCurrencyID = requestModel.PurchasePriceCurrencyID,
                   SalePriceCurrencyID = requestModel.SalePriceCurrencyID,
                   AmountUnit = requestModel.AmountUnit,
                   Description = requestModel.Description,
                   ID=0,
                   PaperWeight=requestModel.PaperWeight,
                   PurchasePrice = requestModel.PurchasePrice,
                   Status=true,
                   StockTypeID=requestModel.StockTypeID,
                });
                return RedirectToAction("Index");
            }
            return View(requestModel);
        }

        public IActionResult UpdateStockUnit(long id)
        {
            ViewBag.stocktypes = _stockTypeService.GetAll();
            ViewBag.currency = _currencyService.GetAll();
            var getstockUnit = _stockUnitService.GetById(id);
            UpdateStockUnitResponseModel updateStock = new UpdateStockUnitResponseModel
            {
              StockTypeID = getstockUnit.StockTypeID,
              PurchasePrice= getstockUnit.PurchasePrice,
              PaperWeight = getstockUnit.PaperWeight,
              ID=getstockUnit.ID,
              Description=getstockUnit.Description,
              AmountUnit= getstockUnit.AmountUnit,
              PurchasePriceCurrencyID= getstockUnit.PurchasePriceCurrencyID,
              SalePrice = getstockUnit.SalePrice,
              SalePriceCurrencyID= getstockUnit.SalePriceCurrencyID,
              StockUnitCode= getstockUnit.StockUnitCode,
              StockUnitName = getstockUnit.StockUnitName
            };

            return View(updateStock);
        }

        [HttpPost]
        public IActionResult UpdateStockUnit(UpdateStockUnitRequestModel updateStockUnit)
        {
            ViewBag.stocktypes = _stockTypeService.GetAll();
            ViewBag.currency = _currencyService.GetAll();

            if (ModelState.IsValid)
            {
                _stockUnitService.Update(new StockUnit
                {
                   StockUnitName= updateStockUnit.StockUnitName,
                   StockUnitCode = updateStockUnit.StockUnitCode,
                   SalePriceCurrencyID = updateStockUnit.SalePriceCurrencyID,
                   SalePrice = updateStockUnit.SalePrice,
                   PurchasePriceCurrencyID = updateStockUnit.PurchasePriceCurrencyID,
                   AmountUnit = updateStockUnit.AmountUnit,
                   Description = updateStockUnit.Description,
                   ID = updateStockUnit.ID,
                   PaperWeight = updateStockUnit.PaperWeight,
                   PurchasePrice = updateStockUnit.PurchasePrice,
                   RecordDate=DateTime.Now,
                   Status=true,
                   StockTypeID= updateStockUnit.StockTypeID,
                });
                return RedirectToAction("Index");
            }


            return View(updateStockUnit);
        }

        [HttpDelete]
        public IActionResult DeleteStockUnit(long id)
        {
            _stockUnitService.Delete(new StockUnit { ID = id });

            return NoContent();
        }
    }
}