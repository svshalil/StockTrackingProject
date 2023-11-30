namespace Web.Models.Response
{
    public class UpdateCurrencyResponseModel
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public bool Status { get; set; }
    }
}
