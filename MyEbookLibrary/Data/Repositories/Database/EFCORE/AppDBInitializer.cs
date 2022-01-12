using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyEbookLibrary.Models;
using MyEbookLibrary.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEbookLibrary.Data.Repositories.Database.EFCORE
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.EnsureCreated();

                //Books
                if (!context.Books.Any()) 
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Id= "90f29a42-e6b0-4j8f-8ec1-8d0074c08e0b",
                            Title="voluptate",
                            ISBN = "79d429c5-d931-4333-b212-cb1d4f12828c",
                            Description = "Laboris ipsum non adipisicing aute. Dolor incididunt cillum " +
                            "irure incididunt aliqua ea voluptate cupidatat qui adipisicing. Mollit nostrud " +
                            "tempor ex laborum ipsum sunt laborum qui. Irure do cupidatat dolor est nostrud " +
                            "eu amet adipisicing anim. " +
                            "Sint esse elit nulla et velit elit minim amet",

                            PublishedAt = DateTime.Now,
                            CategoryId = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                            AuthorName = "Dennis Newman",
                            BookCover = "https://randomuser.me/portrait/men34.jpg"

                        },
                        new Book()
                        {
                            Id= "42f29a42-e6h0-4a8w-8ec1-9d0074c08e0b",
                            Title="deserunt",
                            ISBN = "71c877ac-d7f5-432b-959f-668e43783e9d",
                            Description = "Laboris ipsum non adipisicing aute. Dolor incididunt cillum " +
                            "irure incididunt aliqua ea voluptate cupidatat qui adipisicing. Mollit nostrud " +
                            "tempor ex laborum ipsum sunt laborum qui. Irure do cupidatat dolor est nostrud " +
                            "eu amet adipisicing anim. " +
                            "Sint esse elit nulla et velit elit minim amet",

                            PublishedAt = DateTime.Now,
                            CategoryId = "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                            AuthorName = "Bola idris",
                            BookCover = "https://randomuser.me/portrait/men93.jpg"
                        },

                        new Book()
                        {
                            Id= "45k29a42-e4b0-7a8f-9vc1-2d0074c08e0b",
                            Title="cillum",
                            ISBN = "8ecfddce-56b8-4229-ak63-4ef25f53d9b",
                            Description = "Laboris ipsum non adipisicing aute. Dolor incididunt cillum " +
                            "irure incididunt aliqua ea voluptate cupidatat qui adipisicing. Mollit nostrud " +
                            "tempor ex laborum ipsum sunt laborum qui. Irure do cupidatat dolor est nostrud " +
                            "eu amet adipisicing anim. " +
                            "Sint esse elit nulla et velit elit minim amet",

                            PublishedAt = DateTime.Now,
                            CategoryId = "38327868-cfa8-4f2f-b944-cb341ce17417",
                            AuthorName = "Fisher James",
                            BookCover = "https://randomuser.me/portrait/men85.jpg"
                        },

                        new Book()
                        {
                            Id= "10f24a42-e6b0-4x8f-8el1-2d0074c08e0z",
                            Title="Evil forest",
                            ISBN = "7d15b69e-cfb4-4b87-b62d-0c22090acb66",
                            Description = "Laboris ipsum non adipisicing aute. Dolor incididunt cillum " +
                            "irure incididunt aliqua ea voluptate cupidatat qui adipisicing. Mollit nostrud " +
                            "tempor ex laborum ipsum sunt laborum qui. Irure do cupidatat dolor est nostrud " +
                            "eu amet adipisicing anim. " +
                            "Sint esse elit nulla et velit elit minim amet",

                            PublishedAt = DateTime.Now,
                            CategoryId = "95f29a42-p6b0-4a8f-8ec1-2d0074c08e0b",
                            AuthorName = "David Dones",
                            BookCover = "https://randomuser.me/portrait/men93.jpg"
                        },

                         new Book()
                        {
                            Id= "22f29i42-e6d0-4a8f-1ec1-2d0074c08e0b",
                            Title="Night Play",
                            ISBN = "6ea58644-97d0-439c-aa67-1a53a81867e1",
                            Description = "Laboris ipsum non adipisicing aute. Dolor incididunt cillum " +
                            "irure incididunt aliqua ea voluptate cupidatat qui adipisicing. Mollit nostrud " +
                            "tempor ex laborum ipsum sunt laborum qui. Irure do cupidatat dolor est nostrud " +
                            "eu amet adipisicing anim. " +
                            "Sint esse elit nulla et velit elit minim amet",

                            PublishedAt = DateTime.Now,
                            CategoryId = "15242969-2d98-4883-8311-918d2b0e3b34",
                            AuthorName = "David Dones",
                            BookCover = "https://randomuser.me/portrait/men19.jpg"
                        }
                    }
  
                   );

                   context.SaveChanges();
                
                }

                //Categories

                if (!context.Categories.Any())
                {

                    context.Categories.AddRange(new List<Category>()

                        {
                          new Category()
                          {
                              Id= "45f29a42-e6b0-4a8f-8ec1-2d0074c08e0b",
                              Name= "deserunt"
                          },
                          new Category()
                          {
                               Id= "38327868-cfa8-4f2f-b944-cb341ce17417",
                               Name= "cillum"
                          },
                          new Category()
                          {
                              Id= "15242969-2d98-4883-8311-918d2b0e3b34",
                              Name= "dolore"
                          },
                           new Category()
                          {
                              Id= "95f29a42-p6b0-4a8f-8ec1-2d0074c08e0b",
                              Name= "deserunt"
                          },

                        }

                    );

                    context.SaveChanges();

                }

                //UserBooks

                if (!context.UserBooks.Any())
                {

                    context.UserBooks.AddRange(new List<UserBook>()

                        {
                          new UserBook()
                          {   
                              UserId= "62fb18c4-3923-4c87-a2e0-d863729e7607",
                              BookId= "45k29a42-e4b0-7a8f-9vc1-2d0074c08e0b"
                          },

                          new UserBook()
                          {
                              UserId= "b3e4ef36-2e8a-4b94-a398-fafe3326f87f",
                              BookId= "10f24a42-e6b0-4x8f-8el1-2d0074c08e0z"
                          },
                        }
                    );

                    context.SaveChanges();

                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string adminUserEmail = "admin@myebooklib.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new User
                    {
                        FirstName = "Kamil",
                        LastName = "Adewale",
                        FullName = $"Kamilu Adewale",
                        UserName = adminUserEmail,
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAdminUser, "Coding@123?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //
                string appUserEmail = "user@myebooklib.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);

                if (appUser == null)
                {
                    var newAppUser = new User
                    {
                        FirstName = "Taofeek",
                        LastName = "Jimoh",
                        FullName = "Taofeek Jimoh",
                        UserName = appUserEmail,
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "Coding@123?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
