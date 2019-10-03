using System;
using System.Collections.Generic;
using System.Text;

namespace Relacao1x1.Model
{
    public class BlogImage
    {
        public int BlogImageId { get; set; }
        public string Image { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
