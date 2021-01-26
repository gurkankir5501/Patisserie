using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class BackgroundPhotos
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Fotoğraf Adı Giriniz")]
        public String Name { get; set; }

       
    }
}