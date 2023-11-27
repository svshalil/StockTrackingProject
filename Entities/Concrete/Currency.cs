using Entities.Interfaces;

namespace Entities.Concrete
{
    public class Currency: ITable
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public bool Status { get; set; }

    }
}
