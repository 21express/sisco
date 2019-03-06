using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class DivisionPopup : BasePopupGrid
    {
        public string Expression { get; set; }
        public object[] ExpressionParameters { get; set; }
        public IListParameter[] Param { get; set; }

        public DivisionPopup()
        {
            InitializeComponent();
            DataManager = new DivisionDataManager();
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            if (Param != null)
            {
                objGrid.DataSource = DataManager.Get<DivisionModel>(Param);
            }
            else if (Expression != null && ExpressionParameters != null)
            {
                int totalCount;
                objGrid.DataSource =
                    ((DivisionDataManager)DataManager).Get<DivisionModel>(
                        new Paging {Limit = 99999, Start = 0}, out totalCount, Expression, ExpressionParameters);
            }
            else
            {
                objGrid.DataSource = ((DivisionDataManager)DataManager).Get<DivisionModel>();
            }
        }
    }
}
