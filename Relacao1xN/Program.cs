using Microsoft.EntityFrameworkCore;
using Relacao1xN.Data;
using Relacao1xN.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Relacao1xN
{
    class Program
    {
        static void Main(string[] args)
        {
            Blog blog = new Blog()
            {
                Url = "www.meublog.com"
            };

            List<Post> posts = new List<Post>()
            {
                new Post(){ Title="Post 01" },
                new Post(){ Title="Post 02" },
                new Post(){ Title="Post 02" }
            };

            blog.Posts = posts;

            CriarDatabase();

            using (var db = new MyContext())
            {
                try
                {
                    db.Add(blog);
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
                if (db.Posts.Any())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.Posts");
                }
            }
        }
    }
}
