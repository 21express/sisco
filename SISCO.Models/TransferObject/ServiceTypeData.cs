using System;

namespace SISCO.Models.TransferObject
{
    public class ServiceTypeData
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public String Name { get; set; }

        public ServiceTypeData()
        {
            Rowstatus = true;
        }
    }
}