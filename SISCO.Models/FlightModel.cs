using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;


namespace SISCO.Models
{
    public class FlightModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public int AirlineId { get; set; }
        public string FlightNumber { get; set; }
        public int OriginAirportId { get; set; }
        public int DestAirportId { get; set; }
        public short WeekDay { get; set; }
        public string EstDepartureTime { get; set; }
        public string EstArrivalTime { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
    }
}