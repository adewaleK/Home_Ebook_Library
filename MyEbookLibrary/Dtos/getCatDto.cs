using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Dtos
{
    public class getCatDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }


        //public List<Book> Books { get; set; }
        public List<BooksDto> catBooks { get; set; }

    }


    public class BooksDto
    {
        public string Title { get; set; }

        public string ISBN { get; set; }
        public string Description { get; set; }

        public DateTime PublishedAt { get; set; }

    }
}
