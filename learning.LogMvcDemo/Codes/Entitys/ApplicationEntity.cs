using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace learning.LogMvcDemo.Codes.Entitys
{
    /// <summary>
    /// 应用。
    /// </summary>
    public class ApplicationEntity: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 名称。
        /// </summary>
        [Display(Name = "应用名称")]
        public string Name { get; set; }

        /// <summary>
        /// 密钥。
        /// </summary>
        [Display(Name = "应用密钥")]
        public string Appsecret { get; set; }

        /// <summary>
        /// 启用。
        /// </summary>
        [Display(Name = "是否启用")]
        public bool Enable { get; set; }

        /// <summary>
        /// 有效期。
        /// </summary>
        [Display(Name = "有效期")]
        public DateTime ValidDateTime { get; set; }
    }
}