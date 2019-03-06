using Devenlab.Common;
using DevExpress.XtraReports.UI;
using SISCO.Administration.Operation.Reports;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Administration.Forms
{
    public partial class PODPrintForm : BaseForm
    {
        public PODPrintForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            rbRange.Click += (ars, ev) => RangePod();
            rbList.Click += (ars, ev) => ListPod();

            tbxPod.KeyDown += (s, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            tbxPod.Focus();
                            AddList();
                        }
                        break;
                }
            };

            lbPod.SelectedIndexChanged += SelectedListPod;
            btnRemove.Click += RemovePod;

            tbxFrom.Leave += FromLeave;
            tbxTo.Leave += ToLeave;

            btnPrint.Click += Print;
            btnPreview.Click += Preview;
            btnPreview.Enabled = false;
        }

        private void ToLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxTo.Text))
            {
                Int64 n;
                bool isNumeric = Int64.TryParse(tbxTo.Text, out n);
                if (!isNumeric)
                {
                    tbxTo.Clear();
                    tbxTo.Focus();
                }
            }
        }

        private void FromLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxFrom.Text))
            {
                Int64 n;
                bool isNumeric = Int64.TryParse(tbxFrom.Text, out n);
                if(!isNumeric)
                {
                    tbxFrom.Clear();
                    tbxFrom.Focus();
                }
            }
        }

        private void RangePod()
        {
            gbList.Enabled = false;
            gbRange.Enabled = true;
            rbRange.Checked = true;
            tbxFrom.Focus();
        }

        private void ListPod()
        {
            gbList.Enabled = true;
            gbRange.Enabled = false;
            rbList.Checked = true;
            tbxPod.Focus();
        }

        private void AddList()
        {
            if (!string.IsNullOrEmpty(tbxPod.Text))
            {
                lbPod.Items.Add(tbxPod.Text);
                tbxPod.Clear();
            }
        }

        private void SelectedListPod(object sender, EventArgs e)
        {
            if (lbPod.SelectedIndex != -1) btnRemove.Enabled = true;
            else btnRemove.Enabled = false;
        }

        private void RemovePod(object sender, EventArgs e)
        {
            lbPod.Items.RemoveAt(lbPod.SelectedIndex);
        }

        private void Print(object sender, EventArgs e)
        {
            var prints = PrintData();

            if (prints.Count() > 0)
            {
                var a = new EConnotePrintout();
                a.DataSource = prints;
                a.CreateDocument();
                a.Print();

                foreach (var s in prints)
                {
                    new ShipmentExpandDataManager().Printing(s.Id1);
                    new ShipmentExpandDataManager().Printing(s.Id2);
                    new ShipmentExpandDataManager().Printing(s.Id3);
                }
            }
        }

        private void Preview(object sender, EventArgs e)
        {
            var prints = PrintData();

            if (prints.Count() > 0)
            {
                var a = new EConnotePrintout();
                a.DataSource = prints;
                a.CreateDocument();

                var printTool = new ReportPrintTool(a);
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
                };
                printTool.ShowPreviewDialog();
            }
        }

        private List<PrintPodModel> PrintData()
        {
            var pod = new List<string>();
            if (rbRange.Checked)
            {
                if (string.IsNullOrEmpty(tbxFrom.Text))
                {
                    tbxFrom.Focus();
                    return null;
                }

                if (string.IsNullOrEmpty(tbxTo.Text))
                {
                    tbxTo.Focus();
                    return null;
                }

                for (var p = Convert.ToInt64(tbxFrom.Text); p <= Convert.ToInt64(tbxTo.Text); p++)
                {
                    pod.Add(p.ToString());
                }
            }

            if (rbList.Checked)
            {
                foreach (var l in lbPod.Items)
                {
                    pod.Add(l.ToString());
                }
            }

            var prints = new List<PrintPodModel>();
            if (pod.Count() > 0)
            {
                for (var p = 0; p < pod.Count(); p++)
                {
                    var shipment = new ShipmentDataManager().GetShipmentDetail(pod[p]);
                    var print = new PrintPodModel();
                    if (shipment != null)
                    {
                        print.Id1 = shipment.Id;
                        print.ShipmentHeader1 = shipment.ShipmentHeader;
                        print.Code1 = shipment.Code;
                        print.CityName1 = shipment.CityName;
                        print.DestCity1 = shipment.DestCity;
                        print.TtlPiece1 = shipment.TtlPiece;
                        print.TtlChargeable1 = shipment.TtlChargeableWeight;
                        print.CustomerCode1 = shipment.CustomerCode;
                        print.RefNumber1 = shipment.RefNumber;
                        print.ShipperName1 = shipment.ShipperName;
                        print.ShipperAddress1 = shipment.ShipperAddress;
                        print.ShipperPhone1 = shipment.ShipperPhone;
                        print.NatureOfGoods1 = shipment.NatureOfGoods;
                        print.Note1 = shipment.Note;
                        print.ConsigneeName1 = shipment.ConsigneeName;
                        print.ConsigneeAddress1 = shipment.ConsigneeAddress;
                        print.ConsigneePhone1 = shipment.ConsigneePhone;
                        print.ServiceType1 = shipment.ServiceType;
                        print.PackageType1 = shipment.PackageType;
                        print.PaymentMethod1 = shipment.PaymentMethod;
                        print.MessengerName1 = shipment.MessengerName;
                        print.DateProcess1 = shipment.DateProcess;
                        print.TariffTotal1 = shipment.TariffTotal;
                        print.PackingFee1 = shipment.PackingFee;
                        print.DiscountTotal1 = shipment.DiscountTotal;
                        print.OtherFee1 = shipment.OtherFee;
                        print.InsuranceFee1 = shipment.InsuranceFee;
                        print.Total1 = shipment.Total;
                        print.TotalCod1 = shipment.TotalCod;
                        print.Printed1 = shipment.Printed;
                        print.VolumeL1 = shipment.VolumeL;
                        print.VolumeH1 = shipment.VolumeH;
                        print.VolumeW1 = shipment.VolumeW;
                        print.Fulfilment1 = shipment.Fulfilment;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("POD {0} tidak ditemukan.", pod[p]));
                        return null;
                    }

                    if (pod.Count() > p + 1)
                    {
                        shipment = new ShipmentDataManager().GetShipmentDetail(pod[p + 1]);

                        if (shipment != null)
                        {
                            print.Id2 = shipment.Id;
                            print.ShipmentHeader2 = shipment.ShipmentHeader;
                            print.Code2 = shipment.Code;
                            print.CityName2 = shipment.CityName;
                            print.DestCity2 = shipment.DestCity;
                            print.TtlPiece2 = shipment.TtlPiece;
                            print.TtlChargeable2 = shipment.TtlChargeableWeight;
                            print.CustomerCode2 = shipment.CustomerCode;
                            print.RefNumber2 = shipment.RefNumber;
                            print.ShipperName2 = shipment.ShipperName;
                            print.ShipperAddress2 = shipment.ShipperAddress;
                            print.ShipperPhone2 = shipment.ShipperPhone;
                            print.NatureOfGoods2 = shipment.NatureOfGoods;
                            print.Note2 = shipment.Note;
                            print.ConsigneeName2 = shipment.ConsigneeName;
                            print.ConsigneeAddress2 = shipment.ConsigneeAddress;
                            print.ConsigneePhone2 = shipment.ConsigneePhone;
                            print.ServiceType2 = shipment.ServiceType;
                            print.PackageType2 = shipment.PackageType;
                            print.PaymentMethod2 = shipment.PaymentMethod;
                            print.MessengerName2 = shipment.MessengerName;
                            print.DateProcess2 = shipment.DateProcess;
                            print.TariffTotal2 = shipment.TariffTotal;
                            print.PackingFee2 = shipment.PackingFee;
                            print.DiscountTotal2 = shipment.DiscountTotal;
                            print.OtherFee2 = shipment.OtherFee;
                            print.InsuranceFee2 = shipment.InsuranceFee;
                            print.Total2 = shipment.Total;
                            print.TotalCod2 = shipment.TotalCod;
                            print.Printed2 = shipment.Printed;
                            print.VolumeL2 = shipment.VolumeL;
                            print.VolumeH2 = shipment.VolumeH;
                            print.VolumeW2 = shipment.VolumeW;
                            print.Fulfilment2 = shipment.Fulfilment;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("POD {0} tidak ditemukan.", pod[p + 1]));
                            return null;
                        }

                        p = p + 1;
                    }

                    if (pod.Count() > p + 1)
                    {
                        shipment = new ShipmentDataManager().GetShipmentDetail(pod[p + 1]);

                        if (shipment != null)
                        {
                            print.Id3 = shipment.Id;
                            print.ShipmentHeader3 = shipment.ShipmentHeader;
                            print.Code3 = shipment.Code;
                            print.CityName3 = shipment.CityName;
                            print.DestCity3 = shipment.DestCity;
                            print.TtlPiece3 = shipment.TtlPiece;
                            print.TtlChargeable3 = shipment.TtlChargeableWeight;
                            print.CustomerCode3 = shipment.CustomerCode;
                            print.RefNumber3 = shipment.RefNumber;
                            print.ShipperName3 = shipment.ShipperName;
                            print.ShipperAddress3 = shipment.ShipperAddress;
                            print.ShipperPhone3 = shipment.ShipperPhone;
                            print.NatureOfGoods3 = shipment.NatureOfGoods;
                            print.Note3 = shipment.Note;
                            print.ConsigneeName3 = shipment.ConsigneeName;
                            print.ConsigneeAddress3 = shipment.ConsigneeAddress;
                            print.ConsigneePhone3 = shipment.ConsigneePhone;
                            print.ServiceType3 = shipment.ServiceType;
                            print.PackageType3 = shipment.PackageType;
                            print.PaymentMethod3 = shipment.PaymentMethod;
                            print.MessengerName3 = shipment.MessengerName;
                            print.DateProcess3 = shipment.DateProcess;
                            print.TariffTotal3 = shipment.TariffTotal;
                            print.PackingFee3 = shipment.PackingFee;
                            print.DiscountTotal3 = shipment.DiscountTotal;
                            print.OtherFee3 = shipment.OtherFee;
                            print.InsuranceFee3 = shipment.InsuranceFee;
                            print.Total3 = shipment.Total;
                            print.TotalCod3 = shipment.TotalCod;
                            print.Printed3 = shipment.Printed;
                            print.VolumeL3 = shipment.VolumeL;
                            print.VolumeH3 = shipment.VolumeH;
                            print.VolumeW3 = shipment.VolumeW;
                            print.Fulfilment3 = shipment.Fulfilment;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("POD {0} tidak ditemukan.", pod[p + 1]));
                            return null;
                        }

                        p = p + 1;
                    }

                    prints.Add(print);
                }
            }

            return prints;
        }
    }

    public class PrintPodModel
    {
        public int Id1 { get;set; }
        public int Id2 { get; set; }
        public int Id3 { get; set; }
        public string ShipmentHeader1 { get; set; }
        public string ShipmentHeader2 { get; set; }
        public string ShipmentHeader3 { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string CityName1 { get; set; }
        public string CityName2 { get; set; }
        public string CityName3 { get; set; }
        public string DestCity1 { get; set; }
        public string DestCity2 { get; set; }
        public string DestCity3 { get; set; }
        public decimal TtlPiece1 { get; set; }
        public decimal TtlPiece2 { get; set; }
        public decimal TtlPiece3 { get; set; }
        public decimal TtlChargeable1 { get; set; }
        public decimal TtlChargeable2 { get; set; }
        public decimal TtlChargeable3 { get; set; }
        public string CustomerCode1 { get; set; }
        public string CustomerCode2 { get; set; }
        public string CustomerCode3 { get; set; }
        public string RefNumber1 { get; set; }
        public string RefNumber2 { get; set; }
        public string RefNumber3 { get; set; }
        public string ShipperName1 { get; set; }
        public string ShipperName2 { get; set; }
        public string ShipperName3 { get; set; }
        public string ShipperAddress1 { get; set; }
        public string ShipperAddress2 { get; set; }
        public string ShipperAddress3 { get; set; }
        public string ShipperPhone1 { get; set; }
        public string ShipperPhone2 { get; set; }
        public string ShipperPhone3 { get; set; }
        public string NatureOfGoods1 { get; set; }
        public string NatureOfGoods2 { get; set; }
        public string NatureOfGoods3 { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string ConsigneeName1 { get; set; }
        public string ConsigneeName2 { get; set; }
        public string ConsigneeName3 { get; set; }
        public string ConsigneeAddress1 { get; set; }
        public string ConsigneeAddress2 { get; set; }
        public string ConsigneeAddress3 { get; set; }
        public string ConsigneePhone1 { get; set; }
        public string ConsigneePhone2 { get; set; }
        public string ConsigneePhone3 { get; set; }
        public string ServiceType1 { get; set; }
        public string ServiceType2 { get; set; }
        public string ServiceType3 { get; set; }
        public string PackageType1 { get; set; }
        public string PackageType2 { get; set; }
        public string PackageType3 { get; set; }
        public string PaymentMethod1 { get; set; }
        public string PaymentMethod2 { get; set; }
        public string PaymentMethod3 { get; set; }
        public string MessengerName1 { get; set; }
        public string MessengerName2 { get; set; }
        public string MessengerName3 { get; set; }
        public DateTime DateProcess1 { get; set; }
        public DateTime DateProcess2 { get; set; }
        public DateTime DateProcess3 { get; set; }
        public decimal TotalCod1 { get; set; }
        public decimal TotalCod2 { get; set; }
        public decimal TotalCod3 { get; set; }
        public decimal TariffTotal1 { get; set; }
        public decimal TariffTotal2 { get; set; }
        public decimal TariffTotal3 { get; set; }
        public decimal PackingFee1 { get; set; }
        public decimal PackingFee2 { get; set; }
        public decimal PackingFee3 { get; set; }
        public decimal DiscountTotal1 { get; set; }
        public decimal DiscountTotal2 { get; set; }
        public decimal DiscountTotal3 { get; set; }
        public decimal OtherFee1 { get; set; }
        public decimal OtherFee2 { get; set; }
        public decimal OtherFee3 { get; set; }
        public decimal InsuranceFee1 { get; set; }
        public decimal InsuranceFee2 { get; set; }
        public decimal InsuranceFee3 { get; set; }
        public decimal Total1 { get; set; }
        public decimal Total2 { get; set; }
        public decimal Total3 { get; set; }
        public short Printed1 { get; set; }
        public short Printed2 { get; set; }
        public short Printed3 { get; set; }
        public decimal VolumeL1 { get; set; }
        public decimal VolumeL2 { get; set; }
        public decimal VolumeL3 { get; set; }
        public decimal VolumeW1 { get; set; }
        public decimal VolumeW2 { get; set; }
        public decimal VolumeW3 { get; set; }
        public decimal VolumeH1 { get; set; }
        public decimal VolumeH2 { get; set; }
        public decimal VolumeH3 { get; set; }
        public string Fulfilment1 { get; set; }
        public string Fulfilment2 { get; set; }
        public string Fulfilment3 { get; set; }
    }
}