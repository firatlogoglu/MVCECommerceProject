using MVCECommerceProject.CORE.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceProject.MODEL.Entities
{
    public class Category : CoreEntity
    {
        [Required(ErrorMessage = "Lütfen bir isim girin"), Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen bir görsel seçin"), Display(Name = "Görsel")]
        public string ImagePath { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        //Mapping
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}