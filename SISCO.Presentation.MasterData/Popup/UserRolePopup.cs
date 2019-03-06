using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class UserRolePopup : BasePopupGrid
    {
        public UserRolePopup()
        {
            InitializeComponent();
            DataManager = new UserRoleDataManager();

            DisplayMember = "Role";
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = DataManager.Get<UserRolesModel>();
            objGrid.DataSource = model;
        }
    }
}
