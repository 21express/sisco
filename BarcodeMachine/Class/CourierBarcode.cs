using System;
namespace BarcodeMachine.Class
{
    public class CourierBarcode
    {
        public DateTime PickupDate { get; set; }
        public string MessengerCode { get; set; }
        public string MessengerName { get; set; }
        public int TotalPcs { get; set; }
    }
}
