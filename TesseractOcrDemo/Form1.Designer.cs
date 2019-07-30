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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEasyYzm
            // 
            this.btnEasyYzm.Location = new System.Drawing.Point(18, 14);
            this.btnEasyYzm.Name = "btnEasyYzm";
            this.btnEasyYzm.Size = new System.Drawing.Size(204, 36);
            this.btnEasyYzm.TabIndex = 0;
            this.btnEasyYzm.Text = "生成简单验证码4位数字";
            this.btnEasyYzm.UseVisualStyleBackColor = true;
            this.btnEasyYzm.Click += new System.EventHandler(this.BtnEasyYzm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(35, 167);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 54);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnKnowYzm
            // 
            this.btnKnowYzm.Location = new System.Drawing.Point(233, 105);
            this.btnKnowYzm.Name = "btnKnowYzm";
            this.btnKnowYzm.Size = new System.Drawing.Size(103, 36);
            this.btnKnowYzm.TabIndex = 2;
            this.btnKnowYzm.Text = "识别普通验证码";
            this.btnKnowYzm.UseVisualStyleBackColor = true;
            this.btnKnowYzm.Click += new System.EventHandler(this.BtnKnowYzm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnYzmNumAndEnChar);
            this.panel1.Controls.Add(this.txtResult);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEasyYzm);
            this.panel1.Controls.Add(this.btnKnowYzm);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(21, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 262);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "识别结果";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(224, 200);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 21);
            this.txtResult.TabIndex = 4;
            // 
            // btnYzmNumAndEnChar
            // 
            this.btnYzmNumAndEnChar.Location = new System.Drawing.Point(18, 56);
            this.btnYzmNumAndEnChar.Name = "btnYzmNumAndEnChar";
            this.btnYzmNumAndEnChar.Size = new System.Drawing.Size(204, 38);
            this.btnYzmNumAndEnChar.TabIndex = 5;
            this.btnYzmNumAndEnChar.Text = "简单验证码4位数字加字母";
            this.btnYzmNumAndEnChar.UseVisualStyleBackColor = true;
            this.btnYzmNumAndEnChar.Click += new System.EventHandler(this.BtnYzmNumAndEnChar_Click);
            // 
            // btnNumberAccuracy
            // 
            this.btnNumberAccuracy.Location = new System.Drawing.Point(467, 27);
            this.btnNumberAccuracy.Name = "btnNumberAccuracy";
            this.btnNumberAccuracy.Size = new System.Drawing.Size(222, 36);
            this.btnNumberAccuracy.TabIndex = 4;
            this.btnNumberAccuracy.Text = "测试纯数字识别率";
            this.btnNumberAccuracy.UseVisualStyleBackColor = true;
            this.btnNumberAccuracy.Click += new System.EventHandler(this.BtnNumberAccuracy_Click);
            // 
            // btnCharAccuracy
            // 
            this.btnCharAccuracy.Location = new System.Drawing.Point(467, 83);
            this.btnCharAccuracy.Name = "btnCharAccuracy";
            this.btnCharAccuracy.Size = new System.Drawing.Size(222, 29);
            this.btnCharAccuracy.TabIndex = 5;
            this.btnCharAccuracy.Text = "测试纯字母识别率";
            this.btnCharAccuracy.UseVisualStyleBackColor = true;
            this.btnCharAccuracy.Click += new System.EventHandler(this.BtnCharAccuracy_Click);
            // 
            // btnNumberCharAccuracy
            // 
            this.btnNumberCharAccuracy.Location = new System.Drawing.Point(467, 132);
            this.btnNumberCharAccuracy.Name = "btnNumberCharAccuracy";
            this.btnNumberCharAccuracy.Size = new System.Drawing.Size(222, 36);
            this.btnNumberCharAccuracy.TabIndex = 6;
            this.btnNumberCharAccuracy.Text = "测试数字加字母";
            this.btnNumberCharAccuracy.UseVisualStyleBackColor = true;
            this.btnNumberCharAccuracy.Click += new System.EventHandler(this.BtnNumberCharAccuracy_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(649, 210);
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
            this.numlabel.Location = new System.Drawing.Point(452, 212);
            this.numlabel.Name = "numlabel";
            this.numlabel.Size = new System.Drawing.Size(191, 12);
            this.numlabel.TabIndex = 8;
            this.numlabel.Text = "数量(x100), 输入范围（0.1-100）";
            // 
            // txtTestResult
            // 
            this.txtTestResult.Location = new System.Drawing.Point(422, 256);
            this.txtTestResult.Multiline = true;
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.Size = new System.Drawing.Size(328, 182);
            this.txtTestResult.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTestResult);
            this.Controls.Add(this.numlabel);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnNumberCharAccuracy);
            this.Controls.Add(this.btnCharAccuracy);
            this.Controls.Add(this.btnNumberAccuracy);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

