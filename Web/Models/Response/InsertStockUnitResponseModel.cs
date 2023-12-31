﻿namespace Web.Models.Response
{
    public class InsertStockUnitResponseModel
    {
        public long ID { get; set; }
        public long StockUnitCode { get; set; }
        public string? StockUnitName { get; set; }
        public string? StockTypeName { get; set; }
        public string? AmountUnit { get; set; }
        public string? Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? PurchasePriceCurrencyName { get; set; }
        public decimal SalePrice { get; set; }
        public string? SalePriceCurrencyName { get; set; }
        public int PaperWeight { get; set; }
        public bool Status { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
