using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class PaymentTypePopup : BasePopupGrid
    {
        public PaymentTypePopup()
        {
            InitializeComponent();
            DataManager = new PaymentTypeDataManager();
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = DataManager.Get<PaymentTypeModel>();
            objGrid.DataSource = model;
        }
    }
}
