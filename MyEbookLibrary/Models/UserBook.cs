using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Models
{
    public class UserBook : BaseEntity
    {
        [Required(ErrorMessage = "UserId is a required field")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "BookId is a required field")]
        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}
