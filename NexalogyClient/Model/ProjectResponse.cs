using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{
  
    public class ProjectsResponse
    {
        public List<Project> projects { get; set; }
        public bool sortDescending { get; set; }
        public string sort { get; set; }
        public bool success { get; set; }
    }
}
