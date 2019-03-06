using System;

namespace SISCO.Presentation.Corporate.DataTransferObject
{
    public class ShipmentDTO
    {
        public string awb { get; set; }
        public string remark { get; set; }
        public ConsigneeDTO consignee { get; set; }
        public OrderDTO order { get; set; }
        public ShipperDTO shipper { get; set; }
    }
}
