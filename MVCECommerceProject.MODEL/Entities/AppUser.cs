using MVCECommerceProject.CORE.Entity;
using MVCECommerceProject.MODEL.Enums;
using MVCECommerceProject.MODEL.Enums.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCECommerceProject.MODEL.Entities
{
    public class AppUser : CoreEntity
    {
        [Required(ErrorMessage = "Lütfen T.C numaranızı girin"), Display(Name = "TC Kimlik No")]
        public string TCNO { get; set; }

        [Required(ErrorMessage = "Lütfen isminizi girin"), Display(Name = "İsim")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soy isminizi girin"), Display(Name = "Soy İsim")]
        public string SurName { get; set; }

        //[Required(ErrorMessage = "Kullanıcı Adı zorunlu!")]
        //public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre girin"), Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
        //[NotMapped]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen bir e-posta adresi giriniz."), EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz."), Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen bir görsel seçin"), Display(Name = "Görsel")]
        public string ImagePath { get; set; }

        [Display(Name = "Doğum Yeri")]
        public string BirthPlace { get; set; }
        public Role? Role { get; set; }

        [Display(Name = "Kan Grubu")]
        public BloodType? BloodType { get; set; }
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

        [Display(Name = "Medeni Hali")]
        public MaritalState MaritalState { get; set; }

        //Mapping
        public List<Order> Orders { get; set; }
    }
}