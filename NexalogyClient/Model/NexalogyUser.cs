using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{
    public class NexalogyUser
    {
        public int id { get; set; }
        public string email { get; set; }
        public string api_key { get; set; }
        public int nb_task_at_once { get; set; }
    }
}
