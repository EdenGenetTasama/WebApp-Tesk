using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers.api
{
    public class ValuesController : ApiController
    {
        // GET: api/Values

        List<Books> bookList = new List<Books>();
        private void ListOfBooks()
        {
            Random random = new Random();
            Books[] bookArray = new Books[]
            {
                new Books("BookOne", "WritterOne", 2010, random.Next(100, 500),1),
                new Books("BookTwo", "WritterTwo", 2000, random.Next(100, 500),2),
                new Books("BookThree", "WritterThree", 2003, random.Next(100, 500),3),
                new Books("BookFour", "WritterFour", 2004, random.Next(100, 500),4),
                new Books("BookFive", "WritterFive", 2005, random.Next(100, 500),5),
                new Books("BookSix", "WritterSix", 2006, random.Next(100, 500),6),
                new Books("BookSeven", "WritterSeven", 2007, random.Next(100, 500),7),
                new Books("BookEigth", "WritterEigth", 2008, random.Next(100, 500),8)
            };

            this.bookList.AddRange(bookArray);

        }
        public IHttpActionResult Get()
        {
            try
            {
                ListOfBooks();
                return Ok(bookList);

            }
            catch
            {
                return BadRequest("HOT FOUND");
            }
        }

        //GET: api/Values/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                ListOfBooks();
                Books booksById = (from book in bookList
                                   where book.id == id
                                   select book).First();

                return Ok(booksById);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/Values
        public IHttpActionResult Post([FromBody] Books value)
        {
            try
            {
                bookList.Add(value);
                return Ok(bookList);
            }

            catch
            {
                return Ok("Not found");
            }
        }

        // PUT: api/Values/5
        public IHttpActionResult Put(int id, [FromBody] Books value)
        {
            try
            {
                ListOfBooks();
                Books bookToPut = bookList.Find(item => item.id == id);
                bookList.IndexOf(bookToPut);
                bookList[bookList.IndexOf(bookToPut)].Name = value.Name;
                bookList[bookList.IndexOf(bookToPut)].writter = value.writter;
                bookList[bookList.IndexOf(bookToPut)].yearOfOut = value.yearOfOut;
                bookList[bookList.IndexOf(bookToPut)].numberOfPage = value.numberOfPage;
                bookList[bookList.IndexOf(bookToPut)].yearOfOut = value.yearOfOut;

                return Ok(bookList);
            }
            catch
            {
                return Ok("Eroor");
            }

        }

        // DELETE: api/Values/5
        public IHttpActionResult Delete(int id)
        {
            bookList.Remove(bookList.Find(item => item.id == id));
            return Ok("Removed");
        }
    }
}
