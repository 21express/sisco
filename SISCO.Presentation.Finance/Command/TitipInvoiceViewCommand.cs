﻿using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Finance.Forms;

namespace SISCO.Presentation.Finance.Command
{
    public class TitipInvoiceViewCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new TitipInvoiceViewForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
