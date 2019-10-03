using Microsoft.EntityFrameworkCore;
using Relacao1x1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Relacao1x1.Data
{
    class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.BlogImage)
                .WithOne(bi => bi.Blog)
                .HasForeignKey<BlogImage>(bi => bi.BlogId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFCore.Relacoes;Trusted_Connection=True;");
        }
    }
}
