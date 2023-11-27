using Entities.Interfaces;

namespace Entities.Concrete
{
    public class StockClass: ITable
    {
        public long ID { get; set; }
        public string? StockClassName { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}
