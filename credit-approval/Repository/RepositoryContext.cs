using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using credit_approval.Models;
using Microsoft.EntityFrameworkCore;

namespace credit_approval.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.UserId).IsUnique();
            });
        }
    }
}
