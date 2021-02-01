using jCoreDemoApp.Domain.Entities;
using jCoreDemoApp.Domain.ValueObjects;
using jCoreDemoApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace jCoreDemoApp.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Colour = Colour.Blue,
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

                await context.SaveChangesAsync();
            }
            if (!context.Contacts.Any())
            {
                context.Contacts.Add(new Contact
                {
                    Id = 1,
                    Name = "Maria Anders",
                    Company = "Alfreds Futterkiste",
                    Email="M.Anders@alfreds.com",
                    BirthDate="",
                    PhoneNumberPersonal="+447456288745",
                    PhoneNumberWork="+441427288015",
                    Address="1000 Berlin st",
                    Deleted= false,
                });

                context.Contacts.Add(new Contact
                {
                    Id = 2,
                    Name = "Ana Trujillo",
                    Company = "Tesla",
                    Email="A.Trujillo@tesla.com",
                    BirthDate="01/01/1980",
                    PhoneNumberPersonal="+527531590014",
                    PhoneNumberWork="+527531599999",
                    Address="500 Calle Picante",
                    Deleted= false,
                });

                context.Contacts.Add(new Contact
                {
                    Id = 3,
                    Name = "Antonio Moreno",
                    Company = "Alfreds Futterkiste",
                    Email="A.Moreno@toyota.com",
                    BirthDate="05/05/1975",
                    PhoneNumberPersonal="+1000000001",
                    PhoneNumberWork="+1000000002",
                    Address="525 Broadway St, New York, NY",
                    Deleted= false,
                });


                context.Contacts.Add(new Contact
                {
                    Id = 4,
                    Name = "Thomas Hardy",
                    Company = "Around the Horn",
                    Email="T.Hardy@thorn.com",
                    BirthDate="07/07/1982",
                    PhoneNumberPersonal="+15342534345",
                    PhoneNumberWork="+15342534341",
                    Address="400 Horn St, Hartfort, CT",
                    Deleted= false,
                });

                context.Contacts.Add(new Contact
                {
                    Id = 5,
                    Name = "Christina Berglund",
                    Company = "Berglunds snapbbkop",
                    Email="C.Berglund@snapbbkop.com",
                    BirthDate="11/10/1984",
                    PhoneNumberPersonal="+317456288745",
                    PhoneNumberWork="+311427288015",
                    Address="1543 Berglunds st, Denmark",
                    Deleted= false,
                });

                context.Contacts.Add(new Contact
                {
                    Id = 6,
                    Name = "Hanna Moss",
                    Company = "Blauer See Delikatessen",
                    Email="H.Moss@Delikatessen.com",
                    BirthDate="12/12/1982",
                    PhoneNumberPersonal="+17456288745",
                    PhoneNumberWork="+17456018015",
                    Address="356 6th St, Elizabeth, NJ",
                    Deleted= false,
                });                                                                


                await context.SaveChangesAsync();
            }            
        }
    }
}
