namespace TesseractOcrDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEasyYzm = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKnowYzm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnYzmNumAndEnChar = new System.Windows.Forms.Button();
            this.btnNumberAccuracy = new System.Windows.Forms.Button();
            this.btnCharAccuracy = new System.Windows.Forms.Button();
            this.btnNumberCharAccuracy = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numlabel = new System.Windows.Forms.Label();
            this.txtTestResult = new System.Windows.Forms.TextBox();
            this.btnLocalYzm = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtImgPath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSeeInput = new System.Windows.Forms.Button();
            this.txtInputResult = new System.Windows.Forms.TextBox();
            this.btnImageCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEasyYzm
            // 
            this.btnEasyYzm.Location = new System.Drawing.Point(12, 72);
            this.btnEasyYzm.Name = "btnEasyYzm";
            this.btnEasyYzm.Size = new System.Drawing.Size(204, 36);
            this.btnEasyYzm.TabIndex = 0;
            this.btnEasyYzm.Text = "生成简单验证码4位数字";
            this.btnEasyYzm.UseVisualStyleBackColor = true;
            this.btnEasyYzm.Click += new System.EventHandler(this.BtnEasyYzm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 185);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 54);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnKnowYzm
            // 
            this.btnKnowYzm.Location = new System.Drawing.Point(251, 126);
            this.btnKnowYzm.Name = "btnKnowYzm";
            this.btnKnowYzm.Size = new System.Drawing.Size(103, 36);
            this.btnKnowYzm.TabIndex = 2;
            this.btnKnowYzm.Text = "识别验证码";
            this.btnKnowYzm.UseVisualStyleBackColor = true;
            this.btnKnowYzm.Click += new System.EventHandler(this.BtnKnowYzm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnYzmNumAndEnChar);
            this.panel1.Controls.Add(this.txtResult);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEasyYzm);
            this.panel1.Controls.Add(this.btnKnowYzm);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(15, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 262);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "识别结果";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(240, 216);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 21);
            this.txtResult.TabIndex = 4;
            // 
            // btnYzmNumAndEnChar
            // 
            this.btnYzmNumAndEnChar.Location = new System.Drawing.Point(12, 125);
            this.btnYzmNumAndEnChar.Name = "btnYzmNumAndEnChar";
            this.btnYzmNumAndEnChar.Size = new System.Drawing.Size(204, 38);
            this.btnYzmNumAndEnChar.TabIndex = 5;
            this.btnYzmNumAndEnChar.Text = "简单验证码4位数字加字母";
            this.btnYzmNumAndEnChar.UseVisualStyleBackColor = true;
            this.btnYzmNumAndEnChar.Click += new System.EventHandler(this.BtnYzmNumAndEnChar_Click);
            // 
            // btnNumberAccuracy
            // 
            this.btnNumberAccuracy.Location = new System.Drawing.Point(38, 20);
            this.btnNumberAccuracy.Name = "btnNumberAccuracy";
            this.btnNumberAccuracy.Size = new System.Drawing.Size(285, 36);
            this.btnNumberAccuracy.TabIndex = 4;
            this.btnNumberAccuracy.Text = "测试纯数字识别率";
            this.btnNumberAccuracy.UseVisualStyleBackColor = true;
            this.btnNumberAccuracy.Click += new System.EventHandler(this.BtnNumberAccuracy_Click);
            // 
            // btnCharAccuracy
            // 
            this.btnCharAccuracy.Location = new System.Drawing.Point(38, 78);
            this.btnCharAccuracy.Name = "btnCharAccuracy";
            this.btnCharAccuracy.Size = new System.Drawing.Size(285, 29);
            this.btnCharAccuracy.TabIndex = 5;
            this.btnCharAccuracy.Text = "测试纯字母识别率";
            this.btnCharAccuracy.UseVisualStyleBackColor = true;
            this.btnCharAccuracy.Click += new System.EventHandler(this.BtnCharAccuracy_Click);
            // 
            // btnNumberCharAccuracy
            // 
            this.btnNumberCharAccuracy.Location = new System.Drawing.Point(39, 130);
            this.btnNumberCharAccuracy.Name = "btnNumberCharAccuracy";
            this.btnNumberCharAccuracy.Size = new System.Drawing.Size(284, 36);
            this.btnNumberCharAccuracy.TabIndex = 6;
            this.btnNumberCharAccuracy.Text = "测试数字加字母";
            this.btnNumberCharAccuracy.UseVisualStyleBackColor = true;
            this.btnNumberCharAccuracy.Click += new System.EventHandler(this.BtnNumberCharAccuracy_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(273, 207);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 21);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numlabel
            // 
            this.numlabel.AutoSize = true;
            this.numlabel.Location = new System.Drawing.Point(37, 209);
            this.numlabel.Name = "numlabel";
            this.numlabel.Size = new System.Drawing.Size(191, 12);
            this.numlabel.TabIndex = 8;
            this.numlabel.Text = "数量(x100), 输入范围（0.1-100）";
            // 
            // txtTestResult
            // 
            this.txtTestResult.Location = new System.Drawing.Point(38, 248);
            this.txtTestResult.Multiline = true;
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTestResult.Size = new System.Drawing.Size(328, 222);
            this.txtTestResult.TabIndex = 9;
            // 
            // btnLocalYzm
            // 
            this.btnLocalYzm.Location = new System.Drawing.Point(228, 14);
            this.btnLocalYzm.Name = "btnLocalYzm";
            this.btnLocalYzm.Size = new System.Drawing.Size(114, 31);
            this.btnLocalYzm.TabIndex = 6;
            this.btnLocalYzm.Text = "选择验证码图片";
            this.btnLocalYzm.UseVisualStyleBackColor = true;
            this.btnLocalYzm.Click += new System.EventHandler(this.BtnLocalYzm_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtImgPath
            // 
            this.txtImgPath.Location = new System.Drawing.Point(21, 24);
            this.txtImgPath.Name = "txtImgPath";
            this.txtImgPath.Size = new System.Drawing.Size(192, 21);
            this.txtImgPath.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtImgPath);
            this.panel2.Controls.Add(this.btnLocalYzm);
            this.panel2.Location = new System.Drawing.Point(12, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 62);
            this.panel2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 327);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "，生成或选图片";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImageCreate);
            this.groupBox2.Controls.Add(this.txtInputResult);
            this.groupBox2.Controls.Add(this.btnSeeInput);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtInput);
            this.groupBox2.Location = new System.Drawing.Point(866, 51);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 446);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手动输入验证码内容";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNumberAccuracy);
            this.groupBox3.Controls.Add(this.txtTestResult);
            this.groupBox3.Controls.Add(this.btnCharAccuracy);
            this.groupBox3.Controls.Add(this.numlabel);
            this.groupBox3.Controls.Add(this.btnNumberCharAccuracy);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Location = new System.Drawing.Point(437, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 518);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "批量自动测试识别率";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(131, 38);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 21);
            this.txtInput.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "输入数字或英文";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(38, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(193, 80);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnSeeInput
            // 
            this.btnSeeInput.Location = new System.Drawing.Point(38, 236);
            this.btnSeeInput.Name = "btnSeeInput";
            this.btnSeeInput.Size = new System.Drawing.Size(193, 38);
            this.btnSeeInput.TabIndex = 3;
            this.btnSeeInput.Text = "识别含输入的内容的图片";
            this.btnSeeInput.UseVisualStyleBackColor = true;
            this.btnSeeInput.Click += new System.EventHandler(this.BtnSeeInput_Click);
            // 
            // txtInputResult
            // 
            this.txtInputResult.Location = new System.Drawing.Point(47, 309);
            this.txtInputResult.Multiline = true;
            this.txtInputResult.Name = "txtInputResult";
            this.txtInputResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputResult.Size = new System.Drawing.Size(184, 67);
            this.txtInputResult.TabIndex = 4;
            // 
            // btnImageCreate
            // 
            this.btnImageCreate.Location = new System.Drawing.Point(38, 75);
            this.btnImageCreate.Name = "btnImageCreate";
            this.btnImageCreate.Size = new System.Drawing.Size(193, 39);
            this.btnImageCreate.TabIndex = 5;
            this.btnImageCreate.Text = "生成图片";
            this.btnImageCreate.UseVisualStyleBackColor = true;
            this.btnImageCreate.Click += new System.EventHandler(this.BtnImageCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 596);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "验证码识别0.0";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEasyYzm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnKnowYzm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYzmNumAndEnChar;
        private System.Windows.Forms.Button btnNumberAccuracy;
        private System.Windows.Forms.Button btnCharAccuracy;
        private System.Windows.Forms.Button btnNumberCharAccuracy;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label numlabel;
        private System.Windows.Forms.TextBox txtTestResult;
        private System.Windows.Forms.TextBox txtImgPath;
        private System.Windows.Forms.Button btnLocalYzm;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInputResult;
        private System.Windows.Forms.Button btnSeeInput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnImageCreate;
    }
}

