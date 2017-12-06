using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class WarhouseModel
    {
        public int Id { get; set; }
        [DisplayName("Склад")]
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Адрес")]
        public string Addres { get; set; }
    }
}