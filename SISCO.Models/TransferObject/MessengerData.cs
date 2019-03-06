using System;

namespace SISCO.Models.TransferObject
{
    public class MessengerData
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public bool AsMessenger { get; set; }
        public Int32 BranchId { get; set; }

        public MessengerData()
        {
            Rowstatus = true;
        }
    }
}