using Microsoft.EntityFrameworkCore;
using MyEbookLibrary.Data.Repositories.Database;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Repositories
{
    public class BookRepo : IBookRepo
    {

        private readonly DataContext _ctx;

        public BookRepo(DataContext ctx)
        {
            _ctx = ctx;

        }

        public Task<bool> Add<T>(T entity)
        {
            var book = entity as Book; 

            _ctx.AddAsync(book);

            return SaveChanges();
        }

        public Task<bool> Delete<T>(T entity)
        {
            var book = entity as Book;
            _ctx.Remove(entity);
            return SaveChanges();
        }

        public Task<bool> Edit<T>(T entity)
        {
            var book = entity as Book;
            _ctx.Update(entity);
            return SaveChanges();

        }

        public async Task<BookToReturnDto> GetBook(string BookId)
        {
            //return await _ctx.Books.FirstOrDefaultAsync(x => x.Id == BookId);

            var bookWithCat = await _ctx.Books.Where(b => b.Id == BookId).Select(book => new BookToReturnDto()
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                PublishedAt = book.PublishedAt,
                AuthorName = book.AuthorName,
                Category = book.Category.Name

            }).FirstOrDefaultAsync();

            return bookWithCat;
        }

        public async Task<List<BookToReturnDto>> GetBooks()
        {
            //return await _ctx.Books.ToListAsync();
            var books = await _ctx.Books.Select(book => new BookToReturnDto()
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                PublishedAt = book.PublishedAt,
                AuthorName = book.AuthorName,
                Category = book.Category.Name,

            }).ToListAsync();

            return books;
        }

        public async Task<int> RowCount()
        {
            return await _ctx.Books.CountAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
