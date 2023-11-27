using Entities.Interfaces;

namespace Entities.Concrete
{
    public class StockUnit: ITable
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
        public int SalePriceCurrencyID { get; set; }
        public int PaperWeight { get; set; }
        public bool Status { get; set; }
        public DateTime RecordDate { get; set; }

        public StockType StockTypes { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}
