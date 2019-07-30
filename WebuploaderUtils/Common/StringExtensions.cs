using System.Data;
using System.Linq;
using System.Text;
using System.Web.Security;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System;

namespace WebuploaderUtils.Common
{
    public static class StringExtensions
    {
        #region string ext

        /// <summary>
        /// 使用默认key进行aes加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string EncryptAes(this string s)
        {
            return EncryptHelper.AesEncrypt(s);
        }

        /// <summary>
        /// 自定义key进行aes加密
        /// </summary>
        /// <param name="toEncrypt">待加密的字符串。</param>
        /// <param name="key">key。</param>
        /// <returns></returns>
        public static string EncryptAes(this string toEncrypt, string key)
        {
            return EncryptHelper.AesEncrypt(toEncrypt, key);
        }

        /// <summary>
        /// 使用默认key进行aes解密
        /// </summary>
        /// <param name="toDecrypts">待解密的字符串。</param>
        /// <returns>字符串。</returns>
        public static string EncryptAesDe(this string toDecrypts)
        {
            return EncryptHelper.AesDecrypt(toDecrypts);
        }

        /// <summary>
        /// 自定义key进行aes解密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EncryptAESDe(this string s, string key)
        {
            return EncryptHelper.AesDecrypt(s, key);
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EncryptMD5(this string s)
        {
            return EncryptHelper.MD5SHA1Encrypt2(s, "MD5");
        }

        /// <summary>
        /// sha1加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string EncryptSHA1(this string s)
        {
            return EncryptHelper.MD5SHA1Encrypt2(s, "SHA1");
        }

        /// <summary>
        /// 删除文件名中不合法的字符串
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string RemoveInvalidFileNameChars(this string fileName)
        {
            StringBuilder _sb = new StringBuilder(fileName);

            char[] c = System.IO.Path.GetInvalidFileNameChars();
            c.ToList().ForEach(m => { _sb.Replace(m.ToString(), string.Empty); });

            return _sb.ToString();
        }

        /// <summary>
        /// 删除路径中不合法的字符串
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string RemoveInvalidPathChars(this string path)
        {
            StringBuilder _sb = new StringBuilder(path);

            char[] c = System.IO.Path.GetInvalidPathChars();
            c.ToList().ForEach(m => { _sb.Replace(m.ToString(), string.Empty); });

            return _sb.ToString();
        }

        /// <summary>
        /// 正则检测
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static bool IsMatch(this string s, string pattern)
        {
            if (string.IsNullOrEmpty(s)) return false;
            else return Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// 字符串是否为空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 正则搜索字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static string Match(this string s, string pattern)
        {
            if (s == null) return "";
            return Regex.Match(s, pattern).Value;
        }

        /// <summary>
        /// 是否是int
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        /// <summary>
        /// 是否是邮件
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmail(this string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 5) return false;
            return Regex.IsMatch(s, "^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 是否是用户名
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsUserName(this string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 6 || s.Length > 16) return false;
            return Regex.IsMatch(s, "^\\w{6,16}$");
        }

        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsPhone(this string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 11) return false;
            return Regex.IsMatch(s, "^13[0-9]{9}|15[012356789][0-9]{8}|18[0256789][0-9]{8}|147[0-9]{8}$");
        }

        /// <summary>
        /// 转换成int
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        /// <summary>
        /// 转换成int,不成功返回-1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToTryInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return i;
            return -1;
        }

        /// <summary>
        /// 是否是DateTime
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDate(this string s)
        {
            DateTime i;
            return DateTime.TryParse(s, out i);
        }

        /// <summary>
        /// 是否为GUID
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsGuid(this string s)
        {
            Guid g = Guid.Empty;
            return Guid.TryParse(s, out g);
        }

        /// <summary>
        /// 转换为GUID
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string s)
        {
            return Guid.Parse(s);
        }

