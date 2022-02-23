using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OA.Entity
{
    public class OaDbContext : DbContext
    {
        public OaDbContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department>  Departments{ get; set; }
        public DbSet<User>  Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(config => {
                config.Property(m => m.DeptName).HasMaxLength(50);
                config.Property(m => m.DeptManageName).HasMaxLength(50);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}