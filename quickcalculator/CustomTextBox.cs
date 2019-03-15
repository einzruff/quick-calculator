using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Quick Calculator - CustomTextBox.cs
 * by Daphne Lundquist
 * 3/14/2019   3.14159265359
 */

namespace quickcalculator
{
    class CustomTextBox : TextBox
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowCaret(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        int cWidth = 15;
        int cHeight = 31;
        int alphaVal = 255;

        protected override void OnGotFocus(System.EventArgs e)
        {
                //HideCaret(this.Handle);
                Bitmap caret = new Bitmap(10, this.ClientRectangle.Height - 1);
                using (Graphics g = Graphics.FromImage(caret))
                {
                    g.Clear(Color.Black);
                    //draw a triangle
                    //g.DrawLine(Pens.White, new Point(caret.Width / 2, 1), new Point(1, caret.Height - 1));
                    //g.DrawLine(Pens.White, new Point(1, caret.Height - 1), new Point(caret.Width - 1, caret.Height - 1));
                    //g.DrawLine(Pens.White, new Point(caret.Width - 1, caret.Height - 1), new Point(caret.Width / 2, 1));

                    Graphics FormGraphics = this.CreateGraphics();
                    Rectangle rectBrush = new Rectangle(0, 0, 1, 1);
                    //LinearGradientBrush brush = new LinearGradientBrush(rectBrush, Color.White, Color.Black,LinearGradientMode.Horizontal);

                    Point startPoint = new Point(0, 0);
                    Point endPoint = new Point(20, 20);

                    LinearGradientBrush brush = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(alphaVal, 255, 0, 0), Color.FromArgb(alphaVal, 255, 255, 0));
                    g.FillRectangle(brush, 0, 0, 20, 30);

                    //blend triangle caret
                    /*Blend BlendOptions = new Blend();
                    BlendOptions.Factors = new float[] { .5f, .85f, 1f, .85f, .50f, .14f, .0f, .14f, .49f };
                    BlendOptions.Positions = new float[] { 0.0f, .125f, .25f, .375f, .5f, .625f, .75f, .875f, 1.0f };
                    brush.Blend = BlendOptions;
                    Pen p = new Pen(brush, 3);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawLine(p, new Point(caret.Width / 2, 1), new Point(1, caret.Height - 1));
                    brush = new LinearGradientBrush(rectBrush, Color.White, Color.Black, -38);
                    brush.Blend = BlendOptions;
                    p = new Pen(brush, 3);
                    g.DrawLine(p, new Point(1, caret.Height - 1), new Point(caret.Width - 1, caret.Height - 1));
                    brush = new LinearGradientBrush(rectBrush, Color.White, Color.Black, 131);
                    brush.Blend = BlendOptions;
                    p = new Pen(brush, 3);
                    g.DrawLine(p, new Point(caret.Width - 1, caret.Height - 1), new Point(caret.Width / 2, 1));
                    */

                    CreateCaret(this.Handle, caret.GetHbitmap(Color.White), cWidth, cHeight);
                    ShowCaret(this.Handle);
                    base.OnGotFocus(e);
            }
        }

        public void updateCaretOpacity(int op)
        {
            if (op > 0)
            {
                HideCaret(this.Handle);
                Bitmap caret = new Bitmap(10, this.ClientRectangle.Height - 1);
                using (Graphics g = Graphics.FromImage(caret))
                {
                    g.Clear(Color.Black);
                    Graphics FormGraphics = this.CreateGraphics();
                    Rectangle rectBrush = new Rectangle(0, 0, 1, 1);
                    Point startPoint = new Point(0, 0);
                    Point endPoint = new Point(20, 20);
                    LinearGradientBrush brush = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(op, 255, 0, 0), Color.FromArgb(op, 255, 255, 0));
                    g.FillRectangle(brush, 0, 0, 20, 30);
                    CreateCaret(this.Handle, caret.GetHbitmap(Color.White), cWidth, cHeight);
                    ShowCaret(this.Handle);
                }
            }
        }
    }
}