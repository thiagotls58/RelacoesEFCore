using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoNxN.Model
{
    class Item
    {
        public string ItemId { get; set; }
        public int Quantidade { get; set; }
        public ICollection<ProdutoItem> ProdutoItem { get; set; }
    }
}
