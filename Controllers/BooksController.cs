using System;
using Microsoft.AspNetCore.Mvc;
using Summaries.Data;

namespace Summaries.Controllers
{
    [Route("api/[controller]")]
    public class BooksController: Controller
    {
        private IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }

        //create/Add a new book
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody]Book book)
        {
            try {
                if (book.Author != null && book.Title != null && book.Description != null)
                {
                    _service.AddBook(book);
                    return Ok(book);
                }
                return BadRequest("Book was not added");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
   
        }

        //Read All Books
        [HttpGet("[action]")]
        public IActionResult GetBooks() {
            var allBooks = _service.getAllBooks();
            return Ok(allBooks);    
        }

        //Update Book
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody]Book book) {
            _service.UpdateBook(id, book);
            return Ok(book);
        }

        //Delete Book
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _service.DeleteBook(id);
            return Ok();
        }

        //Get single book
        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            return Ok(book);
        }
    }
}