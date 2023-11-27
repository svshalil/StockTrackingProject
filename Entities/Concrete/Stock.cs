using Entities.Interfaces;

namespace Entities.Concrete
{
    public class Stock: ITable
    {
        public int ID { get; set; }
        public int StockClassID { get; set; }
        public int StockClassName { get; set; }
        public int StockTypeID { get; set; }
        public int StockTypeName { get; set; }
        public int StockUnitID { get; set; }
        public int StockUnitName { get; set; }
        public int Amount { get; set; }
        public string? ShelfInformation { get; set; }
        public string? CriticalAmount { get; set; }
        public bool Status { get; set; }
        public DateTime RecordDate { get; set; }

        public StockType StockTypes { get; set; }
        public StockClass StockClasss { get; set; }
    }
}
