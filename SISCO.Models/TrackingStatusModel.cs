using System;
using System.ComponentModel;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class TrackingStatusModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public String Code { get; set; }
        public bool IsFinalStatus { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public enum EnumTrackingStatus
    {
        Pickup = 1,
        Acceptance = 2,
        Manifested = 3,
        Waybilled = 4,
        Onboard = 5,
        Arrival = 6,
        Incoming = 7,
        Delivery = 8,
        MissDelivery = 9,
        Received = 10,
        Loss = 11,
        Returned = 12,
        OutManifest = 13,
        OutArea = 14,
        MissRoute = 15,
        FranchiseDataEntry = 17,
        CorporateDataEntry = 18,
        Claimed = 19,
        Gudang = 20,
        WebServiceDataEntry = 21,
        AgentPickup = 23,
        Vendor = 24,
        PodChecker = 25,
        Consolidation = 26,
        WaybilledRevised = 27
    }

    public enum EnumPositionStatus
    {
        Branch = 1,
        Agent = 2,
        Franchise = 3
    }

    public enum EnumInboundStatus
    {
        CNnotEntered = 1,
        WrongDestination = 2,
        ManifestWrongDestination = 3,
        NotManifest = 4,
        Valid = 5,
        Return = 6
    }

    public enum EnumDepartment
    {
        Accounting = 3,
        AdmInbound = 4,
        AdmOutbound = 5,
        Bandara = 6,
        CityCourier = 7,
        Collector = 8,
        Counter = 9,
        Cs = 10,
        DataEntry = 11,
        Driver = 12,
        DriverAsist = 13,
        Edp = 14,
        Hrd = 15,
        It = 16,
        Koordinator = 17,
        Kurir = 18,
        Manifest = 19,
        Marketing = 20,
        Mekanik = 21,
        Ob = 22,
        OperasionalMalam = 23,
        Smu = 24
    }
}
