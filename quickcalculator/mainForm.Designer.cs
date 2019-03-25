namespace quickcalculator
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboCopyResult = new System.Windows.Forms.CheckBox();
            this.cboClearLeft = new System.Windows.Forms.CheckBox();
            this.rbOperatorMult = new System.Windows.Forms.RadioButton();
            this.rbOperatorPlus = new System.Windows.Forms.RadioButton();
            this.rbOperatorSub = new System.Windows.Forms.RadioButton();
            this.rbOperatorDiv = new System.Windows.Forms.RadioButton();
            this.lblEquals = new System.Windows.Forms.Label();
            this.cboResultOp = new System.Windows.Forms.ComboBox();
            this.btnCopyLeftVal = new System.Windows.Forms.Button();
            this.btnCopyRightVal = new System.Windows.Forms.Button();
            this.btnCopyResult = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboClearResult = new System.Windows.Forms.CheckBox();
            this.cboClearRight = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tmInfo = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkCaretFade = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboConversionType = new System.Windows.Forms.ComboBox();
            this.cboLeftConvOp = new System.Windows.Forms.ComboBox();
            this.lblConvEquals = new System.Windows.Forms.Label();
            this.cboRightConvOp = new System.Windows.Forms.ComboBox();
            this.txtRightConv = new System.Windows.Forms.TextBox();
            this.txtLeftConv = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tmCaretFade = new System.Windows.Forms.Timer(this.components);
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.txtColor2B = new System.Windows.Forms.TextBox();
            this.txtColor2G = new System.Windows.Forms.TextBox();
            this.txtColor2R = new System.Windows.Forms.TextBox();
            this.txtColor1B = new System.Windows.Forms.TextBox();
            this.txtColor1G = new System.Windows.Forms.TextBox();
            this.txtColor1R = new System.Windows.Forms.TextBox();
            this.tkColor2B = new System.Windows.Forms.TrackBar();
            this.tkColor2G = new System.Windows.Forms.TrackBar();
            this.tkColor2R = new System.Windows.Forms.TrackBar();
            this.tkColor1B = new System.Windows.Forms.TrackBar();
            this.tkColor1G = new System.Windows.Forms.TrackBar();
            this.tkColor1R = new System.Windows.Forms.TrackBar();
            this.btnCFadeFin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCFadeColor2 = new System.Windows.Forms.Button();
            this.btnCFadeColor1 = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnCaretFadeTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numCaretFade = new System.Windows.Forms.NumericUpDown();
            this.lblSettingsHL = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResultColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.colorWheelz1 = new quickcalculator.ColorWheelz();
            this.txtExampleTB = new quickcalculator.CustomTextBox();
            this.txtResult = new quickcalculator.CustomTextBox();
            this.txtRightVal = new quickcalculator.CustomTextBox();
            this.txtLeftVal = new quickcalculator.CustomTextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor2B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor2G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor2R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor1B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor1G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor1R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCaretFade)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCopyResult
            // 
            this.cboCopyResult.AutoSize = true;
            this.cboCopyResult.Checked = true;
            this.cboCopyResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboCopyResult.Location = new System.Drawing.Point(13, 44);
            this.cboCopyResult.Name = "cboCopyResult";
            this.cboCopyResult.Size = new System.Drawing.Size(136, 17);
            this.cboCopyResult.TabIndex = 11;
            this.cboCopyResult.Text = "Copy result to clipboard";
            this.cboCopyResult.UseVisualStyleBackColor = true;
            // 
            // cboClearLeft
            // 
            this.cboClearLeft.AutoSize = true;
            this.cboClearLeft.Checked = true;
            this.cboClearLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboClearLeft.Location = new System.Drawing.Point(13, 19);
            this.cboClearLeft.Name = "cboClearLeft";
            this.cboClearLeft.Size = new System.Drawing.Size(96, 17);
            this.cboClearLeft.TabIndex = 8;
            this.cboClearLeft.Text = "Clear left value";
            this.cboClearLeft.UseVisualStyleBackColor = true;
            // 
            // rbOperatorMult
            // 
            this.rbOperatorMult.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOperatorMult.Location = new System.Drawing.Point(175, 5);
            this.rbOperatorMult.Margin = new System.Windows.Forms.Padding(1);
            this.rbOperatorMult.Name = "rbOperatorMult";
            this.rbOperatorMult.Size = new System.Drawing.Size(20, 20);
            this.rbOperatorMult.TabIndex = 3;
            this.rbOperatorMult.TabStop = true;
            this.rbOperatorMult.Text = "x";
            this.rbOperatorMult.UseVisualStyleBackColor = true;
            // 
            // rbOperatorPlus
            // 
            this.rbOperatorPlus.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOperatorPlus.Location = new System.Drawing.Point(195, 5);
            this.rbOperatorPlus.Margin = new System.Windows.Forms.Padding(1);
            this.rbOperatorPlus.Name = "rbOperatorPlus";
            this.rbOperatorPlus.Size = new System.Drawing.Size(20, 20);
            this.rbOperatorPlus.TabIndex = 4;
            this.rbOperatorPlus.TabStop = true;
            this.rbOperatorPlus.Text = "+";
            this.rbOperatorPlus.UseVisualStyleBackColor = true;
            // 
            // rbOperatorSub
            // 
            this.rbOperatorSub.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOperatorSub.Location = new System.Drawing.Point(175, 24);
            this.rbOperatorSub.Margin = new System.Windows.Forms.Padding(1);
            this.rbOperatorSub.Name = "rbOperatorSub";
            this.rbOperatorSub.Size = new System.Drawing.Size(20, 20);
            this.rbOperatorSub.TabIndex = 5;
            this.rbOperatorSub.TabStop = true;
            this.rbOperatorSub.Text = "-";
            this.rbOperatorSub.UseVisualStyleBackColor = true;
            // 
            // rbOperatorDiv
            // 
            this.rbOperatorDiv.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOperatorDiv.Location = new System.Drawing.Point(195, 24);
            this.rbOperatorDiv.Margin = new System.Windows.Forms.Padding(1);
            this.rbOperatorDiv.Name = "rbOperatorDiv";
            this.rbOperatorDiv.Size = new System.Drawing.Size(20, 20);
            this.rbOperatorDiv.TabIndex = 6;
            this.rbOperatorDiv.TabStop = true;
            this.rbOperatorDiv.Text = "/";
            this.rbOperatorDiv.UseVisualStyleBackColor = true;
            // 
            // lblEquals
            // 
            this.lblEquals.AutoSize = true;
            this.lblEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquals.Location = new System.Drawing.Point(380, 10);
            this.lblEquals.Name = "lblEquals";
            this.lblEquals.Size = new System.Drawing.Size(24, 25);
            this.lblEquals.TabIndex = 14;
            this.lblEquals.Text = "=";
            // 
            // cboResultOp
            // 
            this.cboResultOp.BackColor = System.Drawing.Color.Gainsboro;
            this.cboResultOp.DropDownHeight = 120;
            this.cboResultOp.DropDownWidth = 10;
            this.cboResultOp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboResultOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboResultOp.FormattingEnabled = true;
            this.cboResultOp.IntegralHeight = false;
            this.cboResultOp.Items.AddRange(new object[] {
            " ",
            "$",
            "%"});
            this.cboResultOp.Location = new System.Drawing.Point(168, 47);
            this.cboResultOp.MaxLength = 2;
            this.cboResultOp.Name = "cboResultOp";
            this.cboResultOp.Size = new System.Drawing.Size(47, 33);
            this.cboResultOp.TabIndex = 7;
            // 
            // btnCopyLeftVal
            // 
            this.btnCopyLeftVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyLeftVal.Location = new System.Drawing.Point(9, 5);
            this.btnCopyLeftVal.Name = "btnCopyLeftVal";
            this.btnCopyLeftVal.Size = new System.Drawing.Size(15, 36);
            this.btnCopyLeftVal.TabIndex = 16;
            this.btnCopyLeftVal.Text = "Copy";
            this.btnCopyLeftVal.UseVisualStyleBackColor = true;
            this.btnCopyLeftVal.Click += new System.EventHandler(this.btnCopyLeftVal_Click);
            // 
            // btnCopyRightVal
            // 
            this.btnCopyRightVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyRightVal.Location = new System.Drawing.Point(367, 5);
            this.btnCopyRightVal.Name = "btnCopyRightVal";
            this.btnCopyRightVal.Size = new System.Drawing.Size(15, 36);
            this.btnCopyRightVal.TabIndex = 17;
            this.btnCopyRightVal.Text = "Copy";
            this.btnCopyRightVal.UseVisualStyleBackColor = true;
            this.btnCopyRightVal.Click += new System.EventHandler(this.btnCopyRightVal_Click);
            // 
            // btnCopyResult
            // 
            this.btnCopyResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyResult.Location = new System.Drawing.Point(367, 46);
            this.btnCopyResult.Name = "btnCopyResult";
            this.btnCopyResult.Size = new System.Drawing.Size(15, 36);
            this.btnCopyResult.TabIndex = 18;
            this.btnCopyResult.Text = "Copy";
            this.btnCopyResult.UseVisualStyleBackColor = true;
            this.btnCopyResult.Click += new System.EventHandler(this.btnCopyResult_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboClearResult);
            this.groupBox1.Controls.Add(this.cboClearRight);
            this.groupBox1.Controls.Add(this.cboClearLeft);
            this.groupBox1.Controls.Add(this.cboCopyResult);
            this.groupBox1.Location = new System.Drawing.Point(11, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 70);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "on Enter key";
            // 
            // cboClearResult
            // 
            this.cboClearResult.AutoSize = true;
            this.cboClearResult.Location = new System.Drawing.Point(244, 19);
            this.cboClearResult.Name = "cboClearResult";
            this.cboClearResult.Size = new System.Drawing.Size(78, 17);
            this.cboClearResult.TabIndex = 10;
            this.cboClearResult.Text = "Clear result";
            this.cboClearResult.UseVisualStyleBackColor = true;
            // 
            // cboClearRight
            // 
            this.cboClearRight.AutoSize = true;
            this.cboClearRight.Location = new System.Drawing.Point(131, 19);
            this.cboClearRight.Name = "cboClearRight";
            this.cboClearRight.Size = new System.Drawing.Size(102, 17);
            this.cboClearRight.TabIndex = 9;
            this.cboClearRight.Text = "Clear right value";
            this.cboClearRight.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(14, 155);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(23, 17);
            this.lblInfo.TabIndex = 21;
            this.lblInfo.Text = "...";
            // 
            // tmInfo
            // 
            this.tmInfo.Tick += new System.EventHandler(this.tmInfo_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 207);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.txtResult);
            this.tabPage1.Controls.Add(this.txtRightVal);
            this.tabPage1.Controls.Add(this.txtLeftVal);
            this.tabPage1.Controls.Add(this.lblInfo);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCopyResult);
            this.tabPage1.Controls.Add(this.rbOperatorMult);
            this.tabPage1.Controls.Add(this.btnCopyRightVal);
            this.tabPage1.Controls.Add(this.rbOperatorPlus);
            this.tabPage1.Controls.Add(this.btnCopyLeftVal);
            this.tabPage1.Controls.Add(this.rbOperatorSub);
            this.tabPage1.Controls.Add(this.cboResultOp);
            this.tabPage1.Controls.Add(this.rbOperatorDiv);
            this.tabPage1.Controls.Add(this.lblEquals);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(421, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Calculator";
            // 
            // chkCaretFade
            // 
            this.chkCaretFade.AutoSize = true;
            this.chkCaretFade.Checked = true;
            this.chkCaretFade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaretFade.Location = new System.Drawing.Point(6, 22);
            this.chkCaretFade.Name = "chkCaretFade";
            this.chkCaretFade.Size = new System.Drawing.Size(78, 17);
            this.chkCaretFade.TabIndex = 12;
            this.chkCaretFade.Text = "Caret Fade";
            this.chkCaretFade.UseVisualStyleBackColor = true;
            this.chkCaretFade.CheckedChanged += new System.EventHandler(this.chkCaretFade_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.cboConversionType);
            this.tabPage2.Controls.Add(this.cboLeftConvOp);
            this.tabPage2.Controls.Add(this.lblConvEquals);
            this.tabPage2.Controls.Add(this.cboRightConvOp);
            this.tabPage2.Controls.Add(this.txtRightConv);
            this.tabPage2.Controls.Add(this.txtLeftConv);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(421, 181);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Converter";
            // 
            // cboConversionType
            // 
            this.cboConversionType.FormattingEnabled = true;
            this.cboConversionType.Items.AddRange(new object[] {
            "Length"});
            this.cboConversionType.Location = new System.Drawing.Point(6, 5);
            this.cboConversionType.Name = "cboConversionType";
            this.cboConversionType.Size = new System.Drawing.Size(144, 21);
            this.cboConversionType.TabIndex = 23;
            // 
            // cboLeftConvOp
            // 
            this.cboLeftConvOp.BackColor = System.Drawing.Color.Gainsboro;
            this.cboLeftConvOp.DropDownHeight = 120;
            this.cboLeftConvOp.DropDownWidth = 10;
            this.cboLeftConvOp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLeftConvOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLeftConvOp.FormattingEnabled = true;
            this.cboLeftConvOp.IntegralHeight = false;
            this.cboLeftConvOp.Items.AddRange(new object[] {
            " ",
            "mill",
            "inch",
            "foot",
            "yard",
            "mile",
            "capefoot",
            "rod",
            "nanometer",
            "micron",
            "millimeter",
            "centimeter",
            "meter",
            "kilometer",
            "lightyear",
            "lightday",
            "lighthour",
            "lightminute",
            "lightsecond"});
            this.cboLeftConvOp.Location = new System.Drawing.Point(202, 31);
            this.cboLeftConvOp.MaxLength = 2;
            this.cboLeftConvOp.Name = "cboLeftConvOp";
            this.cboLeftConvOp.Size = new System.Drawing.Size(148, 33);
            this.cboLeftConvOp.TabIndex = 23;
            this.cboLeftConvOp.SelectedIndexChanged += new System.EventHandler(this.cboLeftConvOp_SelectedIndexChanged);
            // 
            // lblConvEquals
            // 
            this.lblConvEquals.AutoSize = true;
            this.lblConvEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvEquals.Location = new System.Drawing.Point(350, 35);
            this.lblConvEquals.Name = "lblConvEquals";
            this.lblConvEquals.Size = new System.Drawing.Size(24, 25);
            this.lblConvEquals.TabIndex = 24;
            this.lblConvEquals.Text = "=";
            // 
            // cboRightConvOp
            // 
            this.cboRightConvOp.BackColor = System.Drawing.Color.Gainsboro;
            this.cboRightConvOp.DropDownHeight = 120;
            this.cboRightConvOp.DropDownWidth = 10;
            this.cboRightConvOp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRightConvOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRightConvOp.FormattingEnabled = true;
            this.cboRightConvOp.IntegralHeight = false;
            this.cboRightConvOp.Items.AddRange(new object[] {
            " ",
            "mill",
            "inch",
            "foot",
            "yard",
            "mile",
            "capefoot",
            "rod",
            "nanometer",
            "micron",
            "millimeter",
            "centimeter",
            "meter",
            "kilometer",
            "lightyear",
            "lightday",
            "lighthour",
            "lightminute",
            "lightsecond"});
            this.cboRightConvOp.Location = new System.Drawing.Point(202, 70);
            this.cboRightConvOp.MaxLength = 2;
            this.cboRightConvOp.Name = "cboRightConvOp";
            this.cboRightConvOp.Size = new System.Drawing.Size(148, 33);
            this.cboRightConvOp.TabIndex = 23;
            this.cboRightConvOp.SelectedIndexChanged += new System.EventHandler(this.cboRightConvOp_SelectedIndexChanged);
            // 
            // txtRightConv
            // 
            this.txtRightConv.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRightConv.Location = new System.Drawing.Point(6, 70);
            this.txtRightConv.Name = "txtRightConv";
            this.txtRightConv.Size = new System.Drawing.Size(190, 33);
            this.txtRightConv.TabIndex = 23;
            // 
            // txtLeftConv
            // 
            this.txtLeftConv.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftConv.Location = new System.Drawing.Point(6, 31);
            this.txtLeftConv.Name = "txtLeftConv";
            this.txtLeftConv.Size = new System.Drawing.Size(190, 33);
            this.txtLeftConv.TabIndex = 23;
            this.txtLeftConv.Text = "0";
            this.txtLeftConv.TextChanged += new System.EventHandler(this.txtLeftConv_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tmCaretFade
            // 
            this.tmCaretFade.Enabled = true;
            this.tmCaretFade.Tick += new System.EventHandler(this.tmCaretFade_Tick);
            // 
            // pnlSettings
            // 
            this.pnlSettings.AutoScroll = true;
            this.pnlSettings.Controls.Add(this.groupBox3);
            this.pnlSettings.Controls.Add(this.groupBox2);
            this.pnlSettings.Controls.Add(this.btnCFadeFin);
            this.pnlSettings.Controls.Add(this.btnCFadeColor2);
            this.pnlSettings.Controls.Add(this.btnCFadeColor1);
            this.pnlSettings.Controls.Add(this.lblVersion);
            this.pnlSettings.Controls.Add(this.lblSettingsHL);
            this.pnlSettings.Location = new System.Drawing.Point(5, 182);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(427, 219);
            this.pnlSettings.TabIndex = 23;
            this.pnlSettings.Visible = false;
            // 
            // txtColor2B
            // 
            this.txtColor2B.Location = new System.Drawing.Point(126, 151);
            this.txtColor2B.Name = "txtColor2B";
            this.txtColor2B.Size = new System.Drawing.Size(42, 20);
            this.txtColor2B.TabIndex = 43;
            this.txtColor2B.Text = "0";
            // 
            // txtColor2G
            // 
            this.txtColor2G.Location = new System.Drawing.Point(126, 120);
            this.txtColor2G.Name = "txtColor2G";
            this.txtColor2G.Size = new System.Drawing.Size(42, 20);
            this.txtColor2G.TabIndex = 42;
            this.txtColor2G.Text = "255";
            // 
            // txtColor2R
            // 
            this.txtColor2R.Location = new System.Drawing.Point(126, 85);
            this.txtColor2R.Name = "txtColor2R";
            this.txtColor2R.Size = new System.Drawing.Size(42, 20);
            this.txtColor2R.TabIndex = 41;
            this.txtColor2R.Text = "255";
            // 
            // txtColor1B
            // 
            this.txtColor1B.Location = new System.Drawing.Point(4, 148);
            this.txtColor1B.Name = "txtColor1B";
            this.txtColor1B.Size = new System.Drawing.Size(42, 20);
            this.txtColor1B.TabIndex = 40;
            this.txtColor1B.Text = "0";
            // 
            // txtColor1G
            // 
            this.txtColor1G.Location = new System.Drawing.Point(4, 116);
            this.txtColor1G.Name = "txtColor1G";
            this.txtColor1G.Size = new System.Drawing.Size(42, 20);
            this.txtColor1G.TabIndex = 39;
            this.txtColor1G.Text = "0";
            // 
            // txtColor1R
            // 
            this.txtColor1R.Location = new System.Drawing.Point(4, 85);
            this.txtColor1R.Name = "txtColor1R";
            this.txtColor1R.Size = new System.Drawing.Size(42, 20);
            this.txtColor1R.TabIndex = 38;
            this.txtColor1R.Text = "255";
            // 
            // tkColor2B
            // 
            this.tkColor2B.AutoSize = false;
            this.tkColor2B.Location = new System.Drawing.Point(166, 148);
            this.tkColor2B.Maximum = 255;
            this.tkColor2B.Name = "tkColor2B";
            this.tkColor2B.Size = new System.Drawing.Size(65, 26);
            this.tkColor2B.TabIndex = 37;
            this.tkColor2B.ValueChanged += new System.EventHandler(this.tkColor2B_ValueChanged);
            // 
            // tkColor2G
            // 
            this.tkColor2G.AutoSize = false;
            this.tkColor2G.Location = new System.Drawing.Point(166, 116);
            this.tkColor2G.Maximum = 255;
            this.tkColor2G.Name = "tkColor2G";
            this.tkColor2G.Size = new System.Drawing.Size(65, 26);
            this.tkColor2G.TabIndex = 36;
            this.tkColor2G.Value = 255;
            this.tkColor2G.ValueChanged += new System.EventHandler(this.tkColor2G_ValueChanged);
            // 
            // tkColor2R
            // 
            this.tkColor2R.AutoSize = false;
            this.tkColor2R.Location = new System.Drawing.Point(166, 83);
            this.tkColor2R.Maximum = 255;
            this.tkColor2R.Name = "tkColor2R";
            this.tkColor2R.Size = new System.Drawing.Size(65, 26);
            this.tkColor2R.TabIndex = 35;
            this.tkColor2R.Value = 255;
            this.tkColor2R.ValueChanged += new System.EventHandler(this.tkColor2R_ValueChanged);
            // 
            // tkColor1B
            // 
            this.tkColor1B.AutoSize = false;
            this.tkColor1B.Location = new System.Drawing.Point(43, 147);
            this.tkColor1B.Maximum = 255;
            this.tkColor1B.Name = "tkColor1B";
            this.tkColor1B.Size = new System.Drawing.Size(65, 26);
            this.tkColor1B.TabIndex = 34;
            this.tkColor1B.ValueChanged += new System.EventHandler(this.tkColor1B_ValueChanged);
            // 
            // tkColor1G
            // 
            this.tkColor1G.AutoSize = false;
            this.tkColor1G.Location = new System.Drawing.Point(43, 113);
            this.tkColor1G.Maximum = 255;
            this.tkColor1G.Name = "tkColor1G";
            this.tkColor1G.Size = new System.Drawing.Size(65, 26);
            this.tkColor1G.TabIndex = 33;
            this.tkColor1G.ValueChanged += new System.EventHandler(this.tkColor1G_ValueChanged);
            // 
            // tkColor1R
            // 
            this.tkColor1R.AutoSize = false;
            this.tkColor1R.Location = new System.Drawing.Point(43, 81);
            this.tkColor1R.Maximum = 255;
            this.tkColor1R.Name = "tkColor1R";
            this.tkColor1R.Size = new System.Drawing.Size(65, 26);
            this.tkColor1R.TabIndex = 32;
            this.tkColor1R.Value = 255;
            this.tkColor1R.ValueChanged += new System.EventHandler(this.tkColor1R_ValueChanged);
            // 
            // btnCFadeFin
            // 
            this.btnCFadeFin.Location = new System.Drawing.Point(401, 180);
            this.btnCFadeFin.Name = "btnCFadeFin";
            this.btnCFadeFin.Size = new System.Drawing.Size(10, 10);
            this.btnCFadeFin.TabIndex = 31;
            this.btnCFadeFin.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Caret Fade Color 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Caret Fade Color 1";
            // 
            // btnCFadeColor2
            // 
            this.btnCFadeColor2.Location = new System.Drawing.Point(401, 164);
            this.btnCFadeColor2.Name = "btnCFadeColor2";
            this.btnCFadeColor2.Size = new System.Drawing.Size(10, 12);
            this.btnCFadeColor2.TabIndex = 28;
            this.btnCFadeColor2.UseVisualStyleBackColor = true;
            // 
            // btnCFadeColor1
            // 
            this.btnCFadeColor1.Location = new System.Drawing.Point(401, 149);
            this.btnCFadeColor1.Name = "btnCFadeColor1";
            this.btnCFadeColor1.Size = new System.Drawing.Size(10, 11);
            this.btnCFadeColor1.TabIndex = 27;
            this.btnCFadeColor1.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(352, 16);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(37, 13);
            this.lblVersion.TabIndex = 26;
            this.lblVersion.Text = "v1.0.5";
            // 
            // btnCaretFadeTest
            // 
            this.btnCaretFadeTest.Location = new System.Drawing.Point(180, 27);
            this.btnCaretFadeTest.Name = "btnCaretFadeTest";
            this.btnCaretFadeTest.Size = new System.Drawing.Size(76, 36);
            this.btnCaretFadeTest.TabIndex = 25;
            this.btnCaretFadeTest.Text = "test (mouseover)";
            this.btnCaretFadeTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaretFadeTest.UseVisualStyleBackColor = true;
            this.btnCaretFadeTest.Click += new System.EventHandler(this.btnCaretFadeTest_Click);
            this.btnCaretFadeTest.MouseEnter += new System.EventHandler(this.btnCaretFadeTest_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Example";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caret Fade Speed (0-127)";
            // 
            // numCaretFade
            // 
            this.numCaretFade.Location = new System.Drawing.Point(140, 43);
            this.numCaretFade.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numCaretFade.Name = "numCaretFade";
            this.numCaretFade.Size = new System.Drawing.Size(38, 20);
            this.numCaretFade.TabIndex = 1;
            this.numCaretFade.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numCaretFade.ValueChanged += new System.EventHandler(this.numCaretFade_ValueChanged);
            // 
            // lblSettingsHL
            // 
            this.lblSettingsHL.AutoSize = true;
            this.lblSettingsHL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsHL.Location = new System.Drawing.Point(3, 4);
            this.lblSettingsHL.Name = "lblSettingsHL";
            this.lblSettingsHL.Size = new System.Drawing.Size(75, 22);
            this.lblSettingsHL.TabIndex = 0;
            this.lblSettingsHL.Text = "Settings";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(431, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(14, 14);
            this.btnSettings.TabIndex = 24;
            this.btnSettings.Text = "~";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCaretFade);
            this.groupBox2.Controls.Add(this.txtColor2B);
            this.groupBox2.Controls.Add(this.txtExampleTB);
            this.groupBox2.Controls.Add(this.txtColor2G);
            this.groupBox2.Controls.Add(this.numCaretFade);
            this.groupBox2.Controls.Add(this.txtColor2R);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtColor1B);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtColor1G);
            this.groupBox2.Controls.Add(this.btnCaretFadeTest);
            this.groupBox2.Controls.Add(this.txtColor1R);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tkColor2B);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tkColor2G);
            this.groupBox2.Controls.Add(this.tkColor1R);
            this.groupBox2.Controls.Add(this.tkColor2R);
            this.groupBox2.Controls.Add(this.tkColor1G);
            this.groupBox2.Controls.Add(this.tkColor1B);
            this.groupBox2.Location = new System.Drawing.Point(8, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 190);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caret";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.colorWheelz1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnResultColor);
            this.groupBox3.Location = new System.Drawing.Point(8, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 106);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result Box";
            // 
            // btnResultColor
            // 
            this.btnResultColor.BackColor = System.Drawing.Color.CadetBlue;
            this.btnResultColor.Location = new System.Drawing.Point(92, 16);
            this.btnResultColor.Name = "btnResultColor";
            this.btnResultColor.Size = new System.Drawing.Size(46, 38);
            this.btnResultColor.TabIndex = 28;
            this.btnResultColor.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Result Box Color";
            // 
            // colorWheelz1
            // 
            this.colorWheelz1.Location = new System.Drawing.Point(148, 11);
            this.colorWheelz1.Name = "colorWheelz1";
            this.colorWheelz1.Size = new System.Drawing.Size(92, 89);
            this.colorWheelz1.TabIndex = 30;
            this.colorWheelz1.ColorChanged += new System.EventHandler(this.colorWheelz1_ColorChanged);
            // 
            // txtExampleTB
            // 
            this.txtExampleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExampleTB.Location = new System.Drawing.Point(308, 31);
            this.txtExampleTB.Name = "txtExampleTB";
            this.txtExampleTB.Size = new System.Drawing.Size(67, 33);
            this.txtExampleTB.TabIndex = 23;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.CadetBlue;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.White;
            this.txtResult.Location = new System.Drawing.Point(219, 47);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(148, 33);
            this.txtResult.TabIndex = 24;
            // 
            // txtRightVal
            // 
            this.txtRightVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRightVal.Location = new System.Drawing.Point(219, 6);
            this.txtRightVal.Name = "txtRightVal";
            this.txtRightVal.Size = new System.Drawing.Size(148, 33);
            this.txtRightVal.TabIndex = 23;
            this.txtRightVal.Text = "1.00";
            this.txtRightVal.TextChanged += new System.EventHandler(this.txtRightVal_TextChanged);
            this.txtRightVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRightVal_KeyPress);
            // 
            // txtLeftVal
            // 
            this.txtLeftVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftVal.Location = new System.Drawing.Point(24, 6);
            this.txtLeftVal.Name = "txtLeftVal";
            this.txtLeftVal.Size = new System.Drawing.Size(148, 33);
            this.txtLeftVal.TabIndex = 22;
            this.txtLeftVal.TextChanged += new System.EventHandler(this.txtLeftVal_TextChanged);
            this.txtLeftVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLeftVal_KeyPress);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 223);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tabControl1);
            this.Name = "mainForm";
            this.Text = "Quick Calculator";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor2B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor2G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor2R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor1B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor1G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkColor1R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCaretFade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cboCopyResult;
        private System.Windows.Forms.CheckBox cboClearLeft;
        private System.Windows.Forms.RadioButton rbOperatorMult;
        private System.Windows.Forms.RadioButton rbOperatorPlus;
        private System.Windows.Forms.RadioButton rbOperatorSub;
        private System.Windows.Forms.RadioButton rbOperatorDiv;
        private System.Windows.Forms.Label lblEquals;
        private System.Windows.Forms.ComboBox cboResultOp;
        private System.Windows.Forms.Button btnCopyLeftVal;
        private System.Windows.Forms.Button btnCopyRightVal;
        private System.Windows.Forms.Button btnCopyResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cboClearRight;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer tmInfo;
        private System.Windows.Forms.CheckBox cboClearResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cboConversionType;
        private System.Windows.Forms.ComboBox cboLeftConvOp;
        private System.Windows.Forms.Label lblConvEquals;
        private System.Windows.Forms.ComboBox cboRightConvOp;
        private System.Windows.Forms.TextBox txtRightConv;
        private System.Windows.Forms.TextBox txtLeftConv;
        private CustomTextBox txtResult;
        private CustomTextBox txtRightVal;
        private CustomTextBox txtLeftVal;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer tmCaretFade;
        private System.Windows.Forms.CheckBox chkCaretFade;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblSettingsHL;
        private System.Windows.Forms.NumericUpDown numCaretFade;
        private CustomTextBox txtExampleTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCaretFadeTest;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCFadeColor2;
        private System.Windows.Forms.Button btnCFadeColor1;
        private System.Windows.Forms.Button btnCFadeFin;
        private System.Windows.Forms.TextBox txtColor2B;
        private System.Windows.Forms.TextBox txtColor2G;
        private System.Windows.Forms.TextBox txtColor2R;
        private System.Windows.Forms.TextBox txtColor1B;
        private System.Windows.Forms.TextBox txtColor1G;
        private System.Windows.Forms.TextBox txtColor1R;
        private System.Windows.Forms.TrackBar tkColor2B;
        private System.Windows.Forms.TrackBar tkColor2G;
        private System.Windows.Forms.TrackBar tkColor2R;
        private System.Windows.Forms.TrackBar tkColor1B;
        private System.Windows.Forms.TrackBar tkColor1G;
        private System.Windows.Forms.TrackBar tkColor1R;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnResultColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private ColorWheelz colorWheelz1;
    }
}

