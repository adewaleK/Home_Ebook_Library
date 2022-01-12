using Microsoft.AspNetCore.Mvc;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Services
{
    public interface ICategoryService
    {
        //public Task<IActionResult> AddCategory(addCatDto model);

        public List<getAllCatsDto> GetCategories();

        public getCatDto GetCategory(string Id);

        public bool DeleteCategory(string Id);

        public bool AddCategory(Category cat);
        
    }
}
