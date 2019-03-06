using System;

namespace SISCO.Presentation.Corporate.DataTransferObject
{
    public class OrderDTO
    {
        public string orderid { get; set; }
        public decimal actweight { get; set; }
        public string pieces { get; set; }
        public ItemDTO items { get; set; }
        public decimal goodsval { get; set; }
        public string insurance { get; set; }
        public string cod { get; set; }
        public DateTime pickupdate { get; set; }
        public string service { get; set; }
    }
}
