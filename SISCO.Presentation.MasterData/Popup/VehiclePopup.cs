using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class VehiclePopup : BasePopupGrid
    {
        public VehiclePopup()
        {
            InitializeComponent();
            DataManager = new VehicleTypeDataManager();
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = DataManager.Get<VehicleTypeModel>();
            objGrid.DataSource = model;
        }
    }
}
