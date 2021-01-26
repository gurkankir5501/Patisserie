using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class Administration
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public String Username { get; set; }

        [Required]
        [DisplayName("Parola ")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}