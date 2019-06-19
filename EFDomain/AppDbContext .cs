using System;
using Microsoft.EntityFrameworkCore;
using Model;
namespace EFDomain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
