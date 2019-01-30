using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CAP.Web.Codes
{
    /// <summary>
    /// 数据库上下文。
    /// </summary>
    public class CAPDbContext:DbContext
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="options">数据库配置。</param>
        public CAPDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
