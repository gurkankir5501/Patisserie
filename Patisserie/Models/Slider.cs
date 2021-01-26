using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class Slider
    {

        public int Id { get; set; }

        [DisplayName("Başlık")]
        public String TitleText { get; set; }
        [DisplayName("Yazı")]
        public String Text { get; set; }
       
    }
}