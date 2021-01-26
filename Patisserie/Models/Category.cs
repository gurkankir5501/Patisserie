using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        [DisplayName("kategori Adı ")]
        public String CategoryName { get; set; }
        
      
        public List<Recipe> categories { get; set; }
    }
}