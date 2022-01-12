using Microsoft.AspNetCore.Mvc;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Services
{
    public interface IUserService
    {
        public List<User> GetUsers { get; }
        Task<User> GetUser(string email);
        Task<User> EditUser(User user);
        Task<bool> DeleteUser(User user);
    }
}
