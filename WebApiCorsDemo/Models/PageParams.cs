using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApiCorsDemo.Models
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParams
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public PageParams()
        {
            
        }
        /// <summary>
        /// 音乐关键词
        /// </summary>
        [Required]
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        private int _current=1;

        private int _size=20;

        /// <summary>
        /// 获取当前页
        /// </summary>
        [JsonProperty("current")]
        public int Current
        {
            get
            {
                if (_current <= 0)
                    _current = 1;
                return _current;
            }
            set { _current = value; }
        }
        /// <summary>
        /// 分页大小
        /// </summary>
        [JsonProperty("size")]
        public int Size
        {
            get
            {
                if (_size <= 0)
                    _size = 20;
                return _size;
            }
            set { _size = value; }
        }
    }
}