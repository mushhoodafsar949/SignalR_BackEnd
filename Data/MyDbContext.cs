using CRUDinCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDinCore.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<Student> Students { get; set; }
    }
}
