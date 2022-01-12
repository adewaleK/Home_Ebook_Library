using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Services
{
    public interface IBookService
    {
        public Task<List<BookToReturnDto>> GetBooks();

        public Task<BookToReturnDto> GetBookById(string BkId);

        public Task<bool> AddBook(addBookDto book);

        //public bool DeleteBook(string Id);

        Task<bool> SaveChanges();
        Task<int> RowCount();
    }
}
