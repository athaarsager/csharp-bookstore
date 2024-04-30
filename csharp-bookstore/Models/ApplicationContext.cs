// Had to install EntityFrameworkCore via Nuget
// Need it for ability to interact with database
using Microsoft.EntityFrameworkCore;

namespace csharp_bookstore.Models;
// DbContext class is provided by Entity Framework Core
// The class constructor takes a parameter of type DbContextOptions<ApplicationContext>, 
// which provides configuration options for the ApplicationContext.
public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    // From Chat GPT:
    // This line declares a property named Book of type DbSet<Book>. 
    // DbSet<T> is a property of DbContext that represents a collection of entities of type T in the database.
    // In this case, PetOwner represents the table or collection of PetOwner entities in the database.
    public DbSet<Book> Book { get; set; }
}
