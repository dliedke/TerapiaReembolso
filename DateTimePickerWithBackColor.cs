// *****************************************
// ** Author: Vincenzo Rossi              **
// ** Year  : 2008                        **
// ** Mail  : redmaster@tiscali.it        **
// **                                     **
// ** Released under                      **
// **   The Code Project Open License     **
// *****************************************

using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace TerapiaReembolso
{
    /// <summary>
    ///     A derivation of DateTimePicker allowing to change background color
    /// </summary>
    public class DateTimePickerWithBackColor : System.Windows.Forms.DateTimePicker
    {
        private Color _backDisabledColor;
        private Color _foreDisabledColor;

        public DateTimePickerWithBackColor() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            _backDisabledColor = Color.FromKnownColor(KnownColor.Control);
        }

        /// <summary>
        ///     Gets or sets the background color of the control
        /// </summary>
        [Browsable(true)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        ///     Gets or sets the fore color of the control
        /// </summary>
        [Browsable(true)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        /// <summary>
        ///     Gets or sets the background color of the control when disabled
        /// </summary>
        [Category("Appearance"), Description("The background color of the component when disabled")]
        [Browsable(true)]
        public Color BackDisabledColor
        {
            get { return _backDisabledColor; }
            set { _backDisabledColor = value; }
        }

        /// <summary>
        ///     Gets or sets the background color of the control when disabled
        /// </summary>
        [Category("Appearance"), Description("The fore color of the component when disabled")]
        [Browsable(true)]
        public Color ForeDisabledColor
        {
            get { return _foreDisabledColor; }
            set { _foreDisabledColor = value; }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //Graphics g = e.Graphics;
            
            //The dropDownRectangle defines position and size of dropdownbutton block, 
            //the width is fixed to 17 and height to 16. The dropdownbutton is aligned to right
            Rectangle dropDownRectangle = new Rectangle(ClientRectangle.Width - 17, 0, 17, 16);
            Brush bkgBrush;
            Brush fgBrush;
            ComboBoxState visualState;

            //When the control is enabled the brush is set to Backcolor, 
            //otherwise to color stored in _backDisabledColor
            if (this.Enabled) {
                 bkgBrush = new SolidBrush(this.BackColor);
                 fgBrush = new SolidBrush(this.ForeColor);
                 visualState = ComboBoxState.Normal;
            }
            else {
                bkgBrush = new SolidBrush(this._backDisabledColor);
                fgBrush = new SolidBrush(this._foreDisabledColor);
                visualState = ComboBoxState.Disabled;
            }

            // Painting...in action

            //Filling the background
            g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            
            //Drawing the datetime text
            g.DrawString(this.Text, this.Font, fgBrush, 0, 2);

            //Drawing the dropdownbutton using ComboBoxRenderer
            ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, visualState);

            g.Dispose();
            bkgBrush.Dispose();
        }
    }
}
