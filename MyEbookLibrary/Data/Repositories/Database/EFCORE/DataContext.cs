using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEbookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Data.Repositories.Database
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }



        //public DbSet<BaseEntity> BaseEntities { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public DbSet<UserBook> UserBooks { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserBook>()
            .HasKey(s => new { s.UserId, s.BookId });

            builder.Entity<Category>()
            .HasMany(c => c.Books)
            .WithOne(b => b.Category);
        }
    }
}
