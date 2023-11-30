namespace Web.Models.Response
{
    public class InsertStockResponseModel
    {
        public long StockID { get; set; }
        public long StockUnitCode { get; set; }
        public string? UnitDescription { get; set; }
        public string? StockTypeName { get; set; }
        public string? StockUnitName { get; set; }
        public string? StockClassName { get; set; }
        public int Amount { get; set; }
        public string? CriticalAmount { get; set; }
        public string? ShelfInformation { get; set; }
        public string? CabinetInformation { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
