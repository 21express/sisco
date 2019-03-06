using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class ServicePopup : BasePopupGrid
    {
        public ServicePopup()
        {
            InitializeComponent();
            DataManager = new ServiceDataManager();
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = DataManager.Get<ServiceTypeModel>();
            objGrid.DataSource = model;
        }
    }
}
