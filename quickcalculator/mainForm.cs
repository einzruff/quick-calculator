using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Quick Calculator
 * by Daphne Lundquist
 * 3/9/2019
 * v 1.01
 */

namespace quickcalculator
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void txtLeftVal_TextChanged(object sender, EventArgs e)
        {
            updateCalculation();
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
                        timer1.Enabled = false;
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
                        timer1.Enabled = true;
                        lblInfo.Text = "Error: non-numeric value detected.";
                    }
                }
            }
            else
            {
                lblInfo.Text = "...";
                lblInfo.ForeColor = Color.Black;
                timer1.Enabled = false;
            }
        }


        private void txtLeftVal_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void mainForm_Load(object sender, EventArgs e)
        {
            cboResultOp.SelectedIndex = 0;
            cboConversionType.SelectedIndex = 0;
            rbOperatorMult.Select();
            this.ActiveControl = txtLeftVal;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //change lblInfo text color
            Random rnd = new Random();
            lblInfo.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

 /// <summary>
 /// ///////////////////////////////////////////////////////////////////////////////////////
 /// </summary>

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
    }
}
