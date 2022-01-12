using AutoMapper;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, getAllCatsDto>();
            CreateMap<Category, getCatDto>();
            CreateMap<Book, BooksToReturnDto>();    
        }
    }
}
