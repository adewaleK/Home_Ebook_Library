using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Dtos
{
    public class usersToReturnDto
    {
        [Display(Name = "Full name")]
        [Required]
        public string FullName { get; set; }


        [Required]
        public string Email { get; set; }
    }
}
