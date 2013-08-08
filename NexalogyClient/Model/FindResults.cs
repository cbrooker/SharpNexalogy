using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{

    public class Results
    {
        public List<Project> NexamasterV021Epilogger { get; set; }
    }

    public class FindResults
    {
        public Results results { get; set; }
        public bool success { get; set; }
    }

}
