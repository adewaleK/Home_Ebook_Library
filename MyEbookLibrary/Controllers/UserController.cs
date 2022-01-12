using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEbookLibrary.Data.Repositories.Database;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public UserController(UserManager<User> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var listOfUsersToReturn = new List<usersToReturnDto>();

            foreach (var user in users)
            {
                listOfUsersToReturn.Add(new usersToReturnDto
                {
                    Email = user.Email,
                    FullName = user.FullName
                });
            }

            return Ok(listOfUsersToReturn);

        }


        //ADD A BOOK AS FAVOURITE BY CURRENT USER
        [Authorize]
        [HttpPost("addbook-as-favourite")]
        public async Task<IActionResult> AddBookAsFavourite([FromBody] FavBookDto book)
        {

            var cUserId = _userManager.GetUserId(HttpContext.User);

            var buCheck = await _context.UserBooks
                          .FirstOrDefaultAsync(bu => bu.BookId == book.Id && bu.UserId == cUserId);

            if (buCheck != null) return BadRequest("Book has already been added as a favourite");

            var newFav = new UserBook()
            {
                UserId = cUserId,
                BookId = book.Id
            };

            _context.UserBooks.Add(newFav);

            await _context.SaveChangesAsync();

            return Ok("Book successfully added as favourite");   
        }

        //Get All Favourite Books of A logged-in user
        [Authorize]
        [HttpPost("get-favourite-books")]
        public async Task<ActionResult<UserWithFavBooksDto>> GetFavouriteBooks()
        {
            var cUserId = _userManager.GetUserId(HttpContext.User);
            var AuthorFavBooks = await _context.Users.Where(user => user.Id == cUserId)
                .Select(user => new UserWithFavBooksDto(){                 
                  UserName = user.UserName,
                  FullName = user.FullName,
                  FavBooks = user.UserBooks.Select(ub => new BooksToReturnDto()
                  {
                      Title = ub.Book.Title,
                      ISBN = ub.Book.ISBN,
                      Description = ub.Book.Description,
                      PublishedAt = ub.Book.PublishedAt,
                      Category = ub.Book.Category.Name,
                      AuthorName = ub.Book.AuthorName,
                      BookCover = ub.Book.BookCover

                  }).ToList()      
                }).FirstOrDefaultAsync();
            return AuthorFavBooks;
        }

        [HttpGet("current-user")]
        public ActionResult<string> GetCurrentUser()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null) return BadRequest("You are not logged in");

            return userId;
        }

        

    }
}
