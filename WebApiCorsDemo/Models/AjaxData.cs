using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiCorsDemo.Models
{
    /// <summary>
    /// ajax结果封装类
    /// </summary>
    [Serializable]
    public class AjaxData
    {
        /// <summary>
        ///true: 成功,false:失败
        /// </summary>
        [Display(Name = "true: 成功,false:失败")]
        public bool OK { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [Display(Name = "true: 成功,false:失败")]
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static AjaxData GetAjaxData()
        {
            return new AjaxData() { OK=false,Msg="未处理的异常"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="res"></param>
        /// <returns></returns>
        public static AjaxData<T> GetAjaxData<T>(T res=default(T))
        {
            return new AjaxData<T>() { OK = false, Msg = "未处理的异常",Res=res};
        }
    }

    /// <summary>
    /// ajax结果封装类 泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AjaxData<T> : AjaxData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        public AjaxData(T res=default(T))
        {
            Res = res;
        }

        /// <summary>
        /// 结果
        /// </summary>
        public T Res { get; set; }
    }
}