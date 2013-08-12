using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{

    public class AutoCapture
    {
        public bool ongoing { get; set; }
    }

    public class AutoCaptureStatusResults
    {
        public AutoCapture autoCapture { get; set; }
        public bool success { get; set; }
    }

}
