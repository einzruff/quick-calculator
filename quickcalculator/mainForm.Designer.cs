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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboConversionType = new System.Windows.Forms.ComboBox();
            this.cboLeftConvOp = new System.Windows.Forms.ComboBox();
            this.lblConvEquals = new System.Windows.Forms.Label();
            this.cboRightConvOp = new System.Windows.Forms.ComboBox();
            this.txtRightConv = new System.Windows.Forms.TextBox();
            this.txtLeftConv = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtResult = new quickcalculator.CustomTextBox();
            this.txtRightVal = new quickcalculator.CustomTextBox();
            this.txtLeftVal = new quickcalculator.CustomTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.chkCaretFade = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 207);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.chkCaretFade);
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
            this.cboLeftConvOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboLeftConvOp.Location = new System.Drawing.Point(126, 31);
            this.cboLeftConvOp.MaxLength = 2;
            this.cboLeftConvOp.Name = "cboLeftConvOp";
            this.cboLeftConvOp.Size = new System.Drawing.Size(62, 33);
            this.cboLeftConvOp.TabIndex = 23;
            // 
            // lblConvEquals
            // 
            this.lblConvEquals.AutoSize = true;
            this.lblConvEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvEquals.Location = new System.Drawing.Point(186, 35);
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
            this.cboRightConvOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboRightConvOp.Location = new System.Drawing.Point(346, 31);
            this.cboRightConvOp.MaxLength = 2;
            this.cboRightConvOp.Name = "cboRightConvOp";
            this.cboRightConvOp.Size = new System.Drawing.Size(69, 33);
            this.cboRightConvOp.TabIndex = 23;
            // 
            // txtRightConv
            // 
            this.txtRightConv.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRightConv.Location = new System.Drawing.Point(210, 31);
            this.txtRightConv.Name = "txtRightConv";
            this.txtRightConv.Size = new System.Drawing.Size(132, 33);
            this.txtRightConv.TabIndex = 23;
            // 
            // txtLeftConv
            // 
            this.txtLeftConv.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftConv.Location = new System.Drawing.Point(6, 31);
            this.txtLeftConv.Name = "txtLeftConv";
            this.txtLeftConv.Size = new System.Drawing.Size(118, 33);
            this.txtLeftConv.TabIndex = 23;
            this.txtLeftConv.TextChanged += new System.EventHandler(this.txtLeftConv_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            // 
            // txtLeftVal
            // 
            this.txtLeftVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftVal.Location = new System.Drawing.Point(24, 6);
            this.txtLeftVal.Name = "txtLeftVal";
            this.txtLeftVal.Size = new System.Drawing.Size(148, 33);
            this.txtLeftVal.TabIndex = 22;
            this.txtLeftVal.TextChanged += new System.EventHandler(this.txtLeftVal_TextChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // chkCaretFade
            // 
            this.chkCaretFade.AutoSize = true;
            this.chkCaretFade.Checked = true;
            this.chkCaretFade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaretFade.Location = new System.Drawing.Point(337, 158);
            this.chkCaretFade.Name = "chkCaretFade";
            this.chkCaretFade.Size = new System.Drawing.Size(78, 17);
            this.chkCaretFade.TabIndex = 12;
            this.chkCaretFade.Text = "Caret Fade";
            this.chkCaretFade.UseVisualStyleBackColor = true;
            this.chkCaretFade.CheckedChanged += new System.EventHandler(this.chkCaretFade_CheckedChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 223);
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
        private System.Windows.Forms.Timer timer1;
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
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox chkCaretFade;
    }
}

