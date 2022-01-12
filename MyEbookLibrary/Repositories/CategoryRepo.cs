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
    public class CategoryRepo : ICategoryRepo
    {

            private readonly DataContext _ctx;

            public CategoryRepo(DataContext ctx)
            {
                _ctx = ctx;

            }
            public Task<bool> Add<T>(T entity)
            {
                var category = entity as Category;
                _ctx.AddAsync(category);
                return SaveChanges();
            }

            public Task<bool> Delete<T>(T entity)
            {
                var category = entity as Category;
                _ctx.Remove(category);
                return SaveChanges();
            }

            public Task<bool> Edit<T>(T entity)
            {
                throw new NotImplementedException();
            }

            public Task<List<Category>> GetCategories()
            {
                return _ctx.Categories.ToListAsync();
            }

            public getCatDto GetCategoryById(string CatId)
            {
                var category = _ctx.Categories.Where(cat => cat.Id == CatId).Select(cat => new getCatDto()
                {
                    Name = cat.Name,
                    catBooks = cat.Books.Select(b => new BooksDto()
                    {
                        Title = b.Title,
                        ISBN = b.ISBN,
                        Description = b.Description,
                        PublishedAt = b.PublishedAt
                    }).ToList()

                }).FirstOrDefault();

                return category;
            }

            public async Task<int> RowCount()
            {
                return await _ctx.Categories.CountAsync();
            }

            public async Task<bool> SaveChanges()
            {
                return await _ctx.SaveChangesAsync() > 0;
            }
        }
    } 


