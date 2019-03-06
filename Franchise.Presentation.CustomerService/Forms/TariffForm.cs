using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.MasterData.Popup;
using SISCO.App.MasterData;
using SISCO.Models;

namespace Franchise.Presentation.CustomerService.Forms
{
    public partial class TariffForm : BaseForm
    {
        public TariffForm()
        {
            InitializeComponent();
            form = this;

            Load += TariffLoad;
        }

        private void TariffLoad(object sender, EventArgs e)
        {            
            lkpOrigin.LookupPopup = new CityPopup();
            lkpOrigin.AutoCompleteDataManager = new CityDataManager();
            lkpOrigin.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpOrigin.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpOrigin.FieldLabel = "Origin City";
            lkpOrigin.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityDataManager();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestination.FieldLabel = "Destination City";
            lkpDestination.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpOrigin.Focus();
            ClearForm();

            btnFind.Click += ShowTariff;
        }

        private void ShowTariff(object sender, EventArgs e)
        {
            if (lkpOrigin.Value != null)
            {
                if (lkpDestination.Value != null)
                {
                    var ds = new TariffDataManager().GetTarif((int)lkpOrigin.Value, (int)lkpDestination.Value);
                    tarifGrid.DataSource = ds;
                    tarifView.RefreshData();
                }
            }
        }
    }
}
