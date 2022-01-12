using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEbookLibrary.Data.Repositories.Database;
using MyEbookLibrary.Dtos;
using MyEbookLibrary.Models;
using MyEbookLibrary.Services;
using MyEbookLibrary.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _cat;
        

        public CategoryController(ICategoryService cat)
        {
            _cat = cat;
        }

        [HttpGet("get-categories")]
        public IActionResult GetCategories()
        {
            var categories = _cat.GetCategories();

            if(categories == null)
            {
                return NotFound("No any categories found");
            }

            return Ok(categories);
        }

        [HttpGet("GetCategory/{Id}")]

        public IActionResult GetCategoryById(string Id)
        {
            if (!ModelState.IsValid) return Ok("Invalid details");

            var category =  _cat.GetCategory(Id);
            
            if (category == null)
            {
                return NotFound("No category found with this Id");
            }

            return Ok(category);
        }

        [Authorize(Roles = UserRoles.Admin)]

        [HttpPost("add-category")]

        public IActionResult AddNewCategory([FromBody] addCatDto cat)
        {
            if (!ModelState.IsValid) return Ok("Invalid details");

            var newCat = new Category();
            newCat.Name = cat.Name;

            _cat.AddCategory(newCat);

            return Ok("Category added successfully");
            
        }

        [Authorize(Roles = UserRoles.Admin)]

        [HttpDelete("DeleteCategory/{Id}")]
        public IActionResult DeleteCategory(string Id)
        {
            _cat.DeleteCategory(Id);
            return Ok("Category deleted successfully");
        }
    }
}
