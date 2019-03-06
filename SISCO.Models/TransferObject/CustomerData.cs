using System;

namespace SISCO.Models.TransferObject
{
    public class CustomerData
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public Int32 BranchId { get; set; }
        public string Disabled { get; set; }

        public CustomerData()
        {
            Rowstatus = true;
        }
    }
}