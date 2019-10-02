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
            using (var db = new MyContext())
            {
                CriarDatabase();

                Produto produto_1 = new Produto
                {
                    ProdutoId = "prod_01",
                    Descricao = "Coca-Cola",
                    ProdutoItem = new List<ProdutoItem>()
                };

                Item item_1 = new Item
                {
                    ItemId = "item_01",
                    Quantidade = 3,
                    ProdutoItem = new List<ProdutoItem>()
                };

                Item item_2 = new Item
                {
                    ItemId = "item_02",
                    Quantidade = 5,
                    ProdutoItem = new List<ProdutoItem>()
                };

                Item item_3 = new Item
                {
                    ItemId = "item_03",
                    Quantidade = 1,
                    ProdutoItem = new List<ProdutoItem>()
                };

                ProdutoItem pi_1 = new ProdutoItem
                {
                    ProdutoId = produto_1.ProdutoId,
                    Produto = produto_1,
                    ItemId = item_1.ItemId,
                    Item = item_1
                };

                ProdutoItem pi_2 = new ProdutoItem
                {
                    ProdutoId = produto_1.ProdutoId,
                    Produto = produto_1,
                    ItemId = item_2.ItemId,
                    Item = item_2
                };

                ProdutoItem pi_3 = new ProdutoItem
                {
                    ProdutoId = produto_1.ProdutoId,
                    Produto = produto_1,
                    ItemId = item_3.ItemId,
                    Item = item_3
                };

                produto_1.ProdutoItem.Add(pi_1);
                produto_1.ProdutoItem.Add(pi_2);
                produto_1.ProdutoItem.Add(pi_3);

                try
                {
                    db.Update(produto_1);

                    db.SaveChanges();

                    Console.WriteLine("Objetos persistidos no banco de dados");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problemas ao persistir no banco de dados");
                }

            }
        }

        private static void CriarDatabase()
        {
            using (var db = new MyContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                if (db.Produto.Any())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.Produto");
                }
                if (db.Item.Any())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.Item");
                }
                if (db.ProdutoItem.Any())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.ProdutoItem");
                }
            }
        }
    }
}
