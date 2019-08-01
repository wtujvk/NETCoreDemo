using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOcrDemo.Codes;
using TesseractOcrDemo.Codes.Enums;

namespace TesseractOcrDemo
{
    public partial class Form1 : Form
    {
        private bool isTesting = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnEasyYzm_Click(object sender, EventArgs e)
        {
            var ranNum = Utils.GetRandString(VerificationCodeCategory.Number);
            var image = Utils.CreateCaptchaSimpleImage(ranNum);
            this.pictureBox1.Image?.Dispose();
            this.pictureBox1.Image = image;
        }

        private void BtnKnowYzm_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image != null)
            {
                var bitmap = new Bitmap(this.pictureBox1.Image);
                var text = new RecognizeLogic().GetStringFromImage(bitmap);
                this.txtResult.Text = text;
                bitmap.Dispose();
            }
            else
            {
                MessageBox.Show("请先生成图片");
            }
        }

        private void BtnYzmNumAndEnChar_Click(object sender, EventArgs e)
        {
            var ranNum = Utils.GetRandString(VerificationCodeCategory.Number | VerificationCodeCategory.Lowercase);
            var image = Utils.CreateCaptchaSimpleImage(ranNum);
            this.pictureBox1.Image?.Dispose();
            this.pictureBox1.Image = image;
        }

        private void BtnNumberAccuracy_Click(object sender, EventArgs e)
        {
            if (this.CheckIsTest())
            {
                isTesting = true;
                var num = Convert.ToInt32(this.numericUpDown1.Value * 100);
                var resultTuple = new RecognizeLogic().Test(VerificationCodeCategory.Number, num, this.WriteTestResult);
                var message = $"总共测试{resultTuple.Item2}个，成功{resultTuple.Item1}个，成功率{100.0 * resultTuple.Item1 / resultTuple.Item2}%";
                this.WriteTestResult(message);
                this.isTesting = false;
            }
        }

        private void BtnCharAccuracy_Click(object sender, EventArgs e)
        {
            if (this.CheckIsTest())
            {
                var num = Convert.ToInt32(this.numericUpDown1.Value * 100);
              var resultTuple=  new RecognizeLogic().Test(VerificationCodeCategory.Lowercase, num, this.WriteTestResult);
                var message = $"总共测试{resultTuple.Item2}个，成功{resultTuple.Item1}个，成功率{100.0 * resultTuple.Item1 / resultTuple.Item2}%";
                this.WriteTestResult(message);
                this.isTesting = false;
            }
        }

        private void BtnNumberCharAccuracy_Click(object sender, EventArgs e)
        {
            if (this.CheckIsTest())
            {
                var num = Convert.ToInt32(this.numericUpDown1.Value * 100);
               var resultTuple= new RecognizeLogic().Test(VerificationCodeCategory.Lowercase | VerificationCodeCategory.Number, num, this.WriteTestResult);
               var message = $"总共测试{resultTuple.Item2}个，成功{resultTuple.Item1}个，成功率{100.0 * resultTuple.Item1 / resultTuple.Item2}%";
               this.WriteTestResult(message);
                this.isTesting = false;
            }
        }

        private bool CheckIsTest()
        {
            if (isTesting)
            {
                MessageBox.Show("正在测试中，。。。。");
            }

            return !isTesting;
        }

        private void WriteTestResult(string result)
        {
            this.txtTestResult.AppendText(result);
            this.txtTestResult.ScrollToCaret();
        }

        private void BtnLocalYzm_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "请选择要上传的图片", Filter = "图像文件(*.jpg;*.gif;*.png)|*.jpg;*.gif;*.png", Multiselect = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                this.txtImgPath.Text = path;
                this.pictureBox1.Load(path);
            }
        }

        private void BtnImageCreate_Click(object sender, EventArgs e)
        {
            var input = this.txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("请输入内容");
            }
            else
            {
                inputText = input.Trim();
                var image = Utils.CreateCaptchaSimpleImage(input.Trim());
                this.pictureBox2.Image?.Dispose();
                this.pictureBox2.Image = image;
            }
        }

        private void BtnSeeInput_Click(object sender, EventArgs e)
        {
            if (this.pictureBox2.Image != null)
            {
                using (var bitmap = new Bitmap(this.pictureBox2.Image))
                {
                    var text = new RecognizeLogic().GetStringFromImage(bitmap);
                    var result =
                        string.Equals(inputText?.Trim(), text?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            ? "成功"
                            : "失败";
                    var message = $"输入：{inputText}，识别：{text}。 识别{result}\r\n";
                    this.txtInputResult.AppendText(message);
                    this.txtInputResult.ScrollToCaret();
                }
            }
        }

        private string inputText;
    }
}
