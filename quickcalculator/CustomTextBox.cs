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
 * 5/4/2019
 * v 1.0.9
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
        String caretShape = "rect";  //can be 'rect', 'triangle', or 'quad'


        //constructor
        public CustomTextBox()
        {
            caret = new Bitmap(10, this.ClientRectangle.Height); //was Height-1
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

            //set  default caret shape
            //setCaretShape("rect");
        }

        public String getCaretShape()
        {
            return caretShape;
        }

        public void setCaretShape(String cShape)
        {
            if(cShape.Equals("rect"))
            {
                caretShape = "rect";
                this.Invalidate();
                this.Focus();
            }
            if(cShape.Equals("triangle"))
            {
                caretShape = "triangle";
                this.Invalidate();
                this.Focus();
            }
            if(cShape.Equals("quad"))
            {   
                caretShape = "quad";
                this.Invalidate();
                this.Focus();
            }
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            //Console.WriteLine("OnGotFocus() triggered");
            try
            {
                DestroyCaret();
                //HideCaret(this.Handle);
                //Bitmap caret = new Bitmap(10, this.ClientRectangle.Height - 1);
                caret = new Bitmap(10, this.ClientRectangle.Height); //was Height-1
                Color clr1 = Color.FromArgb(alphaVal, color1R, color1G, color1B);
                Color clr2 = Color.FromArgb(alphaVal, color2R, color2G, color2B);
                using (Graphics g = Graphics.FromImage(caret))
                {
                    g.Clear(Color.Black);
                    switch (caretShape)
                    {
                        case "rect":
                            brush = new LinearGradientBrush(startPoint, endPoint, clr1, clr2);
                            g.FillRectangle(brush, 0, 0, 20, 30);
                            break;
                        case "triangle":
                            Point[] tripoints = {
                                new Point(0, 0),
                                new Point(caret.Width, caret.Height),
                                new Point(0, caret.Height)};
                            PathGradientBrush tripthGrBrush = new PathGradientBrush(tripoints);
                            Color[] tricolors = {
                                clr1,
                                clr2 };
                            float[] trirelativePositions = {
                                0f,       
                                1.0f};
                            ColorBlend tricolorBlend = new ColorBlend();
                            tricolorBlend.Colors = tricolors;
                            tricolorBlend.Positions = trirelativePositions;
                            tripthGrBrush.InterpolationColors = tricolorBlend;
                            g.FillRectangle(tripthGrBrush, 0, 0, caret.Width - 1, caret.Height - 1);
                            break;
                        case "quad":
                            Point[] quadpoints = {
                                new Point(0, 0),  //left top most
                                new Point(caret.Width-4, 3), //right top most slightly inside
                                new Point(caret.Width-4, caret.Height-3), //right bottom most slightly inside
                                new Point(0, caret.Height)};  //left bottom most
                            PathGradientBrush quadpthGrBrush = new PathGradientBrush(quadpoints);
                            Color[] quadcolors = {
                                clr1,
                                clr2 };
                            float[] quadrelativePositions = {
                                0f,
                                1.0f};
                            ColorBlend quadcolorBlend = new ColorBlend();
                            quadcolorBlend.Colors = quadcolors;
                            quadcolorBlend.Positions = quadrelativePositions;
                            quadpthGrBrush.InterpolationColors = quadcolorBlend;
                            g.FillRectangle(quadpthGrBrush, 0, 0, caret.Width - 1, caret.Height - 1);
                            break;
                    }
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
                    using (caret = new Bitmap(10, this.ClientRectangle.Height))  //was Height-1
                    {
                        Color clr1 = Color.FromArgb(op, color1R, color1G, color1B);
                        Color clr2 = Color.FromArgb(op, color2R, color2G, color2B);
                        using (Graphics g = Graphics.FromImage(caret))
                        {
                            g.Clear(Color.Black);
                            switch (caretShape)
                            {
                                case "rect":
                                    brush = new LinearGradientBrush(startPoint, endPoint, clr1, clr2);
                                    g.FillRectangle(brush, 0, 0, 20, 30);
                                    break;
                                case "triangle":
                                    Point[] points = {
                                        new Point(0, 0),
                                        new Point(caret.Width, caret.Height),
                                        new Point(0, caret.Height)};
                                    PathGradientBrush pthGrBrush = new PathGradientBrush(points);
                                    Color[] colors = {
                                        clr1,
                                        clr2 };
                                    float[] relativePositions = {
                                        0f,
                                        1.0f};
                                    ColorBlend colorBlend = new ColorBlend();
                                    colorBlend.Colors = colors;
                                    colorBlend.Positions = relativePositions;
                                    pthGrBrush.InterpolationColors = colorBlend;
                                    g.FillRectangle(pthGrBrush, 0, 0, caret.Width - 1, caret.Height - 1);
                                    break;
                                case "quad":
                                    Point[] quadpoints = {
                                        new Point(0, 0),  //left top most
                                        new Point(caret.Width-4, 3), //right top most slightly inside
                                        new Point(caret.Width-4, caret.Height-3), //right bottom most slightly inside
                                        new Point(0, caret.Height)};  //left bottom most
                                    PathGradientBrush quadpthGrBrush = new PathGradientBrush(quadpoints);
                                    Color[] quadcolors = {
                                        clr1,
                                        clr2 };
                                    float[] quadrelativePositions = {
                                        0f,
                                        1.0f};
                                    ColorBlend quadcolorBlend = new ColorBlend();
                                    quadcolorBlend.Colors = quadcolors;
                                    quadcolorBlend.Positions = quadrelativePositions;
                                    quadpthGrBrush.InterpolationColors = quadcolorBlend;
                                    g.FillRectangle(quadpthGrBrush, 0, 0, caret.Width - 1, caret.Height - 1);
                                    break;
                            }
                            bitmapPtr = caret.GetHbitmap(Color.White);
                            //CreateCaret(this.Handle, caret.GetHbitmap(Color.White), cWidth, cHeight);
                            CreateCaret(this.Handle, bitmapPtr, cWidth, cHeight);
                            ShowCaret(this.Handle);
                            //add bitmapPtr to list  GDI handles to be deleted later  max num of GDI handles in prog. is 10,000 (windows 65,536)
                            bitmapPtrList.Add(bitmapPtr);
                        }                
                    }
                }
                else
                {
                    //we get here once the opacity has dropped below 0 (end of a full fade)
                    //let's free memory after awhile
                    if (fadeCount > (20 + 400 + 69))
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