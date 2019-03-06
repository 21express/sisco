using System;

namespace SISCO.Models.TransferObject
{
    public class CityData
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public String Name { get; set; }
        public Int32 CountryId { get; set; }

        public CityData()
        {
            Rowstatus = true;
        }
    }
}