using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Точка продаж")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Юридическое лицо")]
        public int? EntityId { get; set; }
        [DisplayName("Юридическое лицо")]
        public EntityModel Entity { get; set; }
        [DisplayName("Склад")]
        [Required]
        public int? WarhouseId { get; set; }
        [DisplayName("Склад")]
        public WarhouseModel Warhouse { get; set; }
        [Required]
        [DisplayName("Адрес")]
        public string Addres { get; set; }
        [DisplayName("Комментарий")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}