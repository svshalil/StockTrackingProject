namespace Web.Models.Request
{
    public class UpdateStockUnitRequestModel
    {
        public long ID { get; set; }
        public long StockUnitCode { get; set; }
        public string? StockUnitName { get; set; }
        public long StockTypeID { get; set; }
        public string? AmountUnit { get; set; }
        public string? Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public long PurchasePriceCurrencyID { get; set; }
        public decimal SalePrice { get; set; }
        public long SalePriceCurrencyID { get; set; }
        public int PaperWeight { get; set; }
    }
}
