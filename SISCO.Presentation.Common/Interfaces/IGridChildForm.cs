using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Devenlab.Common;

namespace SISCO.Presentation.Common.Interfaces
{
    public interface IGridChildForm : IChildForm
    {
        void DetailNew();
        void DetailDelete();
    }
}
