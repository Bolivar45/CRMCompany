using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class GoodModel
    {
        public int Id { get; set; }
        [DisplayName("Товар")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Артикул")]
        public string Articul { get; set; }
        [DisplayName("Страна")]
        public string Country { get; set; }
        [DisplayName("Ед.Изм.")]
        public string Measure { get; set; }
        [DisplayName("Вес")]
        public string Weight { get; set; }
        [DisplayName("Объем")]
        public string Capasity { get; set; }
        [DisplayName("НДС")]
        public int VAT { get; set; }
        [DisplayName("Неснижаемый остаток")]
        public int AutoOst { get; set; }
        [DisplayName("Закупочная цена")]
        public float PriseIn { get; set; }
        [DisplayName("Цена продажи")]
        public float PriseOut { get; set; }
        [DisplayName("Контрагент")]
        public int? ConterpartyId { get; set; }
        public ConterpartyModel Conterparty { get; set; }
        [DisplayName("Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}