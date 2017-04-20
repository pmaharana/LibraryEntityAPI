namespace LibraryEntityAPI.Migrations
{
    using LibraryEntityAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryEntityAPI.DataContext.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryEntityAPI.DataContext.LibraryContext db)
        {
            var books = new List<Books>
           {
               new Books {Title="Harry Potter & The Sorceror's Stone", Author="J.K. Rowling", YearPublished=2001,
               Genre="Fantasy", IsCheckedOut=false},

               new Books {Title="Fight Club", Author="Chuck Palahniuk", YearPublished=1997,
               Genre="Thriller", IsCheckedOut=false},

               new Books {Title="A Series of Unfortunate Events", Author="Lemony Snickett", YearPublished=1843,
               Genre="Horror", IsCheckedOut=false},

               new Books {Title="Adventures of Huckleberry Finn", Author="Mark Twain", YearPublished=1884,
               Genre="Adventure", IsCheckedOut=false},

               new Books {Title="The Art of War", Author="Sun Tzu", YearPublished=1200,
               Genre="Strategy Guide", IsCheckedOut=false},

           };

            books.ForEach(book => db.Books.AddOrUpdate(b => new { b.Title, b.Author }, book));
            db.SaveChanges();




        }
    }
}
