using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class MissDeliveryReasonPopup : BasePopupGrid
    {
        public MissDeliveryReasonPopup()
        {
            InitializeComponent();
            DataManager = new MissDeliveryReasonDataManager();
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = DataManager.Get<MissDeliveryReasonModel>();
            objGrid.DataSource = model;
        }
    }
}
