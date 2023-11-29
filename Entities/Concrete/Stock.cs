using Entities.Interfaces;

namespace Entities.Concrete
{
    public class Stock: ITable
    {
        public long ID { get; set; }
        public long StockClassID { get; set; }
        public long StockTypeID { get; set; }
        public long StockUnitID { get; set; }
        public int Amount { get; set; }
        public string? ShelfInformation { get; set; }
        public string? CabinetInformation { get; set; }
        public string? CriticalAmount { get; set; }
        public bool Status { get; set; }
        public DateTime RecordDate { get; set; }

        public StockUnit StockUnits { get; set; }
        public StockType StockTypes { get; set; }
        public StockClass StockClasss { get; set; }
       
    }
}
