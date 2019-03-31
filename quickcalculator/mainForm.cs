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
 * 3/30/2019
 * v 1.0.6
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

            //t1mCaret
            tmCaretFade.Enabled = true;

            //set caret fade button colors (settings)
            //btnCFadeColor1.BackColor = Color.FromArgb(255, 255, 0, 0);
            //btnCFadeColor2.BackColor = Color.FromArgb(255, 255, 255, 0);
            //LinearGradientBrush brush = new LinearGradientBrush(0, 20, Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 255, 255, 0));
            //Bitmap bb = gradientTest(btnCFadeFin.ClientRectangle, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 255, 255));
            //btnCFadeFin.BackgroundImage = bb;

            //set Color Wheel initial color of Color.CadetBlue
            Color cbRGB = Color.CadetBlue;
            ColorRgb cwRGBInit = new ColorRgb(cbRGB.R, cbRGB.G, cbRGB.B);
            ColorHsv cwHSVInit = (ColorHsv)cwRGBInit.ToHsv();
            colorWheelz1.Color = cwHSVInit;

            //set initial conversion units
            cboLeftConvOp.SelectedIndex = 2; //inch
            cboRightConvOp.SelectedIndex = 3; //foot
            txtLeftConv.Text = "12";

            this.rbSelRect.Image = this.DrawRBRect(20, 20);
            this.rbSelTriangle.Image = this.DrawRBTriangle(20, 20);

            //start testForm for debugging
            //testForm tf = new testForm();
            //tf.Show();
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

        //concentration solution constants
        /*double CV_kilogramliter = 1;
        double CV_gramliter = 0.001;
        double CV_kilogrammetercubed = 0.001;
        double CV_gramcubicmeter = 1.0E-6;
        double CV_microgramcubicmeter = 1.0E-9;
        double CV_gramcubiccentimeter = 1;
        double CV_milligramliter = 1.0E-6;
        double CV_milligrammilliliter = 0.001;
        double CV_milligramteaspoon= 0.005;
        double CV_milligramnanoliter = 1;
        double CV_picogrammilliliter = 1.0E-9;
        double CV_picogramliter = 1.0E-6;
        double CV_picogramdeciliter = 1.0E-12;
        double CV_microgrammilliliter = 1.0E-15;
        double CV_microgramdeciliter = 1.0E-11;
        double CV_microgramliter = 1.0E-6;
        double CV_nanogramliter = 1.0E-8;
        double CV_nanogramdeciliter = 1.0E-9;
        double CV_nanogrammilliliter = 1.0E-12;
        double CV_gramdeciliter = 1.0E-11;
        double CV_milligramdeciliter = 1.0E-9;
        double CV_toncubicmeter = 0.01;
        double CV_poundcubicyard = 1.0E-5;
        double CV_poundgallonuk = 1;
        double CV_poundcubicfoot = 0.00059327642110147;
        double CV_poundgallonus = 0.099776397913856;
        double CV_ouncecubicinch = 0.01601846336974;
        double CV_ouncecubicfoot = 0.11982642730074;
        double CV_ouncecubicyard = 1.7299940439319;
        double CV_toncubicyard = 0.0010011539606087;
        double CV_poundcubicinch = 3.7079776318842E-5;
        double CV_percentage = 1.3078733978551;
        double CV_partpermillion= 27.67990470291;
        double CV_partperbillion = 0.01;
        double CV_partpertrillion = 1.0E-6;
        double CV_slugcubicfoot = 1.0E-9;
        double CV_slugcubicinch = 1.0E-15;
        double CV_slugcubicyard = 0.51537881852553;
        // = 55.660912400758;
        // = 0.019088104389835;
        */

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
                txtRightConv.Text = finalVal.ToString();
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
        }

        private void tkColor1G_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor1G.Text = tkColor1G.Value.ToString();
        }

        private void tkColor1B_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor1B.Text = tkColor1B.Value.ToString();
        }

        private void tkColor2R_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor2R.Text = tkColor2R.Value.ToString();
        }

        private void tkColor2G_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor2G.Text = tkColor2G.Value.ToString();
        }

        private void tkColor2B_ValueChanged(object sender, EventArgs e)
        {
            txtLeftVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtRightVal.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtResult.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtExampleTB.changeColors(tkColor1R.Value, tkColor1G.Value, tkColor1B.Value, tkColor2R.Value, tkColor2G.Value, tkColor2B.Value);
            txtColor2B.Text = tkColor2B.Value.ToString();
        }

        private void colorWheelz1_ColorChanged(object sender, EventArgs e)
        {
            Color resultColor = colorWheelz1.Color.ToColor();
            btnResultColor.BackColor = colorWheelz1.Color.ToColor();
            txtResult.BackColor = resultColor;
        }


    }
}
