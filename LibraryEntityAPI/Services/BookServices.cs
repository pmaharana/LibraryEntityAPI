using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryEntityAPI.Models;
using LibraryEntityAPI.DataContext;

namespace LibraryEntityAPI.Services
{
    public class BookServices
    {
        LibraryContext db = new LibraryContext();

        public IEnumerable<Books> GetAllBooks()
        {
            var list = db.Books.ToList();
            return list;
        }

        public void CheckOutBook (int id)
        {

        }

    }
}