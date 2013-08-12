using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{
    public class Job
    {
        public string result { get; set; }
        public int time_it_took { get; set; }
        public string error_code { get; set; }
        public string error_detail { get; set; }
        public int type { get; set; }
        public int id { get; set; }
        public string command_url { get; set; }
        public string post_vars { get; set; }
        public string requested_at { get; set; }
        public int estimated_time { get; set; }
        public string error_link { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        public string error_message { get; set; }
        public string callback_url { get; set; }
        public int percent_completed { get; set; }
        public NexalogyUser nexalogy_user { get; set; }
    }
}
