using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Dtos
{
    public class getAllCatsDto
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
    }
}
