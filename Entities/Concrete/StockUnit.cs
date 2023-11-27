using Entities.Interfaces;

namespace Entities.Concrete
{
    public class StockUnit: ITable
    {
        public int ID { get; set; }
        public long StockUnitCode { get; set; }
        public int StockUnitName { get; set; }
        public int StockTypeID { get; set; }
        public int StockTypeName { get; set; }
        public string? AmountUnit { get; set; }
        public string? Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchasePriceCurrencyID { get; set; }
        public string? PurchasePriceCurrency { get; set; }
        public decimal SalePrice { get; set; }
        public int SalePriceCurrencyID { get; set; }
        public string? SalePriceCurrency { get; set; }
        public int PaperWeight { get; set; }
        public bool Status { get; set; }
        public DateTime RecordDate { get; set; }

        public StockType StockTypes { get; set; }



    }
}
