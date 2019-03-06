using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpBarcodePrinting
{
    [Serializable]
    public class ReportModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebSites { get; set; }
        public int NumberOfEmployee { get; set; }
    }
}
