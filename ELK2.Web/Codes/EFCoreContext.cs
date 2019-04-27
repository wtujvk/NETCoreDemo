using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELK2.Web.Codes
{
    /// <summary>
    /// 上下文。
    /// </summary>
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
            this.InitData();
        }

        /// <summary>
        /// 房间。
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// 学生。
        /// </summary>
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=database-name;Integrated Security=True");
        }

        /// <summary>
        /// 初始化数据。
        /// </summary>
        private void InitData()
        {
            var room = new Room()
            {
                RoomCode = "101",
                Enable = true,
            };

            this.Rooms.Add(room);
            this.SaveChanges();
            var students = new List<Student>()
            {
                new Student(){ Name = "张三", Gender = true, RoomId = room.RoomId, RoomName = room.RoomCode, Score = 250, RecordTime = DateTime.Now},
                new Student(){ Name = "萌萌", Gender = false, RoomId = room.RoomId, RoomName = room.RoomCode, Score = 666, RecordTime = DateTime.Now}
            };

            this.Students.AddRange(students);
            this.SaveChanges();
        }
    }
}
