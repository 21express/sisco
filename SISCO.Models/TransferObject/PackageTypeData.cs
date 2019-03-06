using System;

namespace SISCO.Models.TransferObject
{
    public class PackageTypeData
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public String Name { get; set; }

        public PackageTypeData()
        {
            Rowstatus = true;
        }
    }
}