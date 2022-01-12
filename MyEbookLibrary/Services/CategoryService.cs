using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper) {    
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public List<getAllCatsDto> GetCategories()
        {
            var categories =  _categoryRepo.GetCategories().Result;

            var catsCto = _mapper.Map<List<getAllCatsDto>>(categories);

            return catsCto;
        }

        public getCatDto GetCategory(string Id)
        {  
            //return _categoryRepo.GetCategoryById(Id);

            var cat = _categoryRepo.GetCategoryById(Id);

            var catDto = _mapper.Map<getCatDto>(cat);

            //var final = new finalCatDto();

            return catDto;
           
        }
        
        public bool AddCategory(Category cat)
        {
            _categoryRepo.Add<Category>(cat);

            return true;     
        }

        public bool DeleteCategory(string Id)
        {
            _categoryRepo.Delete<getCatDto>(GetCategory(Id));
            return true;
        }
    }
}
