using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class Recipe
    {

        public int Id { get; set; }
        [Required]
        [DisplayName("Tarif Adı giriniz")]
        public String RecipeName { get; set; }

        [Required]
        [DisplayName("Malzemeleri giriniz")]
        public String Materials { get; set; }

        [Required]
        [DisplayName("Tarifi giriniz")]
        public String Fabrication { get; set; }

        [Required]
        [DisplayName("Kategori Seçiniz")]
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}