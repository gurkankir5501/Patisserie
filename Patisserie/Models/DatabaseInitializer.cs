using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patisserie.Models
{
    public class DatabaseInitializer:System.Data.Entity.CreateDatabaseIfNotExists<DataBase>
    {
        protected override void Seed(DataBase context)
        {
            BackgroundPhotos b = new BackgroundPhotos() { Name = "Home sayfası 1. arka plan" };
            BackgroundPhotos b2 = new BackgroundPhotos() { Name = "Home sayfası 2. arka plan" };
            BackgroundPhotos b3 = new BackgroundPhotos() { Name = "Hakkımızda sayfasısı arka plan" };
            BackgroundPhotos b4 = new BackgroundPhotos() { Name = "İletişim sayfası arka plan" };

            context.backgroundPhotos.Add(b);
            context.backgroundPhotos.Add(b2);
            context.backgroundPhotos.Add(b3);
            context.backgroundPhotos.Add(b4);

            About about = new About() { Title = "Title", Text = "yazı metnini düzenleyiniz" };
            context.abouts.Add(about);

            Contact contact = new Contact() { Adress = "514 S. Magnolia St. Orlando, FL 32806", Mail = "info@demolink.org", PhoneNumber = "+1 718-999-3939", Instagram = "#", Facebook = "#", Twitter = "#" };

            context.contacts.Add(contact);

            Words words = new Words() { Name = "Name", Text = "yazı" };
            context.words.Add(words);

            Administration administration = new Administration() { Username = "admin", Password = "admin" };
            context.administrations.Add(administration);

           

            context.SaveChanges();
        }
    }
}