using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


/* Quick Calculator - CustomTextBox.cs
 * by Daphne Lundquist
 * 3/24/2019
 * v 1.0.5
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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool DestroyCaret();

        [DllImport("gdi32.dll")] public static extern int DeleteObject(IntPtr hObject);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetProcessWorkingSetSize(IntPtr process,
        UIntPtr minimumWorkingSetSize, UIntPtr maximumWorkingSetSize);

        int cWidth = 15;
        int cHeight = 31;
        int alphaVal = 255;
        int fadeCount = 0;

        Bitmap caret;
        Graphics FormGraphics;
        Rectangle rectBrush;
        Point startPoint;
        Point endPoint;
        LinearGradientBrush brush;
        int color1R;
        int color1G;
        int color1B;
        int color2R;
        int color2G;
        int color2B;
        ArrayList bitmapPtrList = new ArrayList();
        //List<IntPtr> handlesNp = new List<IntPtr>();

        //constructor
        public CustomTextBox()
        {
            caret = new Bitmap(10, this.ClientRectangle.Height - 1);
            FormGraphics = this.CreateGraphics();
            rectBrush = new Rectangle(0, 0, 1, 1);
            startPoint = new Point(0, 0);
            endPoint = new Point(20, 20);

            color1R = 255;
            color1G = 0;
            color1B = 0;
            color2R = 255;
            color2G = 255;
            color2B = 0;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            Console.WriteLine("OnGotFocus() triggered");
            try
            {
                DestroyCaret();
                //HideCaret(this.Handle);
                //Bitmap caret = new Bitmap(10, this.ClientRectangle.Height - 1);
                caret = new Bitmap(10, this.ClientRectangle.Height - 1);
                using (Graphics g = Graphics.FromImage(caret))
                {
                    g.Clear(Color.Black);
                    //draw a triangle
                    //g.DrawLine(Pens.White, new Point(caret.Width / 2, 1), new Point(1, caret.Height - 1));
                    //g.DrawLine(Pens.White, new Point(1, caret.Height - 1), new Point(caret.Width - 1, caret.Height - 1));
                    //g.DrawLine(Pens.White, new Point(caret.Width - 1, caret.Height - 1), new Point(caret.Width / 2, 1));

                    //Graphics FormGraphics = this.CreateGraphics();
                    //Rectangle rectBrush = new Rectangle(0, 0, 1, 1);
                    //FormGraphics = this.CreateGraphics();
                    //rectBrush = new Rectangle(0, 0, 1, 1);
                    //LinearGradientBrush brush = new LinearGradientBrush(rectBrush, Color.White, Color.Black,LinearGradientMode.Horizontal);

                    //Point startPoint = new Point(0, 0);
                    //Point endPoint = new Point(20, 20);

                    //LinearGradientBrush brush = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(alphaVal, color1R, color1G, color1B), Color.FromArgb(alphaVal, color2R, color2G, color2B));
                    brush = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(alphaVal, color1R, color1G, color1B), Color.FromArgb(alphaVal, color2R, color2G, color2B));
                    //LinearGradientBrush brush = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(alphaVal, 255, 0, 0), Color.FromArgb(alphaVal, 255, 255, 0));
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
                    caret.Dispose();
                    base.OnGotFocus(e);
                }
            }
            catch (Exception ee)
            {
                //excepc'ion
                Console.WriteLine(ee.Message);
            }
        }

        public void changeColors(int c1R, int c1G, int c1B, int c2R, int c2G, int c2B)
        {
            color1R = c1R;
            color1G = c1G;
            color1B = c1B;
            color2R = c2R;
            color2G = c2G;
            color2B = c2B;
        }

        public void UpdateCaretOpacity(int op)
        {
            IntPtr bitmapPtr = new IntPtr();
            try
            {
                if (op > 0)
                {
                    //DestroyCaret();
                    //HideCaret(this.Handle);
                    //caret = new Bitmap(10, this.ClientRectangle.Height - 1);
                    using (caret = new Bitmap(10, this.ClientRectangle.Height - 1))
                    {
                        using (Graphics g = Graphics.FromImage(caret))
                        {
                            g.Clear(Color.Black);
                            //FormGraphics = this.CreateGraphics();
                            //Rectangle rectBrush = new Rectangle(0, 0, 1, 1);
                            //Point startPoint = new Point(0, 0);
                            //Point endPoint = new Point(20, 20);
                            brush = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(op, color1R, color1G, color1B), Color.FromArgb(op, color2R, color2G, color2B));
                            //brush = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(op, 255, 0, 0), Color.FromArgb(op, 255, 255, 0));
                            g.FillRectangle(brush, 0, 0, 20, 30);
                            bitmapPtr = caret.GetHbitmap(Color.White);
                            //CreateCaret(this.Handle, caret.GetHbitmap(Color.White), cWidth, cHeight);
                            CreateCaret(this.Handle, bitmapPtr, cWidth, cHeight);
                            ShowCaret(this.Handle);
                            //add bitmapPtr to list  GDI handles to be deleted later  max num of GDI handles in prog. is 10,000 (windows 65,536)
                            bitmapPtrList.Add(bitmapPtr);
                            //caret.UnlockBits(bp.ToPointer());
                            //caret.Dispose();
                            //DestroyCaret();
                            //Marshal.FreeHGlobal(bp);
                            //Marshal.FreeCoTaskMem(bp);
                        }                
                    }
                }
                else
                {
                    //we get here once the opacity has dropped below 0 (end of a full fade)
                    //let's free memory after awhile
                    if (fadeCount > 169)
                    {
                        //Console.WriteLine("at garbage collection " + bitmapPtrList.Count + " :items in list");
                        //iterate through bitmapPtrList and delete bitmap pointers to prevent GDI handle overload
                        for(int i = 0; i<bitmapPtrList.Count; i++)
                        {
                            IntPtr ptr = (IntPtr)bitmapPtrList[i];
                            if (ptr != null)
                            {
                                DeleteObject(ptr);
                            }
                        }
                        bitmapPtrList.Clear();

                        //DestroyCaret();
                        minimizeMemory();
                        fadeCount = 0;
                        //Console.WriteLine("memory freed");
                    }
                }
                fadeCount++;
            }
            catch (Exception ee)
            {
                //excepc'ion
                Console.WriteLine(ee.Message);
            }
        }

        private static void minimizeMemory()
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle,
                (UIntPtr)0xFFFFFFFF, (UIntPtr)0xFFFFFFFF);
        }
    }
}