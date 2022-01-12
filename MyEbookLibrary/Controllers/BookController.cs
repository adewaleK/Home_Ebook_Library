using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using MyEbookLibrary.Services;
using MyEbookLibrary.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookS, IMapper mapper)
        {
            bookService = bookS;
            _mapper = mapper;
        }
        
        
        [HttpGet("get-books")]      
        public IActionResult GetBooks()
        {
            //var categories = _cat.GetCategories();
            var books = bookService.GetBooks();

            if (books == null)
            {
                return NotFound("No book found");
            }

            return Ok(books.Result);
        }


        [HttpGet("GetBook/{Id}")]

        public IActionResult GetBookById(string Id)
        {
            if (!ModelState.IsValid) return Ok("Invalid details");

            var book = bookService.GetBookById(Id);

            if (book == null)
            {
                return NotFound("No book found with this Id");
            }

            return Ok(book.Result);
        }

        [Authorize(Roles = UserRoles.Admin)]

        [HttpPost("AddBook")] 
        public async Task<IActionResult> CreateBook(addBookDto bookDto)
        {
            if (!ModelState.IsValid) return Ok("Invalid details");

            if (await bookService.AddBook(bookDto))
            {
                return Ok("book added successfully");
            }

            return Ok("Book could not be added");
        }


        //[Authorize(Roles = UserRoles.Admin)]

        //[HttpDelete("DeleteBook/{Id}")]

        //public IActionResult DeleteBook(string Id)
        //{
        //    bookService.DeleteBook(Id);
        //    return Ok("Category deleted successfully");
        //}

    }
}
