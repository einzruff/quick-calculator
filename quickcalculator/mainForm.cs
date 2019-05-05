using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Quick Calculator
 * by Daphne Lundquist
 * 5/4/2019
 * v 1.0.9
 */

namespace quickcalculator
{
    public partial class mainForm : Form
    {
        int cOp = 255;
        int caretFadeAmount = 12;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            cboResultOp.SelectedIndex = 0;
            cboConversionType.SelectedIndex = 0;
            rbOperatorMult.Select();
            this.ActiveControl = txtLeftVal;

            tmCaretFade.Enabled = true;

            //set caret fade button colors (settings)
            //btnCFadeColor1.BackColor = Color.FromArgb(255, 255, 0, 0);
            //btnCFadeColor2.BackColor = Color.FromArgb(255, 255, 255, 0);
            //LinearGradientBrush brush = new LinearGradientBrush(0, 20, Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 255, 255, 0));
            //Bitmap bb = gradientTest(btnCFadeFin.ClientRectangle, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 255, 255));
            //btnCFadeFin.BackgroundImage = bb;

            //set initial conversion units
            cboLeftConvOp.SelectedIndex = 2; //inch
            cboRightConvOp.SelectedIndex = 3; //foot
            txtLeftConv.Text = "12";

            this.rbSelRect.Image = this.DrawRBRect(20, 20);
            this.rbSelTriangle.Image = this.DrawRBTriangle(20, 20);
            this.rbSelQuad.Image = this.DrawRBQuad(20, 20);

            //start testForm for debugging
            //testForm tf = new testForm();
            //tf.Show();

            //settings from properties file
            String cShape = Properties.Settings.Default.cShape;
            String cColor1 = Properties.Settings.Default.cColor1;
            String cColor2 = Properties.Settings.Default.cColor2;
            String resultColor = Properties.Settings.Default.resultColor;
            int cFade = Properties.Settings.Default.fadeSpeed;
            //set shape
                if (cShape.Equals("rect"))
                {
                    txtLeftVal.setCaretShape("rect");
                    txtRightVal.setCaretShape("rect");
                    txtResult.setCaretShape("rect"); ;
                    txtExampleTB.setCaretShape("rect");
                    txtLeftVal.Focus();
                }
                if (cShape.Equals("triangle"))
                {
                    txtLeftVal.setCaretShape("triangle");
                    txtRightVal.setCaretShape("triangle");
                    txtResult.setCaretShape("triangle"); ;
                    txtExampleTB.setCaretShape("triangle");
                    txtLeftVal.Focus();
                }
                if (cShape.Equals("quad"))
                {
                    txtLeftVal.setCaretShape("quad");
                    txtRightVal.setCaretShape("quad");
                    txtResult.setCaretShape("quad"); ;
                    txtExampleTB.setCaretShape("quad");
                    txtLeftVal.Focus();
                }
            //set cColor1
                String[] ccol1 = cColor1.Split(',');
                tkColor1R.Value = Int32.Parse(ccol1[0]);
                tkColor1G.Value = Int32.Parse(ccol1[1]);
                tkColor1B.Value = Int32.Parse(ccol1[2]);
            //set cColor2
                String[] ccol2 = cColor2.Split(',');
                tkColor2R.Value = Int32.Parse(ccol2[0]);
                tkColor2G.Value = Int32.Parse(ccol2[1]);
                tkColor2B.Value = Int32.Parse(ccol2[2]);
            //set resultColor
                //set Color Wheel initial color of Color.CadetBlue
                //Color cbRGB = Color.CadetBlue;  //r:95  g:158  b:160  
                String[] rcol = resultColor.Split(',');
                ColorRgb cwRGBInit = new ColorRgb(Int32.Parse(rcol[0]), Int32.Parse(rcol[1]), Int32.Parse(rcol[2]));
                ColorHsv cwHSVInit = (ColorHsv)cwRGBInit.ToHsv();
                //ColorRgb cwRGBInit = new ColorRgb(cbRGB.R, cbRGB.G, cbRGB.B);
                //MessageBox.Show(cbRGB.R + " " + cbRGB.G + " " + cbRGB.B);
                //ColorHsv cwHSVInit = (ColorHsv)cwRGBInit.ToHsv();
                colorWheelz1.Color = cwHSVInit;
            //set fade speed
                caretFadeAmount = cFade;
                numCaretFade.Value = cFade;
        }
 /////////////////////////////////////////////////////////////////////////////////////////////////////////
 // Caret Shape Settings
 //
 /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap DrawRBRect(int wid, int hei)
        {
            Bitmap btmp = new Bitmap(wid, hei);
            using (Graphics g = Graphics.FromImage(btmp))
            {
                Point[] points = {
                    new Point(0, 0),
                    new Point(wid, 0),
                    new Point(wid, hei),
                    new Point(0, hei)};

                using (Pen drpen = new Pen(Color.Blue, 2))
                {
                    g.DrawPolygon(drpen, points);
                }
            }
            return btmp;
        }

