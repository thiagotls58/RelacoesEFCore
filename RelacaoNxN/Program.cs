using Microsoft.EntityFrameworkCore;
using RelacaoNxN.Data;
using RelacaoNxN.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace RelacaoNxN
{
    class Program
    {
        static void Main(string[] args)
        {
            Post post1 = new Post() { Title = "Post 01" };
            Post post2 = new Post() { Title = "Post 02" };
            Post post3 = new Post() { Title = "Post 03" };

            Tag t1 = new Tag() { TagId = "Tag 01" };
            Tag t2 = new Tag() { TagId = "Tag 02" };
            Tag t3 = new Tag() { TagId = "Tag 03" };

            List<PostTag> postTags1 = new List<PostTag>()
            {
                new PostTag() { Post = post1, Tag = t1 },
                new PostTag() { Post = post1, Tag = t2 },
                new PostTag() { Post = post1, Tag = t3 }
            };
            post1.PostTags = postTags1;

            List<PostTag> postTags2 = new List<PostTag>()
            {
                new PostTag() { Post = post2, Tag = t1 },
                new PostTag() { Post = post2, Tag = t2 },
                new PostTag() { Post = post2, Tag = t3 }
            };
            post2.PostTags = postTags2;

            List<PostTag> postTags3 = new List<PostTag>()
            {
                new PostTag() { Post = post3, Tag = t1 },
                new PostTag() { Post = post3, Tag = t2 },
                new PostTag() { Post = post3, Tag = t3 }
            };
            post3.PostTags = postTags3;

            CriarDatabase();

            using (var db = new MyContext())
            {
                try
                {
                    db.Add(post1);
                    db.Add(post2);
                    db.Add(post3);
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

                if (db.PostTags.Any())
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.PostTags");

                if (db.Posts.Any())
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.Posts");

                if (db.Tags.Any())
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.Tags");
                
            }
        }
    }
}
