using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Точка продаж")]
        public int? StoreId { get; set; }
        public StoreModel Strore { get; set; }
        [Required]
        [DisplayName("Дата открытия смены")]
        public DateTime DateOpen { get; set; }
        [Required]
        [DisplayName("Дата закрытия смены")]
        public DateTime DateClose { get; set; }
        [DisplayName("Юр. лицо")]
        [Required]
        public int? EntityId { get; set; }
        public EntityModel Entity { get; set; }
        [DisplayName("Итог наличные")]
        public float SummCash { get; set; }
        [DisplayName("Итог безналичные")]
        public float SummNonCash { get; set; }
        [Required]
        [DisplayName("Итог")]
        public float Summ { get; set; }
        [Required]
        [DisplayName("Начальная касса")]
        public float MoneyIn { get; set; }
        [Required]
        [DisplayName("Конечная касса")]
        public float MoneyOut { get; set; }
        [Required]
        [DisplayName("Валюта")]
        public int? CurrencyId { get; set; }
        public CurrencyModel Currency { get; set; }
        [DisplayName("Комментарий")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }
}