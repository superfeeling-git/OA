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
        //特性 Attribute
        //属性
        public OaDbContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// 属性
        /// </summary>
        public DbSet<Department>  Departments{ get; set; }
        public DbSet<User>  Users{ get; set; }
        public DbSet<UserAccount>  userAccounts{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(config => {
                config.Property(m => m.DeptName).HasMaxLength(50);
                config.Property(m => m.DeptManageName).HasMaxLength(50);
                config.Property(m => m.Remark).HasMaxLength(500);
            });

            modelBuilder.Entity<UserAccount>(config => {
                config.Property(m => m.Password).HasMaxLength(50);
                config.Property(m => m.Account).HasMaxLength(50);
                config.Property(m => m.FullName).HasMaxLength(500);
                config.Property(m => m.Tel).HasMaxLength(500);
                config.Property(m => m.LastLoginIp).HasMaxLength(500);
                //主外键关系
                //.......
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}