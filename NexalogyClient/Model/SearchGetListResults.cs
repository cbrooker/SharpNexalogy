﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{
    public class SearchGetListResults
    {
        public List<Search> searches { get; set; }
        public bool success { get; set; }
    }
}
