using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryEntityAPI.DataContext;
using LibraryEntityAPI.Models;

namespace LibraryEntityAPI.Controllers
{
    public class CheckOutController : ApiController
    {
        private LibraryContext db = new LibraryContext();


        // PUT: api/CheckOut/5
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
            if (!updating.IsCheckedOut.GetValueOrDefault())
            {

                updating.IsCheckedOut = true;
                updating.LastCheckedOutDate = DateTime.Now;
                updating.DueBackDate = DateTime.Now.AddDays(10);
                db.SaveChanges();
                return Ok(updating);
            }
            else
            {
                return Ok(new
                {
                    Message = "The book is already checked out. It will be due back on ", books.DueBackDate
                });
            }


            //try
            //{
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BooksExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

       
    }
}