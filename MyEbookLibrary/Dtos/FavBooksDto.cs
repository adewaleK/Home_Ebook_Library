using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Dtos
{
    public class FavBooksDto
    {
        [Required(ErrorMessage = "Title is a required field.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is a required field.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }

        [Required(ErrorMessage = "CategoryId is a required field.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "AuthorName is a required field.")]
        public string AuthorName { get; set; }

        public string BookCover { get; set; }

    }
}
