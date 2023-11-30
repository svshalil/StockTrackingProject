namespace Web.Models.Response
{
    public class InsertCurrencyResponseModel
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public bool Status { get; set; }
    }
}
