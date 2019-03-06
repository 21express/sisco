using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Devenlab.Common.WinControl
{
    partial class BlankForm : Form
    {
        public BlankForm()
        {
            InitializeComponent();
        }

        private Form _currentForm;
        private DialogResult dialogResult;
        public DialogResult ShowDialogEditor(IWin32Window win32Window, Form form)
        {
            _currentForm = form;
            Shown += OnShown;
            ShowDialog(win32Window);
            return dialogResult;
        }

        private void OnShown(object sender, EventArgs eventArgs)
        {
            _currentForm.FormClosed += currentForm_FormClosed;
            dialogResult = _currentForm.ShowDialog(this);
        }

        void currentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
