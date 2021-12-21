using MehmetGobirinTanirgan_Homework1_BookApi.Models;
using System.Collections.Generic;

namespace MehmetGobirinTanirgan_Homework1_BookApi.FakeDb
{
    public static class BookTable
    {
        public static List<Book> bookList = new()
        {
            new Book(1, "A Thousand Splendid Suns", "Khaled Hosseini", "1-634-28-34", 35),
            new Book(2, "Dune", "Frank Herbert", "2-334-57-08", 44.50),
            new Book(3, "War and Peace", "Leo Tolstoy", "3-224-33-99", 30),
            new Book(4, "Crime and Punishment", "Fyodor Dostoevsky", "2-021-03-67", 29.50),
            new Book(5, "The Lord of the Rings", "J.R.R. Tolkien", "8-386-48-44", 28),
            new Book(6, "The Kite Runner", "Khaled Hosseini", "3-765-21-87", 29.50),
        };
    }
}
