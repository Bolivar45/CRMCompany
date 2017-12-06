using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMCompany.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }     
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Мобильный телефон")]
        public string MobilePhone { get; set; }
        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }
        [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}