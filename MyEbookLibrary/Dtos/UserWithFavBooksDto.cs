using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Dtos
{
    public class UserWithFavBooksDto
    {
        public string UserName { get; set; }

        public string FullName { get; set; }
        public List<BooksToReturnDto> FavBooks { get; set; }
    }
}
