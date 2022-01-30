using bulkybookname.Models;
using Microsoft.EntityFrameworkCore;

namespace bulkybookname.Data;

public class ApplicationDBcontext : DbContext
{
      public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
      {      
      }
        
    public DbSet<Category> categories { get; set; }
}

