using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Repositories
{
    public interface ICategoryRepo : ICrudRepo
    {
        public Task<List<Category>> GetCategories();
        public getCatDto GetCategoryById(string CatId);

        public Task<bool> SaveChanges();
        public Task<int> RowCount();
    }
}
