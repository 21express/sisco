using System;

namespace Franchise.Presentation.Common.Interfaces
{
    public interface IPopup
    {
        int SelectedValue { get; set; }
        string SelectedCode { get; set; }
        string SelectedText { get; set; }

        void SelectRow(object sender, EventArgs e);
    }
}
