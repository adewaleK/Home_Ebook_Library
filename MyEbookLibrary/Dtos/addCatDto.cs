using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Dtos
{
    public class addCatDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        
        public string Name { get; set; }
    }
}
