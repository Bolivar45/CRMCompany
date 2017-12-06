using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class EntityModel
    {
        public int Id { get; set; }
        [DisplayName("Юр. лицо")]
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Мобильный теелфон")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        [Required]
        [DisplayName("Адрес")]
        public string Addres { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Комментарий")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}