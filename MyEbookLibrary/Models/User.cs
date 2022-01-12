using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "FirstName is a required field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is a required field")]
        public string LastName { get; set; }

        [Display(Name ="Full name")]
        [Required(ErrorMessage = "Fullname is a required field")]
        public string FullName { get; set; }
        //[Required]
        public byte[] PasswordSalt { get; set; }

        //public List<UserRole> UserRoles { get; set; }
        public List<UserBook> UserBooks { get; set; }

        public User()
        {
            //UserRoles = new List<UserRole>();
            UserBooks = new List<UserBook>();

            FullName = $"{FirstName} {LastName}";
        }

    }
}
