using Entities.Interfaces;

namespace Entities.Concrete
{
    public class StockType: ITable
    {
        public long ID { get; set; }
        public string? StockTypeName { get; set; }
        public bool Status { get; set; }

        public List<Stock> Stocks { get; set; }
        public List<StockUnit> StockUnits { get; set; }
    }
}
