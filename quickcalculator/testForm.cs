﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quickcalculator
{
    public partial class testForm : Form
    {
        public testForm()
        {
            InitializeComponent();

            this.testPicturebox.Image = this.Draw(this.testPicturebox.Width, this.testPicturebox.Height);
        }

        public Bitmap Draw(int width, int height)
        {
            //draw a flippin square
            //var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            //var graphics = Graphics.FromImage(bitmap);
            //graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.FillRectangle(new SolidBrush(Color.Tomato), 10, 10, 100, 100);
            int color1R = 255;
            int color1G = 0;
            int color1B = 0;
            int color2R = 255;
            int color2G = 255;
            int color2B = 0;
            int alphaVal = 255;
            //Graphics FormGraphics;
            /////Bitmap caret = new Bitmap(10, this.ClientRectangle.Height - 1);
            Bitmap caret = new Bitmap(this.ClientRectangle.Width-1, this.ClientRectangle.Height - 1);
            using (Graphics g = Graphics.FromImage(caret))
            {
                /*Rectangle rectBrush = new Rectangle(0, 0, 1, 1);
                LinearGradientBrush brush = new LinearGradientBrush(rectBrush, Color.FromArgb(alphaVal, color1R, color1G, color1B), Color.FromArgb(alphaVal, color2R, color2G, color2B), LinearGradientMode.Horizontal);               
                Blend BlendOptions = new Blend();
                BlendOptions.Factors = new float[] { .5f, .85f, 1f, .85f, .50f, .14f, .0f, .14f, .49f };
                BlendOptions.Positions = new float[] { 0.0f, .125f, .25f, .375f, .5f, .625f, .75f, .875f, 1.0f };
                brush.Blend = BlendOptions;
                Pen p = new Pen(brush, 3);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawLine(p, new Point(caret.Width / 2, 1), new Point(1, caret.Height - 1));
                brush = new LinearGradientBrush(rectBrush, Color.FromArgb(alphaVal, color1R, color1G, color1B), Color.FromArgb(alphaVal, color2R, color2G, color2B), -38);
                brush.Blend = BlendOptions;
                p = new Pen(brush, 3);
                g.DrawLine(p, new Point(1, caret.Height - 1), new Point(caret.Width - 1, caret.Height - 1));
                brush = new LinearGradientBrush(rectBrush, Color.FromArgb(alphaVal, color1R, color1G, color1B), Color.FromArgb(alphaVal, color2R, color2G, color2B), 131);
                brush.Blend = BlendOptions;
                p = new Pen(brush, 3);
                g.DrawLine(p, new Point(caret.Width - 1, caret.Height - 1), new Point(caret.Width / 2, 1));*/

                Color cola1 = Color.FromArgb(alphaVal, color1R, color1G, color1B);
                Color cola2 = Color.FromArgb(alphaVal, color2R, color2G, color2B);
                // Vertices of the outer triangle
                Point[] points = {
                    new Point(0, 0),
                    new Point(120, 200),
                    new Point(0, 200)};

                // No GraphicsPath object is created. The PathGradientBrush
                // object is constructed directly from the array of points.
                PathGradientBrush pthGrBrush = new PathGradientBrush(points);

               /* Color[] colors = {
                Color.FromArgb(255, 0, 128, 0),    // dark green
                Color.FromArgb(255, 0, 255, 255)};   // blue
                */

                Color[] colors = {
                cola1,    // dark green
                cola2};   // blue

                float[] relativePositions = {
                    0f,       // Dark green is at the boundary of the triangle.
                    1.0f};    // Blue is at the center point.

                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = colors;
                colorBlend.Positions = relativePositions;
                pthGrBrush.InterpolationColors = colorBlend;

                // Fill a rectangle that is larger than the triangle
                // specified in the Point array. The portion of the
                // rectangle outside the triangle will not be painted.
                g.FillRectangle(pthGrBrush, 0, 0, 200, 200);
            }
            return caret;
            //return bitmap;
        }
    }
}
