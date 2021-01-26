using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Adınızı Giriniz")]
        public String Name { get; set; }

        [Required]
        [DisplayName("E Mail Giriniz")]
        [EmailAddress()]
        public String Mail { get; set; }

        [Required]
        [DisplayName("Telefon Numarası Giriniz")]
        [MinLength(11,ErrorMessage ="Telefon Numarası 11 Karakter Olmalıdır")]
        [MaxLength(11,ErrorMessage = "Telefon Numarası 11 Karakter Olmalıdır")]
        public String PhoneNumber { get; set; }

        [Required]
        [DisplayName("Metin Giriniz")]
        public String Messages { get; set; }
    }
}