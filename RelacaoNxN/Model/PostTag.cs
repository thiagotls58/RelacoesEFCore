using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoNxN.Model
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
