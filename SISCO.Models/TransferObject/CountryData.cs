using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models.TransferObject
{
    public class CountryData
    {
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public byte CountryZone { get; set; }
        public Int32? PricingPlanId { get; set; }
        public bool Rowstatus { get; set; }

        public CountryData ()
        {
            Rowstatus = true;
        }
    }
}
