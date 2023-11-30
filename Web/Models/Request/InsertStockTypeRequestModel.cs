using System.ComponentModel.DataAnnotations;

namespace Web.Models.Request
{
    public class InsertStockTypeRequestModel
    {
        public long ID { get; set; }

        [Display(Name = "StockTypeName")]
        [Required(ErrorMessage = "Stok türü adı boş geçilemez")]
        public string? StockTypeName { get; set; }
    }
}
