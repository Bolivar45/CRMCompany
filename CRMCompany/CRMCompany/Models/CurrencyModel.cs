using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMCompany.Models
{
    public class CurrencyModel
    {
        public int Id { get; set; }
        [DisplayName("Код валюты")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Название валюты")]
        [Required]
        public string FullName { get; set; }
        [DisplayName("Коэффициент")]
        [Required]
        public float Сoefficient { get; set; }
    }
}