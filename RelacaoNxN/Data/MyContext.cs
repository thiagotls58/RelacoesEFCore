using Microsoft.EntityFrameworkCore;
using RelacaoNxN.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoNxN.Data
{
    class MyContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ProdutoItem> ProdutoItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFCore.Demo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoItem>()
                .HasKey(pi => new { pi.ProdutoId, pi.ItemId });
        }
    }
}
