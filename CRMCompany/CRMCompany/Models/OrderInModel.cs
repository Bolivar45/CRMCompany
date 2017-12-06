using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class OrderInModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Товар")]
        public int? GoodId { get; set; }
        public GoodModel good { get; set; }
        [Required]
        [DisplayName("Дата")]
        public DateTime DateOpen { get; set; }
        [Required]
        [DisplayName("Поставщик")]
        public int? ConterpartyId { get; set; }
        public ConterpartyModel Conterparty { get; set; }
        [Required]
        [DisplayName("Цена")]
        public float Prise { get; set; }
        [Required]
        [DisplayName("Количество")]
        public int Count { get; set; }
        [Required]
        [DisplayName("Итог")]
        public float Summ { get; set; }
    }
}