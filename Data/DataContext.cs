using CrudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Employees> Employees { get; set; }
    }
}
