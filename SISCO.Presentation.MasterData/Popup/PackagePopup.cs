using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class PackagePopup : BasePopupGrid
    {
        public PackagePopup()
        {
            InitializeComponent();
            DataManager = new PackageDataManager();
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = DataManager.Get<PackageTypeModel>();
            objGrid.DataSource = model;
        }
    }
}
