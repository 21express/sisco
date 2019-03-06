using System;
using System.Collections.Generic;

namespace SISCO.Models.TransferObject
{
    public class MasterDataTransferObject
    {
        public List<CityData> Cities { get; set; }
        public List<PaymentMethodData> Payments { get; set; }
        public List<PackageTypeData> Packages { get; set; }
        public List<ServiceTypeData> Services { get; set; }
    }
}