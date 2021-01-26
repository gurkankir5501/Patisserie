using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Başlık giriniz")]
        public String Title { get; set; }

        [Required]
        [DisplayName("Yazı giriniz")]
        public String Text { get; set; }

       

        
    }
}