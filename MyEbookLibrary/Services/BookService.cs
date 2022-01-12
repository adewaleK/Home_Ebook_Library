using AutoMapper;
using MyEbookLibrary.Data.Repositories.Database;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using MyEbookLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _bookRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public BookService(IBookRepo bkRepo, ICategoryRepo categoryRepo, IMapper mapper)
        {
            _bookRepo = bkRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public Task<List<BookToReturnDto>> GetBooks()
        {
            //return _bookRepo.GetBooks().Result;


            var books = _bookRepo.GetBooks();

            //var booksDtoToReturn = _mapper.Map<List<BooksToReturnDto>>(books);

            return books;
        }

        public async Task<BookToReturnDto> GetBookById(string BkId)
        {
            return await _bookRepo.GetBook(BkId);
        }

        //public Task<bool> DeleteBook(string Id)
        //{

        //    _bookRepo.Delete<Book>(GetBookById(Id));
        //    return true;
        //}

        public Task<int> RowCount()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddBook(addBookDto bookModel)
        {
            
            if (_categoryRepo.GetCategoryById(bookModel.CategoryId) == null) return false;

            var newBook = new Book();

            newBook.Title = bookModel.Title;
            newBook.ISBN = bookModel.ISBN;
            newBook.Description = bookModel.Description;
            newBook.CategoryId = bookModel.CategoryId;
            newBook.AuthorName = bookModel.AuthorName;

            if (await _bookRepo.Add<Book>(newBook))
            {
                return true;
            }

            return false;
        }
    }
}