        public Bitmap DrawRBTriangle(int wid, int hei)
        {
            Bitmap btmp = new Bitmap(wid, hei);
            using (Graphics g = Graphics.FromImage(btmp))
            {
                Point[] points = {
                    new Point(0, 0),
                    new Point(wid, hei),
                    new Point(0, hei)};

                using (Pen drpen = new Pen(Color.Blue, 2))
                {
                    g.DrawPolygon(drpen, points);
                }
            }
            return btmp;
        }

        public Bitmap DrawRBQuad(int wid, int hei)
        {
            Bitmap btmp = new Bitmap(wid, hei);
            using (Graphics g = Graphics.FromImage(btmp))
            {
                Point[] points = {
                    new Point(0, 0),
                    new Point(wid-5, 4),
                    new Point(wid-5, hei-4),
                    new Point(0, hei)};

            using (Pen drpen = new Pen(Color.Blue, 2))
                {
                    g.DrawPolygon(drpen, points);
                }
            }
            return btmp;
        }

        private void rbSelRect_CheckedChanged(object sender, EventArgs e)
        {
            if(rbSelRect.Checked)
            {   //getwrect
                rbSelTriangle.Checked = false;
                //CustomTextBox currentTxt = GetCurrentTB();
                //currentTxt.setCaretShape("rect");
                txtLeftVal.setCaretShape("rect");
                txtRightVal.setCaretShape("rect");
                txtResult.setCaretShape("rect"); ;
                txtExampleTB.setCaretShape("rect");

                //set properties
                Properties.Settings.Default.cShape = "rect";
                Properties.Settings.Default.Save();
            }
        }

