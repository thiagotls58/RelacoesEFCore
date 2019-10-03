using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoNxN.Model
{
    public class Tag
    {
        public string TagId { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
