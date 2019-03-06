using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Popup;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class InsuranceForm : BaseCrudForm<ShipmentInsuranceModel, ShipmentInsuranceDataManager>//BaseToolbarForm//
    {
        private ShipmentModel _shipment { get; set; }
        public InsuranceForm()
        {
            InitializeComponent();
            form = this;

            GridInsurance.DoubleClick += (sender, args) => OpenRelatedForm(InsuranceView, new TrackingViewForm());
            InsuranceView.CustomColumnDisplayText += NumberGrid;
            Load += InsuranceLoad;
            btnExcel.Click += (o, args) =>
            {
                ExportGridToExcel(InsuranceView, "Insurance", true, "xlsx", DevExpress.XtraPrinting.TextExportMode.Value);
            };
        }

        private decimal _fixedCashRate { get; set; }

        private void InsuranceLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new InsurancePopup();

            tbxResi.Leave += CheckCn;
            btnProcess.Click += AddInsurance;
            cbxCash.CheckedChanged += (o, args) =>
            {
                tbxResi.Focus();
            };

            var lookup = new LookupDataManager().Get("FixCashInsurance");
            _fixedCashRate = Convert.ToDecimal(lookup.Value);
        }

        private void AddInsurance(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxInterest.Text))
            {
                tbxInterest.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxConveyance.Text))
            {
                tbxConveyance.Focus();
                return;
            }

            if (tbxTsi.Value == 0)
            {
                tbxTsi.Focus();
                return;
            }

            var newData = new InsuranceDetail
            {
                ShipmentId = _shipment.Id,
                Posted = _shipment.Posted,
                CustomerName = tbxInsured.Text,
                DateProcess = _shipment.DateProcess,
                CityName = _shipment.CityName,
                DestCity = _shipment.DestCity,
                NatureOfGoods = tbxInterest.Text,
                Conveyance = tbxConveyance.Text,
                Code = _shipment.Code,
                GoodsValue = tbxTsi.Value,
                Rate = cbxCash.Checked ? _fixedCashRate : 0,
                InsuranceFee = _shipment.InsuranceFee,
                StateChange = EnumStateChange.Insert.ToString()
            };

            var data = GridInsurance.DataSource as List<InsuranceDetail>;
            if (data == null) data = new List<InsuranceDetail>();
            data.Add(newData);

            GridInsurance.DataSource = data;
            InsuranceView.RefreshData();

            cbxCash.Enabled = false;

            tbxResi.Clear();
            tbxInsured.Clear();
            tbxEtd.Clear();
            tbxDeparture.Clear();
            tbxDestination.Clear();
            tbxConveyance.Clear();
            tbxInterest.Clear();
            tbxTsi.Value = 0;

            tbxResi.Focus();

            _shipment = null;

        }

        private void CheckCn(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxResi.Text))
            {
                var data = GridInsurance.DataSource as List<InsuranceDetail>;
                if (data == null) data = new List<InsuranceDetail>();
                if (data.Count > 0)
                {
                    if (data.Where(p => p.Code == tbxResi.Text).ToList().Count > 0)
                    {
                        tbxResi.Clear();
                        tbxResi.Focus();
                        return;
                    }
                }

                _shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxResi.Text, "code"));
                if (_shipment != null)
                {
                    var exists = new ShipmentInsuranceDetailDataManager().GetFirst<ShipmentInsuranceDetailModel>(WhereTerm.Default(_shipment.Id, "shipment_id"));
                    if (exists != null)
                    {
                        MessageBox.Show("Nomor resi sudah diasuransikan.");
                        tbxResi.Clear();
                        tbxResi.Focus();
                        return;
                    }

                    if (_shipment.Invoiced == 1)
                    {
                        MessageBox.Show("Nomor resi sudah dibuatkan invoice. Silakan hubungi Billing.");
                        tbxResi.Focus();
                        return;
                    }

                    if (_shipment.PaymentMethodId != 1 && cbxCash.Checked)
                    {
                        MessageBox.Show("Nomor resi bukan dengan pembayaran Cash.");
                        cbxCash.Focus();
                        return;
                    }

                    tbxEtd.Text = _shipment.DateProcess.ToString("dd-MM-yyyy");
                    tbxDeparture.Text = _shipment.CityName;
                    tbxDestination.Text = _shipment.DestCity;
                    tbxInterest.Text = _shipment.NatureOfGoods;

                    if (cbxCash.Checked)
                    {
                        tbxTsi.Value = _shipment.GoodsValue;
                        tbxTsi.ReadOnly  = true;

                        tbxInsured.Text = _shipment.ShipperName;
                    }
                    else 
                    {
                        tbxTsi.ReadOnly = false;
                        tbxInsured.Text = _shipment.CustomerName;
                    }

                    tbxInsured.Focus();
                }
                else
                {
                    MessageBox.Show("Nomor resi tidak dikenali.");
                    tbxResi.Clear();
                    tbxResi.Focus();
                }
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridInsurance.DataSource = null;
            InsuranceView.RefreshData();

            tbxEtd.ReadOnly = true;
            cbxCash.Enabled = true;
            tbxEtd.ReadOnly = true;
            tbxDeparture.ReadOnly = true;
            tbxDestination.ReadOnly = true;
            _shipment = null;
            btnExcel.Enabled = false;

            cbxCash.Focus();
        }

        protected override bool ValidateForm()
        {
            var data = GridInsurance.DataSource as List<InsuranceDetail>;
            if (data.Count == 0)
            {
                tbxResi.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ShipmentInsuranceModel model)
        {
            ClearForm();

            if (model == null) return;

            ToolbarCode = model.Code;
            tbxDate.DateTime = model.DateProcess;

            cbxCash.Checked = model.IsCash;

            GridInsurance.DataSource = new ShipmentInsuranceDetailDataManager().GetInsuranceDetail(model.Id);
            InsuranceView.RefreshData();

            btnExcel.Enabled = true;
            cbxCash.Enabled = false;
        }

        protected override ShipmentInsuranceModel PopulateModel(ShipmentInsuranceModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.IsCash = cbxCash.Checked;

            if (model.Id == 0) model.Code = GetCode("insurance", model.DateProcess);

            return model;
        }

        protected override ShipmentInsuranceModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<ShipmentInsuranceModel>(param);
            return obj;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            form.Enabled = false;
            var insuranceDetail = GridInsurance.DataSource as List<InsuranceDetail>;
            new ShipmentInsuranceDetailDataManager().SaveInsurance(insuranceDetail, CurrentModel.Id, BaseControl.UserLogin, Environment.MachineName);
            form.Enabled = true;
        }

        protected override void AfterSave()
       { 
            OpenData(((ShipmentInsuranceModel)CurrentModel).Code);
            tsBaseTxt_Code.Focus();
        }

        public override void Delete()
        {
            var id = CurrentModel.Id;
            base.Delete();

            new ShipmentInsuranceDetailDataManager().DeleteAll(id);
        }
    }
}