using MehmetGobirinTanirgan_Homework1_BookApi.FakeDb;
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
        private static List<Book> bookList;
        public BookController()
        {
            bookList = BookTable.bookList;// Bir db üzerinde çalışıyormuş gibi hissettirmek için static class içerisine list
                                          // oluşturuldu.
        }

        [HttpPost("GetAll")]//Aynı anda her iki post'u çalıştırmak için route path'ini değiştirdim.
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

            var doesExist = bookList.Any(x => x.Id == reqBook.Id || (x.Name == reqBook.Name && x.Author == reqBook.Author)
            || x.SerialNumber == reqBook.SerialNumber); // Girilen kaydın mevcut olup olmadığını kontrol etmek için.
            if (doesExist)
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

            // Burada default değer gelmesi durumunda, yani kullanıcının değiştirmediği özelliklerin
            // eski değerini koruması amaçlandı.
            book.Name = reqBook.Name != "string" ? reqBook.Name : book.Name;
            book.Author = reqBook.Author != "string" ? reqBook.Author : book.Author;
            book.SerialNumber = reqBook.SerialNumber != "string" ? reqBook.SerialNumber : book.SerialNumber;
            book.Price = reqBook.Price != default ? reqBook.Price : book.Price;

            return Ok(new { Message = "Successfully updated", Object = bookList });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
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
