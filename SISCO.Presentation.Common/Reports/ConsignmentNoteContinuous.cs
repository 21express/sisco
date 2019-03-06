using System;
using System.Text;
using SISCO.Models;

namespace SISCO.Presentation.Common.Reports
{
    public class ConsignmentNoteContinuous : DotMatrixRawPrintOut<ShipmentModel.ShipmentReportRow>
    {
        protected override string GetLayoutFile()
        {
            if (string.IsNullOrEmpty(BaseControl.PrinterRangkapSetting.DotMatrix))
                return "PODPrintContinuous.txt";
            else
                return "POD4PrintContinuous.txt";
        }

        protected override void ProcessPrint()
        {
            if (string.IsNullOrEmpty(BaseControl.PrinterRangkapSetting.DotMatrix))
                PrintPOD();
            else
                PrintPODRangkap4();
        }

        private void PrintPOD()
        {
            foreach (var model in DataSource)
            {
                var custAddress = model.ShipperAddress ?? "";
                var custAddress1 = TruncateString(custAddress, 30);
                var custAddress2 = (custAddress.Length > 30) ? TruncateString(custAddress.Substring(30), 30) : "";
                var custAddress3 = (custAddress.Length > 60) ? TruncateString(custAddress.Substring(60), 30) : "";

                var consigneeAddress = model.ConsigneeAddress ?? "";
                var consAddress1 = TruncateString(consigneeAddress, 30);
                var consAddress2 = (consigneeAddress.Length > 30) ? TruncateString(consigneeAddress.Substring(30), 30) : "";
                var consAddress3 = (consigneeAddress.Length > 60) ? TruncateString(consigneeAddress.Substring(60), 30) : "";

                Write(27, 67, 22); // Select page length in lines (n=1..127)
                Write(27, 69); // bold
                Write(27, 106, 36); // reverse
                Write(Layout,
                    TruncateString(model.CityName ?? "", 12), TruncateString(model.DestCity ?? "", 12),
                    model.Code != null ? model.TtlPiece.ToString() : "", model.Code != null ? model.TtlChargeableWeight.ToString() : "",
                    TruncateString(model.CustomerCode ?? "", 15), TruncateString(model.RefNumber ?? "", 15), TruncateString(model.ConsigneeName ?? "", 30),
                    (model.PackageType == "DOCUMENT" ? "X" : ""), TruncateString(model.PackageType ?? "", 8),
                    TruncateString(model.ShipperName ?? "", 30), consAddress1,
                    consAddress2, (model.PackageType == "PARCEL" ? "X" : ""), TruncateString(model.ServiceType ?? "", 8),
                    custAddress1, consAddress3,
                    custAddress2, "", "",
                    custAddress3, "",
                    "", "",
                    TruncateString(model.ShipperPhone ?? "", 21), TruncateString(model.ConsigneePhone ?? "", 23),
                    (model.Code != null && model.PackingFee > 0 ? "PACKING" : ""),
                    (model.Code != null && model.PackingFee > 0 ? model.PackingFee.ToString("#,#0") : ""),
                    TruncateString(model.Note ?? "", 17),
                    TruncateString(model.PaymentMethod ?? "", 10),
                    ((model.PaymentMethod == "CASH" || model.PaymentMethod == "COLLECT") && model.Code != null ? model.Total.ToString("#,#0") : ""),
                    TruncateString(model.NatureOfGoods ?? "", 29), TruncateString(model.MessengerCode ?? "", 17), TruncateString(model.IsCod ? string.Format("[COD = Rp {0}]", model.TotalCod.ToString("#,#0")) : "", 23),
                    TruncateString(model.VolumeL.ToString("#"), 3),
                    TruncateString(model.VolumeW.ToString("#"), 3),
                    TruncateString(model.VolumeH.ToString("#"), 3),
                    model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("dd") : "",
                    model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("MM") : "",
                    model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("yyyy") : "",
                    TruncateString(model.Fulfilment, 15)
                );

                Write(10);
                Write(10);
                Write(10);
                Write(10);
                Write(10);
                Write(27, 64);
            }
        }

        private void PrintPODRangkap4()
        {
            foreach (var model in DataSource)
            {
                var custAddress = model.ShipperAddress ?? "";
                var custAddress1 = TruncateString(custAddress, 20);
                var custAddress2 = (custAddress.Length > 20) ? TruncateString(custAddress.Substring(20), 27) : "";
                var custAddress3 = (custAddress.Length > 47) ? TruncateString(custAddress.Substring(47), 27) : "";
                var custAddress4 = (custAddress.Length > 74) ? TruncateString(custAddress.Substring(74), 27) : "";
                var custAddress5 = (custAddress.Length > 101) ? TruncateString(custAddress.Substring(101), 27) : "";

                var consigneeAddress = model.ConsigneeAddress ?? "";
                var consAddress1 = TruncateString(consigneeAddress, 30);
                var consAddress2 = (consigneeAddress.Length > 30) ? TruncateString(consigneeAddress.Substring(30), 33) : "";
                var consAddress3 = (consigneeAddress.Length > 63) ? TruncateString(consigneeAddress.Substring(63), 33) : "";
                var consAddress4 = (consigneeAddress.Length > 96) ? TruncateString(consigneeAddress.Substring(96), 33) : "";

                Write(27, 67, 22); // Select page length in lines (n=1..127)
                Write(27, 69); // bold
                Write(27, 106, 36); // reverse
                Write(Layout,
                    TruncateString(model.CityName ?? "", 10),
                    TruncateString(model.DestCity ?? "", 10),
                    TruncateString(model.CustomerCode ?? "", 10),
                    TruncateString(model.RefNumber ?? "", 15),
                    TruncateString(model.ShipperName ?? "", 25),
                    model.Code != null ? model.TtlPiece.ToString() : "", 
                    model.Code != null ? model.TtlChargeableWeight.ToString() : "",
                    custAddress1, 
                    TruncateString(model.ConsigneeName ?? "", 33),
                    TruncateString(model.ServiceType ?? "", 8),
                    custAddress2,
                    consAddress1, 
                    (model.PackageType == "DOCUMENT" ? "X" : ""),
                    (model.PackageType == "PARCEL" ? "X" : ""),
                    custAddress3,
                    consAddress2,
                    custAddress4,
                    consAddress3,
                    TruncateString(model.NatureOfGoods ?? "", 10),
                    custAddress5,
                    consAddress4,
                    TruncateString(model.ShipperPhone ?? "", 21),
                    TruncateString(model.ConsigneePhone ?? "", 23),
                    (model.Code != null && model.PackingFee > 0 ? model.PackingFee.ToString("#,#0") : ""),
                    TruncateString(model.VolumeL.ToString("#"), 3),
                    TruncateString(model.VolumeW.ToString("#"), 3),
                    TruncateString(model.VolumeH.ToString("#"), 3),
                    model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("dd") : "",
                    model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("MM") : "",
                    model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("yyyy") : "",
                    TruncateString(model.MessengerCode ?? "", 17),
                    TruncateString(model.IsCod ? string.Format("[COD = Rp {0}]", model.TotalCod.ToString("#,#0")) : "", 23),
                    TruncateString(model.Fulfilment, 15),
                    TruncateString(model.Note ?? "", 23),
                    (model.PaymentMethodId == 1) ? "Rp" + model.Total.ToString("#,#0") : null
                );

                Write(10);
                Write(10);
                Write(10);
                Write(10);
                Write(27, 64);
            }
        }
    }
}