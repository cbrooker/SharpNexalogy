using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{
    public class ReportsGenerateResults
    {
        public Job job { get; set; }
        public ReportsPostData postData { get; set; }
        public bool success { get; set; }
    }
}
