using Microsoft.EntityFrameworkCore;
using Relacao1x1.Data;
using Relacao1x1.Model;
using System;
using System.Linq;

namespace Relacao1x1
{
    class Program
    {
        static void Main(string[] args)
        {
            Blog blog = new Blog()
            {
                Url = "www.meublog.com"
            };

            BlogImage blogImage = new BlogImage()
            {
                Image = "Imagem",
                Blog = blog
            };

            using (var db = new MyContext())
            {
                CriarDatabase();
                try
                {
                    db.Add(blogImage);
                    db.SaveChanges();
                    Console.WriteLine("Objetos persistidos com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao persistir os objetos!");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void CriarDatabase()
        {
            using (var db = new MyContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                if (db.Blogs.Any())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.Blogs");
                }
                if (db.BlogImages.Any())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.BlogImages");
                }
            }
        }
    }
}
