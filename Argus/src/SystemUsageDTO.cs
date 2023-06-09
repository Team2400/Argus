using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.src
{
    //  DB에 들어갈 Data format
    public class SystemUsageDTO
    {
        public double CPU { get; set; }
        public double Memory { get; set; }
        public double Disk { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ChartDTO 
    {
        public List<double> cList { get; set; }
        public List<double> mList { get; set; }
        public List<double> dList { get; set; }
    }
}
