using MVCECommerceProject.CORE.Entity;
using MVCECommerceProject.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCECommerceProject.MODEL.Entities
{
    public class AppUser : CoreEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı zorunlu!")]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public Role? Role { get; set; }
        public DateTime? BirthDate { get; set; }

        //Mapping
        public List<Order> Orders { get; set; }
    }
}