using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LibraryEntityAPI.Models;

namespace LibraryEntityAPI.DataContext
{
    public class LibraryContext :DbContext
    {
        public LibraryContext():base("name=DefaultConnection")
        {

        }

        public DbSet<Books> Books { get; set; }
    }
}