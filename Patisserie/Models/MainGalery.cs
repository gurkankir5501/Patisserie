using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class MainGalery
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Eklenen Tarifler")]
        public int RecipeId { get; set; }
        public Recipe recipe { get; set; }
    }
}