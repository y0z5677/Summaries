using System.Collections.Generic;

namespace Summaries.Data
{
    public interface IBookService
    {
        List<Book> getAllBooks();
        Book GetBookById(int id);
        void UpdateBook(int id, Book newBook);
        void DeleteBook(int id);

        void AddBook(Book newBook);
        
    }
}