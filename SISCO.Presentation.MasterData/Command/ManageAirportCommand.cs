﻿using System;
using System.Collections.Generic;

using SISCO.Presentation.Common;
using SISCO.Presentation.MasterData.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Command
{
    public class ManageAirportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageAirportForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