        /// <summary>
        /// 转换成DateTime
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string s)
        {
            return DateTime.Parse(s);
        }

        /// <summary>
        /// 转换成DateTime,不成功返回DateTime.Now
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToTryDate(this string s)
        {
            DateTime i;
            if (DateTime.TryParse(s, out i))
            {
                return i;
            }

            return DateTime.Now;
        }

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToCamel(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            return s[0].ToString().ToLower() + s.Substring(1);
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToPascal(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            return s[0].ToString().ToUpper() + s.Substring(1);
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="format">格式</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="format">格式</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static string FormatWith(this string format, object args0)
        {
            return string.Format(format, args0);
        }

        public static string FormatWith(this string format, object args0, object args1)
        {
            return string.Format(format, args0, args1);
        }

        public static string FormatWith(this string format, object args0, object args1, object args2)
        {
            return string.Format(format, args0, args1, args2);
        }

        public static string FormatWith(this string format, object args0, object args1, object args2, object args3)
        {
            return string.Format(format, args0, args1, args2, args3);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }

        /// <summary>
        /// object to json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, new IsoDateTimeConverter());
        }

        #endregion
    }

    /// <summary>
    /// 加密帮助类
    /// </summary>
    public static class EncryptHelper
    {
        /// <summary>
        /// 默认key
        /// </summary>
        private const string defaultKey = "Author:xxwgcg;By:http://xxwgcg.cnblogs.com/";

        private static string _aesKey;

        /// <summary>
        /// key
        /// </summary>
        public static string AesKey
        {
            get
            {
                if (string.IsNullOrEmpty(_aesKey))
                {
                    AesKey = defaultKey;
                }

                return _aesKey;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _aesKey = defaultKey.Substring(0, 32);
                }
                else
                {
                    int valLength = value.Length;
                    if (valLength <= 16)
                    {
                        _aesKey = (value + defaultKey).Substring(0, 16);
                    }
                    else if (valLength <= 24)
                    {
                        _aesKey = (value + defaultKey).Substring(0, 24);
                    }
                    else
                    {
                        _aesKey = (value + defaultKey).Substring(0, 32);
                    }
                }
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="toEncrypt">待加密的字符串</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string AesEncrypt(string toEncrypt, string key)
        {
            AesKey = key;
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(AesKey.ToLower());
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 加密--使用默认key
        /// </summary>
        /// <param name="toEncrypt">待加密的字符串</param>
        /// <returns></returns>
        public static string AesEncrypt(string toEncrypt)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(AesKey.ToLower());
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="toDecrypt">待解密的字符串</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string AesDecrypt(string toDecrypt, string key)
        {
            AesKey = key;
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(AesKey.ToLower());
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="toDecrypt">待解密的字符串</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string AesDecrypt(string toDecrypt)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(AesKey.ToLower());
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// 对字符串进行MD5或SHA1加密操作,带'-'
        /// </summary>
        /// <param name="cleanString">明文字符串</param>
        /// <param name="strPasswordFormat">加密方式--MD5 OR SHA1</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5SHA1Encrypt1(string cleanString, string strPasswordFormat)
        {
            //19-A2-85-41-44-B6-3A-8F-76-17-A6-F2-25-01-9B-12                 MD5 admin
            //7C-87-54-1F-D3-F3-EF-50-16-E1-2D-41-19-00-C8-7A-60-46-A8-E8     SHA1 admin
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            Byte[] hashedBytes;
            switch (strPasswordFormat.ToUpper())
            {
                case "MD5":
                    hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
                    break;
                case "SHA1":
                    hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("SHA1")).ComputeHash(clearBytes);
                    break;
                default:
                    hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
                    break;
            }

            //string str = FormsAuthentication.HashPasswordForStoringInConfigFile(PWD, "MD5");
            return BitConverter.ToString(hashedBytes);
        }

        /// <summary>
        /// 对字符串进行MD5或SHA1加密操作,不带'-'
        /// </summary>
        /// <param name="cleanString">明文字符串</param>
        /// <param name="strPasswordFormat">加密方式--MD5 OR SHA1</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5SHA1Encrypt2(string cleanString, string strPasswordFormat)
        {
            //21232F297A57A5A743894A0E4A801FC3            MD5 admin
            //D033E22AE348AEB5660FC2140AEC35850C4DA997    SHA1 admin
            switch (strPasswordFormat.ToUpper())
            {
                case "MD5":
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(cleanString, "MD5");
                case "SHA1":
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(cleanString, "SHA1");
                default:
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(cleanString, "SHA1");
            }
        }

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式(utf-8)</param>
        /// <returns>签名结果</returns>
        public static string Sign(string prestr, string key, string _input_charset)
        {
            StringBuilder sb = new StringBuilder(32);

            prestr = prestr + key;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式(utf-8)</param>
        /// <returns>验证结果</returns>
        public static bool Verify(string prestr, string sign, string key, string _input_charset)
        {
            string mysign = Sign(prestr, key, _input_charset);
            return (mysign == sign);
        }
    }
}