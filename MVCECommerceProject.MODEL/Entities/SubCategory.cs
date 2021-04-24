using MVCECommerceProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceProject.MODEL.Entities
{
    public class SubCategory : CoreEntity
    {
        [Required(ErrorMessage = "Lütfen bir isim girin"), Display(Name = "Alt Kategori Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen bir görsel seçin"), Display(Name = "Görsel")]
        public string ImagePath { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Etiketler")]
        public string Tag { get; set; }

        public virtual Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}