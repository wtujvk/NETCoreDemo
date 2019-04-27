
using System;
using System.Data.Entity;
using System.Linq;
using learning.LogMvcDemo.Migrations;

namespace learning.LogMvcDemo.Codes.Entitys
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("name=AppDataContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDataContext, Configuration>());
        }

        /// <summary>
        /// 应用。
        /// </summary>
        public virtual DbSet<ApplicationEntity> ApplicationEntitys { get; set; }

        /// <summary>
        /// 日志。
        /// </summary>
        public virtual DbSet<LoginEntity> LoginEntitys { get; set; }
    }
}