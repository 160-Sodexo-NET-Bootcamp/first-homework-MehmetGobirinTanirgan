using MehmetGobirinTanirgan_Homework1_BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MehmetGobirinTanirgan_Homework1_BookApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private List<Book> bookList;
        public BookController()
        {
            bookList = new()
            {
                new Book(1, "A Thousand Splendid Suns", "Khaled Hosseini", "1-634-28-34", 35),
                new Book(2, "Dune", "Frank Herbert", "2-334-57-08", 44.50),
                new Book(3, "War and Peace", "Leo Tolstoy", "3-224-33-99", 30),
                new Book(4, "Crime and Punishment", "Fyodor Dostoevsky", "2-021-03-67", 29.50),
                new Book(5, "The Lord of the Rings", "J.R.R. Tolkien", "8-386-48-44", 28),
                new Book(6, "The Kite Runner", "Khaled Hosseini", "3-765-21-87", 29.50),
            };
        }

        [HttpPost("GetAll")]
        public IActionResult GetBooks()
        {
            if (bookList is null)
            {
                return NotFound();
            }

            if (bookList.Count == 0)
            {
                return NoContent();
            }

            return Ok(bookList);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Id is not valid" }); // Şuan için Anonymous Type döndüm, response için
                                                                        // bir return type modeli tanımlayıp, onu da
                                                                        // gönderebiliriz.
            }

            var book = bookList.FirstOrDefault(x => x.Id == id);

            if (book is null)
            {
                return NotFound(new { Message = "Book doesn't exist" });
            }

            return Ok(book);
        }


        //[HttpGet]
        //public IActionResult GetBookById([FromQuery] int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest(new { Message = "Id is not valid" });
        //    }

        //    var book = bookList.FirstOrDefault(x => x.Id.Equals(id));

        //    if (book is null)
        //    {
        //        return NotFound(new { Message = "Book doesn't exist" });
        //    }

        //    return Ok(book);
        //}

        [HttpPost]
        public IActionResult PostBook([FromBody] Book reqBook)
        {
            if (reqBook is null)
            {
                return BadRequest(new { Message = "Null data" });
            }

            if (reqBook.Id <= 0)
            {
                return BadRequest(new { Message = "Id is not valid" });
            }

            var isExist = bookList.Any(x => x.Id == reqBook.Id || (x.Name == reqBook.Name && x.Author == reqBook.Author)
            || x.SerialNumber == reqBook.SerialNumber); // Girilen kaydın mevcut olup olmadığını kontrol etmek için.
            if (isExist)
            {
                return BadRequest(new { Message = "Possible duplicate. Check your model" });
            }

            bookList.Add(reqBook);
            return Ok(new { Message = "Successfully added", Object = bookList });
        }

        [HttpPut]
        public IActionResult PutBook([FromBody] Book reqBook)
        {
            if (reqBook is null)
            {
                return BadRequest(new { Message = "Null data" });
            }

            if (reqBook.Id <= 0)
            {
                return BadRequest(new { Message = "Id is not valid" });
            }

            var book = bookList.FirstOrDefault(x => x.Id == reqBook.Id);

            if (book is null)
            {
                return NotFound(new { Message = "Book doesn't exist" });
            }

            book.Name = reqBook.Name;
            book.Author = reqBook.Author;
            book.SerialNumber = reqBook.SerialNumber;
            book.Price = reqBook.Price;

            return Ok(new { Message = "Successfully updated", Object = bookList });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Id is not valid" });
            }

            var book = bookList.FirstOrDefault(x => x.Id == id);

            if (book is null)
            {
                return NotFound(new { Message = "Book doesn't exist" });
            }

            bookList.Remove(book);
            return Ok(new { Message = "Successfully deleted", Object = bookList });
        }
    }
}
