using LiveCodingDEMO.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace LiveCodingDEMO.DataAccess
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("database");
    }

}

