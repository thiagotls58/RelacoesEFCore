﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Relacao1x1.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public BlogImage BlogImage { get; set; }
    }
}
