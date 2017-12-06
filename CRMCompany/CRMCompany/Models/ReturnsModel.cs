using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class ReturnsModel
    {
        public int Id { get; set; }
        [DisplayName("Точка продаж")]
        public int? StoreId { get; set; }
        public StoreModel Strore { get; set; }
        [DisplayName("Контрагент")]
        public int? ConterpatryId { get; set; }
        public ConterpartyModel Conterparty { get; set; }
        [DisplayName("Наличные")]
        public float Cash { get; set; }
        [DisplayName("Безналичные")]
        public float NonCash { get; set; }
        [DisplayName("Итог")]
        public float Summ { get; set; }
        [DisplayName("Валюта")]
        public int? CurrencyId { get; set; }
        public CurrencyModel Currency { get; set; }
        [DisplayName("Комментарий")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}