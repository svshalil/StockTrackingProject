using System.ComponentModel.DataAnnotations;

namespace Web.Models.Request
{
    public class InsertStockClassRequestModel
    {
        public long ID { get; set; }

        [Display(Name = "StockClassName")]
        [Required(ErrorMessage = "Stok sınıfı adı boş geçilemez")]
        public string StockClassName { get; set; }
    }
}
