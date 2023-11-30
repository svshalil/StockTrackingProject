using System.ComponentModel.DataAnnotations;

namespace Web.Models.Request
{
    public class InsertCurrencyRequestModel
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Para birimi adı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Symbol")]
        [Required(ErrorMessage = "Symbol boş geçilemez")]
        public string Symbol { get; set; }

        public bool Status { get; set; }
    }
}
