using Microsoft.EntityFrameworkCore;
using RelacaoNxN.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoNxN.Data
{
    class MyContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=EFCore.Relacoes;Trusted_Connection=True;");
        }
    }
}
