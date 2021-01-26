using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class DataBase:DbContext
    {
        public DataBase() : base("baglanti") { }

        public DbSet<About> abouts { get; set; }
        public DbSet<Administration> administrations { get; set; }
        public DbSet<BackgroundPhotos> backgroundPhotos { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<MainGalery> mainGaleries { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Words> words { get; set; }
    }
}