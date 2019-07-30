using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesseractOcrDemo.Codes.Enums;

namespace TesseractOcrDemo.Codes
{
    public class Utils
    {
        /// <summary>
        /// 随机数。
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// 获取验证码字符串自定义的图片。
        /// </summary>
        /// <param name="validateCode">验证码字符串。</param>
        /// <returns>图片对象。</returns>
        public static Bitmap CreateCaptchaSimpleImage(string validateCode)
        {
            Bitmap bitmap = new Bitmap((int)Math.Ceiling(validateCode.Length * 16.0), 27);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                var font = new Font(FontFamily.GenericMonospace, 13);
                var brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Blue,
                    Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                return bitmap;
            }
        }

        /// <summary>
        /// 生成随机数。
        /// </summary>
        /// <param name="verificationCodeCategory"></param>
        /// <param name="length"></param>
        /// <returns>随机数。</returns>
        public static string GetRandString(VerificationCodeCategory verificationCodeCategory, int length = 4)
        {
            StringBuilder sb = new StringBuilder();
            var numString = "0123456789";
            var lowerString = "abcdefghijklmnopqrstuvwxyz";
            var upperString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var baseStr = string.Empty;
            if (verificationCodeCategory.HasFlag(VerificationCodeCategory.Number))
            {
                baseStr += numString;
            }

            if (verificationCodeCategory.HasFlag(VerificationCodeCategory.Lowercase))
            {
                baseStr += lowerString;
            }

            if (verificationCodeCategory.HasFlag(VerificationCodeCategory.Uppercase))
            {
                baseStr += upperString;
            }

            var baseArray = baseStr.ToCharArray();

            for (int i = 0; i < length; i++)
            {
                var ch = baseArray.ElementAt(Random.Next(baseArray.Length));
                sb.Append(ch);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 如果目录不存在就创建。
        /// </summary>
        /// <param name="directory">物理目录名称。</param>
        public static void CreateDirectoryIfNotExists(string directory)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }
        }
    }
}
