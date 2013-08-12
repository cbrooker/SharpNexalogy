using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{

    public class PostData
    {
        public string projectId { get; set; }
        public bool autoLematized { get; set; }
        public bool globalUpdate { get; set; }
    }

    public class LexiconResults
    {
        public Job job { get; set; }
        public PostData postData { get; set; }
        public bool success { get; set; }
    }
    
}
