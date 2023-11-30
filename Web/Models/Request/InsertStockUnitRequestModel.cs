using System.ComponentModel.DataAnnotations;

namespace Web.Models.Request
{
    public class InsertStockUnitRequestModel
    {
        [Display(Name = "StockUnitCode")]
        [Required(ErrorMessage = "Stok birim kodu geçilemez")]
        public long StockUnitCode { get; set; }

        [Display(Name = "StockUnitName")]
        [Required(ErrorMessage = "Stok birim adı geçilemez")]
        public string? StockUnitName { get; set; }

        [Display(Name = "StockTypeID")]
        [Required(ErrorMessage = "Stok türü boş geçilemez")]
        public long StockTypeID { get; set; }

        [Display(Name = "AmountUnit")]
        [Required(ErrorMessage = "Miktar birimi boş geçilemez")]
        public string? AmountUnit { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Açıklama boş geçilemez")]
        public string? Description { get; set; }

        [Display(Name = "PurchasePrice")]
        [Required(ErrorMessage = "Alış fiyatı boş geçilemez")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "PurchasePriceCurrencyID")]
        [Required(ErrorMessage = "Alış fiyatı parası boş geçilemez")]
        public long PurchasePriceCurrencyID { get; set; }

        [Display(Name = "SalePrice")]
        [Required(ErrorMessage = "Satış fiyatı boş geçilemez")]
        public decimal SalePrice { get; set; }

        [Display(Name = "SalePriceCurrencyID")]
        [Required(ErrorMessage = "Statış fiyatı parası boş geçilemez")]
        public long SalePriceCurrencyID { get; set; }

        [Display(Name = "PaperWeight")]
        [Required(ErrorMessage = "Kağıt ağırlığı boş geçilemez")]
        public int PaperWeight { get; set; }
    }
}
