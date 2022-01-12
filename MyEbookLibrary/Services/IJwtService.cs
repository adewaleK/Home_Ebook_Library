using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Services
{
    public interface IJwtService
    {
        public string CreateToken(User user);
    }
}
