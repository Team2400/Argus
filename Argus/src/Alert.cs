using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.src
{
    public class Alert
    {
        public string type { get; set; }
        public int threshold { get; set; }
        public string message { get; set; }
        public bool initialized { get; set; } = false;
        public bool triggered { get; set; } = false;
    }
}
