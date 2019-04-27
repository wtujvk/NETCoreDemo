using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ELK2.Web.Codes
{
    /// <summary>
    /// 教室。
    /// </summary>
    public class Room
    {
        /// <summary>
        /// 教室Id。
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        /// <summary>
        /// 编号。
        /// </summary>
        public string RoomCode { get; set; }

        /// <summary>
        /// 是否可用。
        /// </summary>
        public bool Enable { get; set; }

       /// <summary>
       /// 学生。
       /// </summary>
        public virtual ICollection<Student> Students { get; set; }
    }
}
