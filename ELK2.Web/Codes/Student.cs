using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ELK2.Web.Codes
{
    /// <summary>
    /// 学生。
    /// </summary>
    public class Student
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
        [Required]
        [MaxLength(50)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 性别，男女。
        /// </summary>
        [Display(Name = "性别，男女")]
        public bool Gender { get; set; }

        /// <summary>
        /// 记录时间。
        /// </summary>
        public DateTime RecordTime { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [Display(Name = "分数")]
        [Range(0, 800)]
        public decimal Score { get; set; }

        /// <summary>
        /// 教室。
        /// </summary>
        [Display(Name = "所在的教室")]
        public int RoomId { get; set; }

        /// <summary>
        /// 教室名称。
        /// </summary>
        [Display(Name = "RoomName")]
        public string RoomName { get; set; }

        /// <summary>
        /// 教室。
        /// </summary>
        public virtual Room Room { get; set; }
    }
}
