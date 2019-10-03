using Microsoft.EntityFrameworkCore;
using Relacao1xN.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Relacao1xN.Data
{
    class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=EFCore.Relacoes;Trusted_Connection=True;");
        }
    }
}
