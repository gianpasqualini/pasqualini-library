using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasqualiniLibrary.DataModel;

namespace PasqualiniLibrary.Controllers
{
    [Route("api/Book")]
    public class BookController : Controller
    {
        //public static ICollection<Book> books = new LinkedList<Book>();

        LibraryDataContext _ctx = new LibraryDataContext();

        [HttpGet]
        public IEnumerable<Book> List()
        {
            return getOrderedBooks();
        }

        private IEnumerable<Book> getOrderedBooks()
        {
            return _ctx.Books.OrderBy(x => x.Title).ToList();
        }


        [HttpPost]
        public ActionResult Create([FromBody] Book toInsert)
        {
            try
            {
                _ctx.Books.Add(toInsert);
                _ctx.SaveChanges();

                return Ok(getOrderedBooks());
            }
            catch (Exception e)
            {
                return BadRequest(e.Data);
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] Book toUpdate)
        {
            try
            {
                _ctx.Books.Update(toUpdate);
                _ctx.SaveChanges();

                return Ok(getOrderedBooks());
            }
            catch (Exception e)
            {
                return BadRequest(e.Data);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Book data = _ctx.Books.Where(p => p.id == id).FirstOrDefault();
                if (data != null)
                {
                    _ctx.Books.Remove(data);
                    _ctx.SaveChanges();
                }
                return Ok(getOrderedBooks());
            }
            catch(Exception e)
            {
                return BadRequest(e.Data);
            }
        }

    }
}