using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SISCO.Presentation.CustomerService.Popup;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class ClaimedForm : BaseCrudForm<ClaimedModel, ClaimedDataManager>//BaseToolbarForm//
    {
        private OpenFileDialog openDialog = new OpenFileDialog();
        private List<int> deleteIds { get; set; }
        public ClaimedForm()
        {
            InitializeComponent();
            form = this;

            Load += ClaimedForm_Load;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id") };
        }

        void ClaimedForm_Load(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new ClaimedPopup();

            lkpClaimBranch.LookupPopup = new BranchPopup();
            lkpClaimBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpClaimBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            lkpClaimBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            lkpCustBranch.LookupPopup = new BranchPopup();
            lkpCustBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpCustBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            lkpCustBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            btnAdd.Click += btnAdd_Click;
            dbUpload.ButtonClick += dbUpload_ButtonClick;
            dbUpload.DoubleClick += dbUpload_DoubleClick;

            ClaimView.CustomColumnDisplayText += NumberGrid;
            btnDelete.Click += btnDelete_Click;
        }

        void dbUpload_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dbUpload.Text))
            if (MessageForm.Ask(form, "Download", "Apa anda ingin mengunduh document claim?") == System.Windows.Forms.DialogResult.Yes)
            {
                string url = string.Format("{0}api/v1/claimed-doc?filename={1}", BaseControl.SiscoBaseAddressApi, ((ClaimedModel)CurrentModel).DocName);
                System.Diagnostics.Process.Start(url);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (ClaimView.GetRowCellValue(ClaimView.FocusedRowHandle, ClaimView.Columns["StateChange2"]).ToString() != EnumStateChange.Insert.ToString())
                deleteIds.Add((int)ClaimView.GetRowCellValue(ClaimView.FocusedRowHandle, ClaimView.Columns["Id"]));

            ClaimView.DeleteSelectedRows();
        }

        void dbUpload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileStream = File.Open(openDialog.FileName, FileMode.Open);
                var fileInfo = new FileInfo(openDialog.FileName);

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("ActorBy", BaseControl.UserLogin);
                client.DefaultRequestHeaders.Add("MachineName", "SISCOAPPMC");
                client.DefaultRequestHeaders.Add("BranchId", BaseControl.BranchId.ToString());
                client.DefaultRequestHeaders.Add("Token", BaseControl.SiscoTokenApi);
                client.BaseAddress = new Uri(BaseControl.SiscoBaseAddressApi);

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
                );

                FileUploadResult actionResult = null;
                bool _fileUploaded = false;

                Task taskUpload = client.PostAsync("api/v1/claimed-doc", content).ContinueWith((s) =>
                {
                    if (s.Status == TaskStatus.RanToCompletion)
                    {
                        var response = s.Result;
                        var jsonResponse = response.Content.ReadAsStringAsync();
                        jsonResponse.Wait();

                        if (response.IsSuccessStatusCode)
                        {
                            var jsonConvert = new JavaScriptSerializer();
                            actionResult = jsonConvert.Deserialize<FileUploadResult>(jsonResponse.Result);
                            if (actionResult != null) _fileUploaded = true;
                        }
                    }

                    fileStream.Dispose();
                });

                taskUpload.Wait();
                if (_fileUploaded) dbUpload.Text = actionResult.FileName;
                else dbUpload.Text = string.Empty;

                client.Dispose();
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxCode.Text))
            {
                tbxCode.Focus();
                return;
            }

            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxCode.Text, "code", EnumSqlOperator.Equals));
            if (shipment != null)
            {
                var detail = GridClaim.DataSource as List<ShipmentClaimed>;
                if (detail.Where(p => p.ShipmentCode == tbxCode.Text).FirstOrDefault() == null)
                {
                    if (new ClaimedDataManager().Search(null, null, null, null, null, tbxCode.Text, null).Count == 0)
                    {
                        detail.Add(new ShipmentClaimed
                            {
                                Id = 0,
                                ShipmentId = shipment.Id,
                                ShipmentCode = shipment.Code,
                                CustomerName = shipment.CustomerName,
                                GoodsValue = shipment.GoodsValue,
                                InsuranceFee = shipment.InsuranceFee,
                                StateChange2 = EnumStateChange.Insert.ToString()
                            });

                        GridClaim.DataSource = detail;
                        ClaimView.RefreshData();

                        tbxTotal.Value = detail.Sum(p => p.GoodsValue);
                    }
                    else
                    {
                        MessageBox.Show("Nomor POD sudah dibuatkan claimed sebelumnya.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nomor POD tidak dikenali.");
            }

            tbxCode.Clear();
            tbxCode.Focus();
        }

        public override void New()
        {
            base.New();

            ClearForm();
            GridClaim.DataSource = new List<ShipmentClaimed>();
            ClaimView.RefreshData();

            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lkpClaimBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "id") };
            lkpCustBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "id") };
            tbxCustomer.Focus();
            deleteIds = new List<int>();
        }

        public override void Save()
        {
            if (!string.IsNullOrEmpty(tbxLetterNo.Text))
            {
                var exists = new ClaimedDataManager().GetFirst<ClaimedModel>(WhereTerm.Default(tbxLetterNo.Text, "letter_no", EnumSqlOperator.Equals));
                if (exists != null)
                {
                    if (exists.Id != CurrentModel.Id)
                    {
                        MessageBox.Show(string.Format("Nomor surat {0} sudah digunakan pada claim yang lain."));
                        tbxLetterNo.Focus();
                        return;
                    }
                }
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (var i = 0; i < ClaimView.RowCount; i++)
            {
                if (ClaimView.GetRowCellValue(i, ClaimView.Columns["StateChange2"]) != null)
                if (ClaimView.GetRowCellValue(i, ClaimView.Columns["StateChange2"]).ToString() == EnumStateChange.Insert.ToString())
                {
                    var detail = new ClaimedDetailModel();
                    detail.ClaimedId = CurrentModel.Id;
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.ShipmentId = (int)ClaimView.GetRowCellValue(i, ClaimView.Columns["ShipmentId"]);
                    detail.Createddate = DateTime.Now;
                    detail.Createdby = BaseControl.UserLogin;

                    new ClaimedDetailDataManager().Save<ClaimedDetailModel>(detail);
                }
            }

            foreach (var d in deleteIds)
                new ClaimedDetailDataManager().DeActive(d, BaseControl.UserLogin, DateTime.Now);
        }

        protected override bool ValidateForm()
        {
            if (string.IsNullOrEmpty(tbxCustomer.Text))
            {
                tbxCustomer.Focus();
                return false;
            }

            if (lkpCustBranch.Value == null)
            {
                lkpCustBranch.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxLetterNo.Text))
            {
                tbxLetterNo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(dbUpload.Text))
            {
                dbUpload.Focus();
                return false;
            }

            if (tbxTotal.Value == 0)
            {
                tbxTotal.Focus();
                return false;
            }

            if (ClaimView.RowCount == 0)
            {
                tbxCode.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ClaimedModel model)
        {
            ClearForm();
            if (model == null) return;

            ToolbarCode = model.Id.ToString();
            GridClaim.DataSource = new List<ShipmentClaimed>();
            ClaimView.RefreshData();

            lblDate.Text = model.DateProcess.ToString("dd-MM-yyyy");
            tbxCustomer.Text = model.CustomerName;

            lkpClaimBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ClaimedBranchId, "id") };
            lkpCustBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CustomerBranchId, "id") };

            tbxLetterNo.Text = model.LetterNo;
            tbxDescription.Text = model.Description;
            dbUpload.Text = model.DocName;
            tbxTotal.Value = model.Total;

            deleteIds = new List<int>();

            GridClaim.DataSource = new ClaimedDetailDataManager().GetShipments(model.Id);
            ClaimView.RefreshData();
        }

        protected override void AfterSave()
        {
            ToolbarCode = CurrentModel.Id.ToString();
            PerformFind();
        }

        protected override ClaimedModel PopulateModel(ClaimedModel model)
        {
            model.BranchId = BaseControl.BranchId;
            if (model.Id == 0) model.DateProcess = DateTime.Now;

            model.CustomerName = tbxCustomer.Text;
            model.ClaimedBranchId = (int)lkpClaimBranch.Value;
            model.CustomerBranchId = (int)lkpCustBranch.Value;
            model.LetterNo = tbxLetterNo.Text;
            model.Description = tbxDescription.Text;
            model.DocName = dbUpload.Text;
            model.Total = tbxTotal.Value;

            return model;
        }

        protected override ClaimedModel Find(string searchTerm)
        {
            if (Regex.IsMatch(searchTerm, "^[0-9]+$"))
                return new ClaimedDataManager().GetFirst<ClaimedModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"));
            else return null;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as ClaimedModel;
            if (model != null && model.Id > 0)
            {
                
            }
        }
    }

    public class FileUploadResult
    {
        public string LocalFilePath { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
    }
}
