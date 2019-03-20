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
 * 3/19/2019
 * v 1.04
 */

namespace quickcalculator
{
    public partial class mainForm : Form
    {
        int cOp = 255;
        int caretFadeAmount = 40;

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
        }

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
                if (lastChar.Equals("+") || lastChar.Equals("-") || lastChar.Equals("*") || lastChar.Equals("/"))
                {
                    txtLeftVal.Text = txtLeftVal.Text.Substring(0, txtLeftVal.Text.Length - 1);
                }
            }
        }

        private void txtRightVal_TextChanged(object sender, EventArgs e)
        {
            updateCalculation();
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
                    if (isNumeric)
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
                rbOperatorSub.Checked = true;
                txtRightVal.Focus();
                txtRightVal.SelectAll();
                //Console.WriteLine("subtract pressed");
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
 
        //length conversion constants
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

        private void txtLeftConv_TextChanged(object sender, EventArgs e)
        {
            if((cboLeftConvOp.SelectedItem != null) && (cboRightConvOp.SelectedItem != null))
            {
                //get left val
                bool leftConv = double.TryParse(txtLeftConv.Text, out double leftConvVal);
                //get right val
                bool rightConv = double.TryParse(txtRightConv.Text, out double rightConvVal);

                //MessageBox.Show(cboLeftConvOp.SelectedItem.ToString());
                String leftValUnit = cboLeftConvOp.SelectedItem.ToString();
                double leftUnitVal = getUnitVal(leftValUnit);
                double leftMeterVal = leftConvVal * leftUnitVal;
                //MessageBox.Show(leftMeterVal.ToString());

                String rightValUnit = cboRightConvOp.SelectedItem.ToString();
                double rightUnitVal = getUnitVal(rightValUnit);
                double rightMeterVal = rightConvVal * rightUnitVal;

                double unitQuotient = leftUnitVal / rightUnitVal;

                double finalVal = leftConvVal * unitQuotient;
                txtRightConv.Text = finalVal.ToString();
            }
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
    }
}
