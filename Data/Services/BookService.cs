using System.Collections.Generic;
using System.Linq;

namespace Summaries.Data
{
    public class BookService : IBookService
    {
        void IBookService.AddBook(Book newBook)
        {
            Data.Books.Add(newBook);
        }

        void IBookService.DeleteBook(int id)
        {
            var del = Data.Books.FirstOrDefault(n=>n.Id == id);
            Data.Books.Remove(del);
        }

        List<Book> IBookService.getAllBooks()
        {
            return Data.Books.ToList();
        }

        Book IBookService.GetBookById(int id)
        {
            return Data.Books.FirstOrDefault(n=>n.Id == id);
        }

        void IBookService.UpdateBook(int id, Book newBook)
        {
            var oldData = Data.Books.FirstOrDefault(n => n.Id == id);
            if (oldData != null)
            {
                oldData.Title = newBook.Title;
                oldData.Author = newBook.Author;
                oldData.Description = newBook.Description;
                oldData.Rate = newBook.Rate;
                oldData.DateStart = newBook.DateStart;
                oldData.DateRead = newBook.DateRead;
            }
        }
    }
}