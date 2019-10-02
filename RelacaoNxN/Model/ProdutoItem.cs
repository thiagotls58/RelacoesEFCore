using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoNxN.Model
{
    class ProdutoItem
    {
        public string ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public string ItemId { get; set; }
        public Item Item { get; set; }
    }
}
