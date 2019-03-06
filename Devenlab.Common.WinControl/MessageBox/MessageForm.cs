using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Devenlab.Common.WinControl.MessageBox
{
    public enum EnumButton
    {
        OKCancel,
        YesNo,
        OK
    }

    public enum EnumIcon
    {
        Info,
        Warning,
        Ask,
        Error
    }
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
            labelCaption.Text = string.Empty;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        public void SetTitle(string title)
        {
            labelCaption.Text = title;
        }

        public void SetMessage(string message)
        {
            richTextBoxMessage.Text = message;
        }

        public void SetIcon(EnumIcon? icon)
        {
            switch (icon)
            {
                case EnumIcon.Info:
                    pictureBox1.Image = Properties.Resources.ImageMsgInfo;
                    break;
                case EnumIcon.Warning:
                    pictureBox1.Image = Properties.Resources.ImageMsgWarn;
                    break;
                case EnumIcon.Ask:
                    pictureBox1.Image = Properties.Resources.ImageMsgAsk;
                    break;
                case EnumIcon.Error:
                    pictureBox1.Image = Properties.Resources.ImageMsgError;
                    break;
                default:
                    pictureBox1.Image = Properties.Resources.ImageMsgInfo;
                    break;
            }
            
        }

        public void SetButton(EnumButton button)
        {
            switch (button)
            {
                case EnumButton.OKCancel:
                    buttonOk.Visible = true;
                    AcceptButton = buttonOk;
                    CancelButton = buttonCancel;
                    buttonCancel.Visible = true;
                    buttonCancel.Click += OnCloseMessage;
                    break;
                case EnumButton.YesNo:
                    buttonNo.Visible = true;
                    buttonYes.Visible = true;
                    buttonCancel.Visible = false;
                    break;
                //case EnumButton.OK:
                default:
                    buttonOk.Visible = true;
                    buttonOk.Click += OnCloseMessage;
                    AcceptButton = buttonOk;
                    buttonOk.Select();
                    break;
            }
        }

        void OnCloseMessage(object sender, EventArgs e)
        {
            Close();
        }

        public static void Info(IWin32Window windowForm, string title, string message)
        {
            using (var blankForm = new BlankForm())
            {
                using (var messageForm = new MessageForm())
                {
                    messageForm.SetButton(EnumButton.OK);
                    messageForm.SetMessage(message);
                    messageForm.SetTitle(title);
                    messageForm.SetIcon(EnumIcon.Info);
                    blankForm.ShowDialogEditor(windowForm, messageForm);
                }
            }
        }

        public static void Warning(IWin32Window windowForm, string title, string message)
        {
            using (var blankForm = new BlankForm())
            {
                using (var messageForm = new MessageForm())
                {
                    messageForm.SetButton(EnumButton.OKCancel);
                    messageForm.SetMessage(message);
                    messageForm.SetTitle(title);
                    messageForm.SetIcon(EnumIcon.Warning);
                    blankForm.ShowDialogEditor(windowForm, messageForm);
                }
            }
        }

        public static DialogResult Ask(IWin32Window windowForm, string title, string message, bool yesButtonFocus = false)
        {
            using (var blankForm = new BlankForm())
            {
                using (var messageForm = new MessageForm())
                {
                    
                    messageForm.SetButton(EnumButton.YesNo);
                    messageForm.SetMessage(message);
                    messageForm.SetTitle(title);
                    messageForm.SetIcon(EnumIcon.Ask);
                    
                    if (!yesButtonFocus) messageForm.AcceptButton = messageForm.buttonYes;
                    messageForm.CancelButton = messageForm.buttonNo;
                    return blankForm.ShowDialogEditor(windowForm, messageForm);
                }
            }
        }

        public static void Error(IWin32Window windowForm, string title, string message)
        {
            using (var blankForm = new BlankForm())
            {
                using (var messageForm = new MessageForm())
                {
                    messageForm.SetButton(EnumButton.OK);
                    messageForm.SetMessage(message);
                    messageForm.SetTitle(title);
                    messageForm.SetIcon(EnumIcon.Error);
                    blankForm.ShowDialogEditor(windowForm, messageForm);
                }
            }
        }
    }
}