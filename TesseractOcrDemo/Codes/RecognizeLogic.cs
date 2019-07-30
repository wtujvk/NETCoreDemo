using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using TesseractOcrDemo.Codes.Enums;

namespace TesseractOcrDemo.Codes
{
    public class RecognizeLogic
    {
        /// <summary>
        /// 识别字符串。
        /// </summary>
        /// <param name="bitmap">bitmap图片。</param>
        /// <returns>识别结果。</returns>
        public string GetStringFromImage(Bitmap bitmap)
        {
            using (var ocrApi = OcrApi.Create())
            {
                ocrApi.Init(Languages.English);
                return ocrApi.GetTextFromImage(bitmap);
            }
        }

        /// <summary>
        /// 测试识别率。
        /// </summary>
        /// <param name="verificationCodeCategory">验证码类别。</param>
        /// <param name="count">数量。</param>
        /// <param name="action">回调函数。</param>
        /// <returns>结果。成功数+总数。</returns>
        public Tuple<int,int> Test(VerificationCodeCategory verificationCodeCategory, int count, Action<string> action)
        {
            var successCount = 0;
            if (count > 0)
            {
                using (var ocrApi = OcrApi.Create())
                {
                    ocrApi.Init(Languages.English);
                    for (int i = 0; i < count; i++)
                    {
                        var numberChar = Utils.GetRandString(verificationCodeCategory);
                        var bitmap = Utils.CreateCaptchaSimpleImage(numberChar);
                        var text = ocrApi.GetTextFromImage(bitmap);
                        var resultSuccess = string.Equals(numberChar?.Trim(), text?.Trim(),
                            StringComparison.CurrentCultureIgnoreCase);
                          var resultMessage = resultSuccess ? "识别成功"
                            : "识别失败";
                          if (resultSuccess)
                          {
                              successCount++;
                          }

                        var message = $"{i+1}, 随机数是{numberChar},验证码识别是{text},结果：{resultMessage}。 \r\n";
                        action?.Invoke(message);
                        bitmap.Dispose();
                    }
                }
            }

            return new Tuple<int, int>(successCount, count);
        }
    }
}
