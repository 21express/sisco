﻿using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class ManifestVendorDetailModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public Int32 ManifestVendorId { get; set; }
        public Int32? ShipmentId { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public String ShipmentCode { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 DestCityId { get; set; }
        public String DestCity { get; set; }
        public String ShipperName { get; set; }
        public String ConsigneeName { get; set; }
        public Int32? ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public Int32? PackageTypeId { get; set; }
        public string PackageType { get; set; }
        public Int32? PaymentMethodId { get; set; }
        public string PaymentMethod { get; set; }
        public Int32? SalesTypeId { get; set; }
        public short TtlPiece { get; set; }
        public Decimal TtlGrossWeight { get; set; }
        public Decimal TtlChargeableWeight { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
    }
}