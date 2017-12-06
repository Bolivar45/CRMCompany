using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class ConterpartyModel
    {
        public int Id { get; set; }
        [DisplayName("Контрагент")]
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Мобильный теелфон")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        [DisplayName("Факс")]
        public string Fax { get; set; }
        [DisplayName("Юридический Адрес")]
        public string LegalAddres { get; set; }
        [DisplayName("Физический Адрес")]
        public string ActualAddres { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Комментарий")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}