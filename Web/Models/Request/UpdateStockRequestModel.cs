using System.ComponentModel.DataAnnotations;

namespace Web.Models.Request
{
    public class UpdateStockRequestModel
    {
        public long ID { get; set; }
        [Display(Name = "StockClassID")]
        [Required(ErrorMessage = "Stok Sınıfı boş geçilemez")]
        public long StockClassID { get; set; }

        [Display(Name = "StockTypeID")]
        [Required(ErrorMessage = "Stok Türü boş geçilemez")]
        public long StockTypeID { get; set; }

        [Display(Name = "StockUnitID")]
        [Required(ErrorMessage = "Stok Birimi boş geçilemez")]
        public long StockUnitID { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Stok Miktarı boş geçilemez")]
        public int Amount { get; set; }

        [Display(Name = "ShelfInformation")]
        [Required(ErrorMessage = "Raf bilgisi boş geçilemez")]
        public string ShelfInformation { get; set; }

        [Display(Name = "CabinetInformation")]
        [Required(ErrorMessage = "Dolap bilgisi boş geçilemez")]
        public string CabinetInformation { get; set; }

        [Display(Name = "CriticalAmount")]
        [Required(ErrorMessage = "Kritik Miktar boş geçilemez")]
        public string CriticalAmount { get; set; }
        public bool Status { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
