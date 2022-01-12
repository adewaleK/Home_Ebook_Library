using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Repositories
{
    public interface IBookRepo : ICrudRepo
    {
        Task<List<BookToReturnDto>> GetBooks();
        Task<BookToReturnDto> GetBook(string BookId);

        Task<bool> SaveChanges();
        Task<int> RowCount();
    }
}
