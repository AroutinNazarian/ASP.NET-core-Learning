using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess;

public class ApplicationDBcontext : DbContext
{
      public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
      {      
      }
        
    public DbSet<Category> categories { get; set; }
}

