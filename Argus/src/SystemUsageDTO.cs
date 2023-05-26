using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.src
{
    //  DB에 들어갈 Data format
    internal class SystemUsageDTO
    {
        public double CPU { get; set; }
        public double Memory { get; set; }
        public double Disk { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
