using System;

namespace SISCO.Presentation.Corporate.DataTransferObject
{
    public class ShipperDTO
    {
        public string merchant { get; set; }
        public string merchant_address { get; set; }
        public string merchant_district { get; set; }
        public string merchant_city { get; set; }
        public string merchant_province { get; set; }
        public string merchant_country { get; set; }
        public string merchant_phone { get; set; }
        public string merchant_contact { get; set; }
    }
}
