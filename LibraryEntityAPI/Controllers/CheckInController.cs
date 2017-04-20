using LibraryEntityAPI.DataContext;
using LibraryEntityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LibraryEntityAPI.Controllers
{
    public class CheckInController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooks(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Books books = db.Books.Find(id);
            if (books == null)
            {
                return NotFound();
            }

            var updating = db.Books.FirstOrDefault(f => f.Id == id);
            if (updating.IsCheckedOut == true)
            {

                updating.IsCheckedOut = false;
                db.SaveChanges();
                return Ok(new { Message = "Thank you for bringing the book back homes" });
            }


            else
            {
                return Ok(new
                {
                    Message = "The book is already checked in "
                });
            }

        }
        }
}
