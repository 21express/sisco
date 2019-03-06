using System;
using System.Text;
using SISCO.Models;

namespace SISCO.Presentation.Common.Reports
{
    public class ConsignmentNote : DotMatrixRawPrintOut<ShipmentModel.ShipmentReportRow>
    {
        protected override string GetLayoutFile()
        {
            return "PODPrint.txt";
        }

        protected override void ProcessPrint()
        {
            var i = 0;
            foreach (var model in DataSource)
            {
                var custAddress = model.ShipperAddress ?? "";
                var custAddress1 = TruncateString(custAddress, 30);
                var custAddress2 = (custAddress.Length > 30) ? TruncateString(custAddress.Substring(30), 30) : "";
                var custAddress3 = (custAddress.Length > 60) ? TruncateString(custAddress.Substring(60), 30) : "";

                var consigneeAddress = model.ConsigneeAddress ?? "";
                var consAddress1 = TruncateString(consigneeAddress, 28);
                var consAddress2 = (consigneeAddress.Length > 28) ? TruncateString(consigneeAddress.Substring(28), 28) : "";
                var consAddress3 = (consigneeAddress.Length > 56) ? TruncateString(consigneeAddress.Substring(56), 28) : "";

                Write(27, 106, 24); // reverse
                Write(27, 67, 22); // Select page length in lines (n=1..127)
                Write(27, 69); // bold
                Write(Layout,
                    TruncateString(model.CityName ?? "", 12), TruncateString(model.DestCity ?? "", 12),
                    model.Code != null ? model.TtlPiece.ToString() : "", model.Code != null ? model.TtlChargeableWeight.ToString() : "",
                    TruncateString(model.CustomerCode ?? "", 15), TruncateString(model.RefNumber ?? "", 15), TruncateString(model.ConsigneeName ?? "", 28),
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
                    TruncateString(model.PaymentMethod ?? "", 10),
                    ((model.PaymentMethod == "CASH" || model.PaymentMethod == "COLLECT") && model.Code != null ? model.Total.ToString("#,#0") : ""),
                    TruncateString(model.NatureOfGoods ?? "", 29), TruncateString(model.MessengerCode ?? "", 17),
                    TruncateString(model.Note ?? "", 29), model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("dd") : "", model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("MM") : "", model.DateProcess != null && model.DateProcess != DateTime.MinValue ? model.DateProcess.ToString("yyyy") : ""
                );

                i++;

                if (i > 0 && i%3 == 0)
                {
                    Write(12);
                }
                else
                {
                    Write(10);
                    Write(10);
                    Write(10);
                    Write(10);
                    Write(10);
                    Write(10);
                }

                Write(27, 64);
            }
        }
    }
}