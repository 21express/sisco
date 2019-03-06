using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class PodHandoverModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public int BranchId { get; set; }
        public short ObjectId { get; set; }
        public string Description { get; set; }
        public bool Printed { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public class PodHandoverRowDetail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateProcess { get; set; }
        public string CityName { get; set; }
        public string DestCityName { get; set; }
        public string CustomerName { get; set; }
        public string ShipperName { get; set; }
        public string ShipperAddress { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public decimal TtlPiece { get; set; }
        public decimal TtlGrossWeight { get; set; }
        public decimal TtlChargeableWeight { get; set; }
        public bool Cek { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public class SearchHandover : IBaseModel
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }

        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}