        private void rbSelTriangle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelTriangle.Checked)
            {
                rbSelTriangle.Checked = false;
                //CustomTextBox currentTxt = GetCurrentTB();
                //currentTxt.setCaretShape("triangle");
                txtLeftVal.setCaretShape("triangle");
                txtRightVal.setCaretShape("triangle");
                txtResult.setCaretShape("triangle"); ;
                txtExampleTB.setCaretShape("triangle");

                //set properties
                Properties.Settings.Default.cShape = "triangle";
                Properties.Settings.Default.Save();
            }
        }

        private void RbSelQuad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelQuad.Checked)
            {
                rbSelQuad.Checked = false;
                //CustomTextBox currentTxt = GetCurrentTB();
                //currentTxt.setCaretShape("quad");
                txtLeftVal.setCaretShape("quad");
                txtRightVal.setCaretShape("quad");
                txtResult.setCaretShape("quad"); ;
                txtExampleTB.setCaretShape("quad");

                //set properties
                Properties.Settings.Default.cShape = "quad";
                Properties.Settings.Default.Save();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        Bitmap gradientTest(Rectangle r, Color c1, Color c2)
        {
            Bitmap bmp = new Bitmap(r.Width, r.Height);
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(20, 20);        
            using (Graphics g = Graphics.FromImage(bmp))
                for (int y = 0; y < r.Height; y++)
                {
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(startPoint, endPoint, c2, c1))
                    {
                        g.FillRectangle(lgBrush, 0, 0, 20, 30);
                    }
                }
            return bmp;
        }

        private void txtLeftVal_TextChanged(object sender, EventArgs e)
        {
            updateCalculation();

            //ensure that the operators are not shown in txtLeftVal
            if (!txtLeftVal.Text.Equals(""))
            {
                String lastChar = txtLeftVal.Text.Substring(txtLeftVal.Text.Length - 1);
                if (lastChar.Equals("+") || (lastChar.Equals("-")&&!firstCharNegative()) || lastChar.Equals("*") || lastChar.Equals("/"))
                {
                    txtLeftVal.Text = txtLeftVal.Text.Substring(0, txtLeftVal.Text.Length - 1);
                }
                else if(lastChar.Equals("-") && firstCharNegative())
                {
                    //if initial val is negative don't remove the initial character
                }
            }
        }

        private void txtRightVal_TextChanged(object sender, EventArgs e)
        {
            updateCalculation();
        }

        private bool firstCharNegative()
        {
            String textLeftVal = txtLeftVal.Text;
            String lastChar = textLeftVal.Substring(textLeftVal.Length - 1);
            if ((txtLeftVal.SelectionStart == 1) && lastChar.Equals("-"))
            {
                return true;
            }
            return false;
        }

        private void updateCalculation()
        {
            String textLeftVal = txtLeftVal.Text;
            if (!textLeftVal.Equals(""))
            {
                String lastChar = textLeftVal.Substring(textLeftVal.Length - 1);
                if (!lastChar.Equals("."))
                {
                    bool isNumeric = IsNumber(lastChar.ToString());
                    if ((isNumeric) || firstCharNegative())
                    {
                        lblInfo.Text = "...";
                        tmInfo.Enabled = false;
                        bool leftValParsed = double.TryParse(txtRightVal.Text, out double rightNum);
                        if (leftValParsed)
                        {
                            bool rightValParsed = double.TryParse(textLeftVal, out double leftNum);
                            if (rightValParsed)
                            {
                                double finval = 0.0;
                                //check which operator is selected (+, -, *, /)
                                if (rbOperatorMult.Checked)
                                {
                                    finval = (leftNum * rightNum);
                                }
                                if (rbOperatorPlus.Checked)
                                {
                                    finval = (leftNum + rightNum);
                                }
                                if (rbOperatorSub.Checked)
                                {
                                    finval = (rightNum - leftNum);
                                }
                                if (rbOperatorDiv.Checked)
                                {
                                    finval = (leftNum / rightNum);
                                }
                                txtResult.Text = finval.ToString();
                            }
                        }
                    }
                    else
                    {
                        tmInfo.Enabled = true;
                        lblInfo.Text = "Error: non-numeric value detected.";
                    }
                }
            }
            else
            {
                lblInfo.Text = "...";
                lblInfo.ForeColor = Color.Black;
                tmInfo.Enabled = false;
            }
        }

        private void txtLeftVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Console.WriteLine(e.KeyChar);
            //detect operators in keypress
            if (e.KeyChar == (char)'+')
            {
                rbOperatorPlus.Checked = true;
                txtRightVal.Focus();
                txtRightVal.SelectAll();
                //Console.WriteLine("plus pressed");
            }

            if (e.KeyChar == (char)'-')
            {
                //To detect negative numbers, we will assume that if '-' is pressed while at the beginning of the
                //textbox, then the user wants a negative number
                if (txtLeftVal.SelectionStart == 0)
                {
                    //don't change operator buttons
                }
                else
                {
                    rbOperatorSub.Checked = true;
                    txtRightVal.Focus();
                    txtRightVal.SelectAll();
                    //Console.WriteLine("subtract pressed");
                }
            }

            if (e.KeyChar == (char)'*')
            {
                rbOperatorMult.Checked = true;
                txtRightVal.Focus();
                txtRightVal.SelectAll();
                //Console.WriteLine("multiply pressed");
            }

            if (e.KeyChar == (char)'/')
            {
                rbOperatorDiv.Checked = true;
                txtRightVal.Focus();
                txtRightVal.SelectAll();
                //Console.WriteLine("divide pressed");
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboCopyResult.Checked)
                {
                    //copy result to clipboard
                    if (txtResult.Text != "")
                    {
                        System.Windows.Forms.Clipboard.SetText(txtResult.Text);
                    }
                }
                if (cboClearLeft.Checked)
                {
                    txtLeftVal.Text = "";
                }
                if (cboClearRight.Checked)
                {
                    txtRightVal.Text = "";
                }       
                if (cboClearResult.Checked)
                {
                    txtResult.Text = "";
                }
            }
        }

        private void txtRightVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //on enter key press of txtRightVal, let's reset focus to the left box
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtLeftVal.Text = "";
                txtLeftVal.Focus();
            }
        }

        public Boolean IsNumber(String value)
        {
            return value.All(Char.IsDigit);
        }

        private void btnCopyLeftVal_Click(object sender, EventArgs e)
        {
            if (txtLeftVal.Text != "")
            {
                System.Windows.Forms.Clipboard.SetText(txtLeftVal.Text);
            }
        }

        private void btnCopyRightVal_Click(object sender, EventArgs e)
        {
            if (txtRightVal.Text != "")
            {
                System.Windows.Forms.Clipboard.SetText(txtRightVal.Text);
            }
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != "")
            {
                System.Windows.Forms.Clipboard.SetText(txtResult.Text);
            }
        }

        private void tmInfo_Tick(object sender, EventArgs e)
        {
            //change lblInfo text color
            Random rnd = new Random();
            lblInfo.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }


 /////////////////////////////////////////////////////////////////////////////////////////////////////////
 // Unit Conversion
 //
 /////////////////////////////////////////////////////////////////////////////////////////////////////////
 
        //length constants
        double CV_mill = 0.0000254;
        double CV_inch = 0.0254;
        double CV_foot = 0.3048;
        double CV_yard = 0.9144;
        double CV_mile = 1609.344;
        double CV_capefoot = 0.314856;
        double CV_rod = 5.0292;
        //angstrom
        double CV_nanometer = 0.000000001;
        double CV_micron = 0.000001;
        double CV_millimeter = 0.001;
        double CV_centimeter = 0.01;
        double CV_meter = 1.0;
        double CV_kilometer = 1000.0;
        double CV_lightyear = 9460730472580800.0;
        double CV_parsec = 30856775815580800.0;
        double CV_lightday = 25902068371200.0;
        double CV_lighthour = 1079252848800.0;
        double CV_lightminute = 17987547480.0;
        double CV_lightsecond = 299792458.0;

        //mass constants
        double CV_microgram = 0.000001;
        double CV_milligram = 0.1;
        double CV_gram = 1.0;
        double CV_kilogram = 1000.0;
        double CV_metricton = 1016000.0;
        double CV_ounce = 28.34952;
        double CV_pound = 453.59237;
        double CV_ton = 907200.0;

        //volume constants
        double CV_cubickilometer = 100000000000000;
        double CV_cubicmeter = 100000;
        double CV_hectoliter = 10000;
        double CV_decaliter = 1000;
        double CV_liter = 100;
        double CV_deciliter = 10;
        double CV_centiliter = 1.0;
        double CV_cubiccentimeter = 10;
        double CV_milliliter = 0.10;
        double CV_cubicmilliliter = 0.00010;
        double CV_microliter = 0.00010;
        double CV_gallon = 378.541; //need to further refine US liquid measure constants
        double CV_quart = 94.635; //refine
        double CV_pint = 47.31756; //they come in pints? 47.318 
        double CV_gill = 11.8294; //refine  11.829
        double CV_boardfoot = 2359.737; //refine   
        double CV_fluidounce = 2.95735; //refine 2.957
        double CV_cup = 23.65883; //refine 23.659
        double CV_teaspoon = 0.492892; //refine  0.495
        double CV_tablespoon = 1.478677; //refine
        double CV_cubicinch = 1.638705; //refine 1.639
        double CV_fluiddram = 0.369669; //refine 0.36966
        double CV_minim = 0.00616115; //refine
        double CV_usbeerkeg = 5868.50; //refine

        //data constants
        double CV_yottabyte = 1000000000000000000000000.0;
        double CV_zettabyte = 1000000000000000000000.0;
        double CV_exabyte = 1000000000000000000.0;
        double CV_petabyte = 1000000000000000.0;
        double CV_terabyte = 1000000000000.0;
        double CV_gigabyte = 1000000000.0;
        double CV_megabyte = 1000000.0;
        double CV_kilobyte = 1000.0;
        double CV_byte = 1.0;
        double CV_bit = 0.125;


        private void computeConversion()
        {
            if ((cboLeftConvOp.SelectedItem != null) && (cboRightConvOp.SelectedItem != null))
            {
                //   Length   Mass   Volume
                String convType = cboConversionType.SelectedText;

                //get left val
                bool leftConv = double.TryParse(txtLeftConv.Text, out double leftConvVal);
                //get right val
                bool rightConv = double.TryParse(txtRightConv.Text, out double rightConvVal);

                String leftUnitType = cboLeftConvOp.SelectedItem.ToString();
                double leftUnitVal = getUnitVal(leftUnitType);
                //double leftMeterVal = leftConvVal * leftUnitVal;

                String rightUnitType = cboRightConvOp.SelectedItem.ToString();
                double rightUnitVal = getUnitVal(rightUnitType);
                //double rightMeterVal = rightConvVal * rightUnitVal;

                double unitQuotient = leftUnitVal / rightUnitVal;

                double finalVal = leftConvVal * unitQuotient;
                txtRightConv.Text = RoundDoubUp(finalVal).ToString();

                //RoundDoubUp(finalVal);
            }
        }

        private void cboConversionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String convType = cboConversionType.SelectedItem.ToString();
            if(convType.Equals("Length"))
            {
                cboLeftConvOp.Items.Clear();
                cboLeftConvOp.Items.Add("");
                cboLeftConvOp.Items.Add("mill");
                cboLeftConvOp.Items.Add("inch");
                cboLeftConvOp.Items.Add("foot");
                cboLeftConvOp.Items.Add("yard");
                cboLeftConvOp.Items.Add("mile");
                cboLeftConvOp.Items.Add("capefoot");
                cboLeftConvOp.Items.Add("rod");
                cboLeftConvOp.Items.Add("nanometer");
                cboLeftConvOp.Items.Add("micron");
                cboLeftConvOp.Items.Add("millimeter");
                cboLeftConvOp.Items.Add("centimeter");
                cboLeftConvOp.Items.Add("meter");
                cboLeftConvOp.Items.Add("kilometer");
                cboLeftConvOp.Items.Add("lightyear");
                cboLeftConvOp.Items.Add("parsec");
                cboLeftConvOp.Items.Add("lightday");
                cboLeftConvOp.Items.Add("lighthour");
                cboLeftConvOp.Items.Add("lightminute");
                cboLeftConvOp.Items.Add("lightsecond");
                cboLeftConvOp.SelectedIndex = 0;
                txtLeftConv.Text = "0";
                cboRightConvOp.Items.Clear();
                cboRightConvOp.Items.Add("");
                cboRightConvOp.Items.Add("mill");
                cboRightConvOp.Items.Add("inch");
                cboRightConvOp.Items.Add("foot");
                cboRightConvOp.Items.Add("yard");
                cboRightConvOp.Items.Add("mile");
                cboRightConvOp.Items.Add("capefoot");
                cboRightConvOp.Items.Add("rod");
                cboRightConvOp.Items.Add("nanometer");
                cboRightConvOp.Items.Add("micron");
                cboRightConvOp.Items.Add("millimeter");
                cboRightConvOp.Items.Add("centimeter");
                cboRightConvOp.Items.Add("meter");
                cboRightConvOp.Items.Add("kilometer");
                cboRightConvOp.Items.Add("lightyear");
                cboRightConvOp.Items.Add("parsec");
                cboRightConvOp.Items.Add("lightday");
                cboRightConvOp.Items.Add("lighthour");
                cboRightConvOp.Items.Add("lightminute");
                cboRightConvOp.Items.Add("lightsecond");
                cboRightConvOp.SelectedIndex = 0;
                txtRightConv.Text = "0";
            }

            if (convType.Equals("Mass"))
            {
                cboLeftConvOp.Items.Clear();
                cboLeftConvOp.Items.Add("");
                cboLeftConvOp.Items.Add("microgram");
                cboLeftConvOp.Items.Add("milligram");
                cboLeftConvOp.Items.Add("gram");
                cboLeftConvOp.Items.Add("kilogram");
                cboLeftConvOp.Items.Add("metricton");
                cboLeftConvOp.Items.Add("ounce");
                cboLeftConvOp.Items.Add("pound");
                cboLeftConvOp.Items.Add("ton");
                cboLeftConvOp.SelectedIndex = 0;
                txtLeftConv.Text = "0";
                cboRightConvOp.Items.Clear();
                cboRightConvOp.Items.Add("");
                cboRightConvOp.Items.Add("microgram");
                cboRightConvOp.Items.Add("milligram");
                cboRightConvOp.Items.Add("gram");
                cboRightConvOp.Items.Add("kilogram");
                cboRightConvOp.Items.Add("metricton");
                cboRightConvOp.Items.Add("ounce");
                cboRightConvOp.Items.Add("pound");
                cboRightConvOp.Items.Add("ton");
                cboRightConvOp.SelectedIndex = 0;
                txtRightConv.Text = "0";
            }

            if (convType.Equals("Volume"))
            {
                cboLeftConvOp.Items.Clear();
                cboLeftConvOp.Items.Add("");
                cboLeftConvOp.Items.Add("cubickilometer");
                cboLeftConvOp.Items.Add("cubicmeter");
                cboLeftConvOp.Items.Add("hectoliter");
                cboLeftConvOp.Items.Add("decaliter");
                cboLeftConvOp.Items.Add("liter");
                cboLeftConvOp.Items.Add("deciliter");
                cboLeftConvOp.Items.Add("centiliter");
                cboLeftConvOp.Items.Add("cubiccentimeter");
                cboLeftConvOp.Items.Add("milliliter");
                cboLeftConvOp.Items.Add("cubicmilliliter");
                cboLeftConvOp.Items.Add("microliter");
                cboLeftConvOp.Items.Add("gallon");
                cboLeftConvOp.Items.Add("quart");
                cboLeftConvOp.Items.Add("pint");
                cboLeftConvOp.Items.Add("gill");
                cboLeftConvOp.Items.Add("boardfoot");
                cboLeftConvOp.Items.Add("fluidounce");
                cboLeftConvOp.Items.Add("cup");
                cboLeftConvOp.Items.Add("teaspoon");
                cboLeftConvOp.Items.Add("tablespoon");
                cboLeftConvOp.Items.Add("cubicinch");
                cboLeftConvOp.Items.Add("fluiddram");
                cboLeftConvOp.Items.Add("minim");
                cboLeftConvOp.Items.Add("usbeerkeg");
                cboLeftConvOp.SelectedIndex = 0;
                txtLeftConv.Text = "0";
                cboRightConvOp.Items.Clear();
                cboRightConvOp.Items.Add("");
                cboRightConvOp.Items.Add("cubickilometer");
                cboRightConvOp.Items.Add("cubicmeter");
                cboRightConvOp.Items.Add("hectoliter");
                cboRightConvOp.Items.Add("decaliter");
                cboRightConvOp.Items.Add("liter");
                cboRightConvOp.Items.Add("deciliter");
                cboRightConvOp.Items.Add("centiliter");
                cboRightConvOp.Items.Add("cubiccentimeter");
                cboRightConvOp.Items.Add("milliliter");
                cboRightConvOp.Items.Add("cubicmilliliter");
                cboRightConvOp.Items.Add("microliter");
                cboRightConvOp.Items.Add("gallon");
                cboRightConvOp.Items.Add("quart");
                cboRightConvOp.Items.Add("pint");
                cboRightConvOp.Items.Add("gill");
                cboRightConvOp.Items.Add("boardfoot");
                cboRightConvOp.Items.Add("fluidounce");
                cboRightConvOp.Items.Add("cup");
                cboRightConvOp.Items.Add("teaspoon");
                cboRightConvOp.Items.Add("tablespoon");
                cboRightConvOp.Items.Add("cubicinch");
                cboRightConvOp.Items.Add("fluiddram");
                cboRightConvOp.Items.Add("minim");
                cboRightConvOp.Items.Add("usbeerkeg");
                cboRightConvOp.SelectedIndex = 0;
                txtRightConv.Text = "0";
            }

            if (convType.Equals("Data"))
            {
                cboLeftConvOp.Items.Clear();
                cboLeftConvOp.Items.Add("");
                cboLeftConvOp.Items.Add("bit");
                cboLeftConvOp.Items.Add("byte");
                cboLeftConvOp.Items.Add("kilobyte");
                cboLeftConvOp.Items.Add("megabyte");
                cboLeftConvOp.Items.Add("gigabyte");
                cboLeftConvOp.Items.Add("terabyte");
                cboLeftConvOp.Items.Add("petabyte");
                cboLeftConvOp.Items.Add("exabyte");
                cboLeftConvOp.Items.Add("zettabyte");
                cboLeftConvOp.Items.Add("yottabyte");
                cboLeftConvOp.SelectedIndex = 0;
                txtLeftConv.Text = "0";
                cboRightConvOp.Items.Clear();
                cboRightConvOp.Items.Add("");
                cboRightConvOp.Items.Add("bit");
                cboRightConvOp.Items.Add("byte");
                cboRightConvOp.Items.Add("kilobyte");
                cboRightConvOp.Items.Add("megabyte");
                cboRightConvOp.Items.Add("gigabyte");
                cboRightConvOp.Items.Add("terabyte");
                cboRightConvOp.Items.Add("petabyte");
                cboRightConvOp.Items.Add("exabyte");
                cboRightConvOp.Items.Add("zettabyte");
                cboRightConvOp.Items.Add("yottabyte");
                cboRightConvOp.SelectedIndex = 0;
                txtRightConv.Text = "0";
            }
        }

        private String CommaString(String inStr)
        {
            String commaStr = inStr;
            /*
            //get string to left of .
            int perloc = commaStr.IndexOf('.');
            if (commaStr.Contains('.'))
            {

            }
            else
            {
                perloc = 0;
            }
                //int perloc = commaStr.IndexOf('.');
                String leftSide = commaStr.Substring(0, commaStr.Length - perloc);
                int leftlen = leftSide.Length;
                if (leftlen > 3)
                {
                    commaStr = commaStr.Insert(leftSide.Length - 3, ",");
                }
                if (leftlen > 6)
                {
                    commaStr = commaStr.Insert(leftSide.Length - 6, ",");
                }
                if (leftlen > 9)
                {
                    commaStr = commaStr.Insert(leftSide.Length - 9, ",");
                }
                if (leftlen > 12)
                {
                    commaStr = commaStr.Insert(leftSide.Length - 12, ",");
                }
            */
            return commaStr;
        }

        private void TxtRightConv_TextChanged(object sender, EventArgs e)
        {
            //String newText = CommaString(txtRightConv.Text);
            //txtRightConv.Text = newText;
        }

        private double RoundDoubUp(double dRnd)
        {
            double roundedDoub = dRnd;
            String dStr = dRnd.ToString();
            if (dStr.Contains('.'))
            {                
                int decloc = dStr.IndexOf('.');
                if (dStr.Length > 6)
                {
                    //count number of chars after . (if < 4, no go)
                    if (dStr.Length - decloc < 4)
                    {

                    }
                    else
                    {
                        //get 4 numbers after the decimal point, if all are 9, then round up the double.
                        String nines = dStr.Substring(decloc + 1, 4);
                        if ((nines != null) && (nines.StartsWith("9999")))
                        {
                            roundedDoub = Math.Ceiling(dRnd * 100) / 100;
                        }
                        else
                        {

                        }
                    }
                }
            }
            return roundedDoub;
        }

        public bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            isDouble = Double.TryParse(text, out num);
            return isDouble;
        }

        private void txtLeftConv_TextChanged(object sender, EventArgs e)
        {
            computeConversion();
        }

        private void cboLeftConvOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            computeConversion();
        }

        private void cboRightConvOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            computeConversion();
        }

        private double getUnitVal (String st)
        {
            double returnNum = 0.0;
            switch(st)
            {
                //length
                case "mill":
                    returnNum = CV_mill;
                    break;
                case "inch":
                    returnNum = CV_inch;
                    break;
                case "foot":
                    returnNum = CV_foot;
                    break;
                case "yard":
                    returnNum = CV_yard;
                    break;
                case "mile":
                    returnNum = CV_mile;
                    break;
                case "capefoot":
                    returnNum = CV_capefoot;
                    break;
                case "rod":
                    returnNum = CV_rod;
                    break;
                case "nanometer":
                    returnNum = CV_nanometer;
                    break;
                case "micron":
                    returnNum = CV_micron;
                    break;
                case "millimeter":
                    returnNum = CV_millimeter;
                    break;
                case "centimeter":
                    returnNum = CV_centimeter;
                    break;
                case "meter":
                    returnNum = CV_meter;
                    break;
                case "kilometer":
                    returnNum = CV_kilometer;
                    break;
                case "lightyear":
                    returnNum = CV_lightyear;
                    break;
                case "parsec":
                    returnNum = CV_parsec;
                    break;
                case "lightday":
                    returnNum = CV_lightday;
                    break;
                case "lighthour":
                    returnNum = CV_lighthour;
                    break;
                case "lightminute":
                    returnNum = CV_lightminute;
                    break;
                case "lightsecond":
                    returnNum = CV_lightsecond;
                    break;
                //mass
                case "microgram":
                    returnNum = CV_microgram;
                    break;
                case "milligram":
                    returnNum = CV_milligram;
                    break;
                case "gram":
                    returnNum = CV_gram;
                    break;
                case "kilogram":
                    returnNum = CV_kilogram;
                    break;
                case "metricton":
                    returnNum = CV_metricton;
                    break;
                case "ounce":
                    returnNum = CV_ounce;
                    break;
                case "pound":
                    returnNum = CV_pound;
                    break;
                case "ton":
                    returnNum = CV_ton;
                    break;
                //volume
                case "cubickilometer":
                    returnNum = CV_cubickilometer;
                    break;
                case "cubicmeter":
                    returnNum = CV_cubicmeter;
                    break;
                case "hectoliter":
                    returnNum = CV_hectoliter;
                    break;
                case "decaliter":
                    returnNum = CV_decaliter;
                    break;
                case "liter":
                    returnNum = CV_liter;
                    break;
                case "deciliter":
                    returnNum = CV_deciliter;
                    break;
                case "centiliter":
                    returnNum = CV_centiliter;
                    break;
                case "cubiccentimeter":
                    returnNum = CV_cubiccentimeter;
                    break;
                case "milliliter":
                    returnNum = CV_milliliter;
                    break;
                case "cubicmilliliter":
                    returnNum = CV_cubicmilliliter;
                    break;
                case "microliter":
                    returnNum = CV_microliter;
                    break;
                case "gallon":
                    returnNum = CV_gallon;
                    break;
                case "quart":
                    returnNum = CV_quart;
                    break;
                case "pint":
                    returnNum = CV_pint;
                    break;
                case "gill":
                    returnNum = CV_gill;
                    break;
                case "boardfoot":
                    returnNum = CV_boardfoot;
                    break;
                case "fluidounce":
                    returnNum = CV_fluidounce;
                    break;
                case "cup":
                    returnNum = CV_cup;
                    break;
                case "teaspoon":
                    returnNum = CV_teaspoon;
                    break;
                case "tablespoon":
                    returnNum = CV_tablespoon;
                    break;
                case "cubicinch":
                    returnNum = CV_cubicinch;
                    break;
                case "fluiddram":
                    returnNum = CV_fluiddram;
                    break;
                case "minim":
                    returnNum = CV_minim;
                    break;
                case "usbeerkeg":
                    returnNum = CV_usbeerkeg;
                    break;
                //data
                case "bit":
                    returnNum = CV_bit;
                    break;
                case "byte":
                    returnNum = CV_byte;
                    break;
                case "kilobyte":
                    returnNum = CV_kilobyte;
                    break;
                case "megabyte":
                    returnNum = CV_megabyte;
                    break;
                case "gigabyte":
                    returnNum = CV_gigabyte;
                    break;
                case "terabyte":
                    returnNum = CV_terabyte;
                    break;
                case "petabyte":
                    returnNum = CV_petabyte;
                    break;
                case "exabyte":
                    returnNum = CV_exabyte;
                    break;
                case "zettabyte":
                    returnNum = CV_zettabyte;
                    break;
                case "yottabyte":
                    returnNum = CV_yottabyte;
                    break;
            }
            return returnNum;
        }

 /////////////////////////////////////////////////////////////////////////////////////////////////////////
 // TextBox Caret Fader
 //
 /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private CustomTextBox GetCurrentTB()
        {
            CustomTextBox currentTxt = txtLeftVal;
            if (txtLeftVal.Focused)
            {
                currentTxt = txtLeftVal;
            }
            if (txtRightVal.Focused)
            {
                currentTxt = txtRightVal;
            }
            if (txtResult.Focused)
            {
                currentTxt = txtResult;
            }
            if (txtExampleTB.Focused)
            {
                currentTxt = txtExampleTB;
            }
            return currentTxt;
        }

        //caret fade
        private void tmCaretFade_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("caret fade tick");
            caretFadeAmount = Convert.ToInt32(Math.Round(numCaretFade.Value, 0));
            //CustomTextBox currentTxt = GetCurrentTB();
            CustomTextBox currentTxt = txtLeftVal;
            if (txtLeftVal.Focused)
            {
                currentTxt = txtLeftVal;
            }
            if (txtRightVal.Focused)
            {
                currentTxt = txtRightVal;
            }
            if (txtResult.Focused)
            {
                currentTxt = txtResult;
            }
            if (txtExampleTB.Focused)
            {
                currentTxt = txtExampleTB;
            }
            if (cOp < 0) { cOp = 255; }
            cOp = cOp - caretFadeAmount;
            currentTxt.UpdateCaretOpacity(cOp);
        }

        private void chkCaretFade_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCaretFade.Checked)
            {
                tmCaretFade.Enabled = true;
            }
            else
            {
                //turn off fade and set back to full op
                tmCaretFade.Enabled = false;
                //CustomTextBox currentTxt = GetCurrentTB();
                CustomTextBox currentTxt = txtLeftVal;
                if (txtLeftVal.Focused)
                {
                    currentTxt = txtLeftVal;
                }
                if (txtRightVal.Focused)
                {
                    currentTxt = txtRightVal;
                }
                if (txtResult.Focused)
                {
                    currentTxt = txtResult;
                }
                if (txtExampleTB.Focused)
                {
                    currentTxt = txtExampleTB;
                }
                currentTxt.UpdateCaretOpacity(255);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if(pnlSettings.Visible)
            {
                //already visible, hide it
                pnlSettings.Visible = false;
                pnlSettings.Location = new Point(5, 185);
                txtLeftVal.Focus();
            }
            else
            {
                //not visible, show it
                pnlSettings.Location = new Point(5, 3);
                pnlSettings.Visible = true;
                txtExampleTB.Focus();
            }
        }

        private void numCaretFade_ValueChanged(object sender, EventArgs e)
        {
            //txtExampleTB.Focus();
            int cval = Convert.ToInt32(Math.Round(numCaretFade.Value, 0));
            //int cval = Int32.Parse(numCaretFade.Value.ToString());
            Properties.Settings.Default.fadeSpeed = cval;
            Properties.Settings.Default.Save();
        }

        private void btnCaretFadeTest_MouseEnter(object sender, EventArgs e)
        {
            txtExampleTB.Focus();
        }

        private void btnCaretFadeTest_Click(object sender, EventArgs e)
        {
            txtExampleTB.Focus();
        }

        private void tkColor1R_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor1R.Text = tkColor1R.Value.ToString();

            //set properties
            String col1 = tkColor1R.Value + "," + tkColor1G.Value + "," + tkColor1B.Value;
            Properties.Settings.Default.cColor1 = col1;
            Properties.Settings.Default.Save();
        }

        private void tkColor1G_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor1G.Text = tkColor1G.Value.ToString();

            //set properties
            String col1 = tkColor1R.Value + "," + tkColor1G.Value + "," + tkColor1B.Value;
            Properties.Settings.Default.cColor1 = col1;
            Properties.Settings.Default.Save();
        }

        private void tkColor1B_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor1B.Text = tkColor1B.Value.ToString();

            //set properties
            String col1 = tkColor1R.Value + "," + tkColor1G.Value + "," + tkColor1B.Value;
            Properties.Settings.Default.cColor1 = col1;
            Properties.Settings.Default.Save();
        }

        private void tkColor2R_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor2R.Text = tkColor2R.Value.ToString();

            //set properties
            String col2 = tkColor2R.Value + "," + tkColor2G.Value + "," + tkColor2B.Value;
            Properties.Settings.Default.cColor2 = col2;
            Properties.Settings.Default.Save();
        }

        private void tkColor2G_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor2G.Text = tkColor2G.Value.ToString();

            //set properties
            String col2 = tkColor2R.Value + "," + tkColor2G.Value + "," + tkColor2B.Value;
            Properties.Settings.Default.cColor2 = col2;
            Properties.Settings.Default.Save();
        }

        private void tkColor2B_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor2B.Text = tkColor2B.Value.ToString();

            //set properties
            String col2 = tkColor2R.Value + "," + tkColor2G.Value + "," + tkColor2B.Value;
            Properties.Settings.Default.cColor2 = col2;
            Properties.Settings.Default.Save();
        }

        private void colorWheelz1_ColorChanged(object sender, EventArgs e)
        {
            Color resultColor = colorWheelz1.Color.ToColor();
            btnResultColor.BackColor = colorWheelz1.Color.ToColor();
            txtResult.BackColor = resultColor;

            String rescol = resultColor.R + "," + resultColor.G + "," + resultColor.B;
            Properties.Settings.Default.resultColor = rescol;
            Properties.Settings.Default.Save();
        }


    }
}
