using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiCorsDemo.Models
{
    /// <summary>
    /// 测试数据。
    /// </summary>
    public class DemoData
    {
        /// <summary>
        /// id。
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        [MaxLength(100)]
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Display(Name = "生日")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 已录。
        /// </summary>
        [Display(Name = "已录")]
        public bool Enable { get; set; }
    }
}