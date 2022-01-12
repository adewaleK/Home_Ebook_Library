using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Models
{
    public class Book : BaseEntity
    {
        [Required(ErrorMessage = "Title is a required field.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is a required field.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }

        [Required(ErrorMessage = "CategoryId is a required field.")]
        public string CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "AuthorName is a required field.")]
        public string AuthorName { get; set; }

        public string BookCover { get; set; }

        public List<UserBook> UserBooks { get; set; }

        public Book()
        {
            UserBooks = new List<UserBook>();
        }
    }
}
