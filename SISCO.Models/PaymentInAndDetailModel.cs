using System;

namespace SISCO.Models
{
    public class PaymentInAndDetailModel
    {
        public DateTime DateProcess { get; set; }
        public String Code { get; set; }
        public String CustomerName { get; set; }
        public String PaymentType { get; set; }
        public String Kwitansi { get; set; }
    }
}
