using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using Franchise.Presentation.Common.Forms;

namespace Franchise.Presentation.MasterData.Popup
{
    public partial class PaymentMethodPopup : BasePopupGrid
    {
        public string Expression { get; set; }
        public object[] ExpressionParameters { get; set; }
        public IListParameter[] Param { get; set; }

        public PaymentMethodPopup()
        {
            InitializeComponent();
            DataManager = new PaymentMethodDataManager();
        }

        public PaymentMethodPopup(IListParameter[] p)
        {
            InitializeComponent();
            DataManager = new PaymentMethodDataManager();

            Param = p;
        }

        public PaymentMethodPopup(string expression, params object[] parameters)
        {
            InitializeComponent();
            DataManager = new PaymentMethodDataManager();

            Expression = expression;
            ExpressionParameters = parameters;
        }

        protected override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            if (Param != null)
            {
                objGrid.DataSource = DataManager.Get<PaymentMethodModel>(Param);
            }
            else if (Expression != null && ExpressionParameters != null)
            {
                int totalCount;
                objGrid.DataSource =
                    ((PaymentMethodDataManager) DataManager).Get<PaymentMethodModel>(
                        new Paging {Limit = 99999, Start = 0}, out totalCount, Expression, ExpressionParameters);
            }
            else
            {
                objGrid.DataSource = ((PaymentMethodDataManager)DataManager).Get<PaymentMethodModel>();
            }
        }
    }
}
