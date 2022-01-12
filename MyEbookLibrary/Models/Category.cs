using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Models
{
    public class Category :BaseEntity
    {   
        [Required(ErrorMessage ="Name is a required field")]
        public string Name { get; set; }

        public List<Book> Books { get; set; }

        public Category()
        {
            Books = new List<Book>();
        }
    }
}
