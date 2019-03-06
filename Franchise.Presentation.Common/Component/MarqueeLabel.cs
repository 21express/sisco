using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Franchise.Presentation.Common.Component
{
    [ToolboxItem(true)]
    public sealed class MarqueeLabel : ToolStripStatusLabel
    {
        private IContainer components;
        private Timer _timer1;

        private int _currentPos;
        private bool _mBorder;
        private string _mText;

        public string MarqueeText
        {
            get { return _mText; }
            set { _mText = value; }
        }

        public bool Border
        {
            get { return _mBorder; }
            set { _mBorder = value; }
        }

        public int Interval
        {
            get { return _timer1.Interval * 10; }
            set { _timer1.Interval = value / 10; }
        }


        public MarqueeLabel()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitForm call
            Size = new Size(Width, Font.Height);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this._timer1.Enabled = true;
            this._timer1.Interval = 1000;
            this._timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Marquee
            // 
            //this.Resize += new System.EventHandler(this.Marquee_Resize);

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, Width - 1, Height - 1);

            var textSize = e.Graphics.MeasureString(_mText, Font);
            var dif = textSize.Width - Width;
            var paddingTop = Convert.ToInt32((Height - textSize.Height)/2);

            if (Width < textSize.Width)
            {
                e.Graphics.DrawString(_mText, Font, new SolidBrush(ForeColor),
                    Width + _currentPos, paddingTop);
                e.Graphics.DrawString(_mText, Font, new SolidBrush(ForeColor),
                    Width + Width + Width + _currentPos + dif, paddingTop);

                _currentPos--;

                if ((_currentPos < 0) && (Math.Abs(_currentPos) >= (textSize.Width + (Width * 6))))
                    _currentPos = 0;
            }
            else
            {
                e.Graphics.DrawString(_mText, Font, new SolidBrush(ForeColor), -dif / 2, 0);
            }

        }
    }
}
