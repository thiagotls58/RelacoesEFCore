using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoNxN.Model
{
    class Produto
    {
        public string ProdutoId { get; set; }
        public string Descricao { get; set; }

        public ICollection<ProdutoItem> ProdutoItem { get; set; }
    }
}
