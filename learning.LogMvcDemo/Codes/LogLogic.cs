using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using learning.LogMvcDemo.Models;
using learning.LogMvcDemo.Codes.Entitys;
using Webdiyer.WebControls.Mvc;

namespace learning.LogMvcDemo.Codes
{
    public class LogLogic
    {
        readonly AppDataContext _context = new AppDataContext();

        public bool CheckKeyIsIsValid(LogInfo logInfo)
        {
            return false;
        }

        public void AddLog(LogInfo logInfo)
        {
            var loginEntity = new LoginEntity()
            {
                AppId = logInfo.AppId,
                CreateDate = DateTime.Now,
                LogLevel = logInfo.Level,
                Message = HttpUtility.UrlDecode(logInfo.Message),
                Origin = HttpUtility.UrlDecode(logInfo.Title),
                StackTrace = HttpUtility.UrlDecode(logInfo.StackTrace)
            };

            new GenericRepository<LoginEntity>(_context).Insert(loginEntity);
        }

        /// <summary>
        /// 获取应用分页列表数据。
        /// </summary>
        /// <param name="pageIndex">页码。</param>
        /// <param name="pageSize">页容量。</param>
        /// <returns>数据。</returns>
        public IPagedList<ApplicationEntity> GetPage(int pageIndex, int pageSize)
        {
            var query = new GenericRepository<ApplicationEntity>(_context).GetAll(c => true);
            return query.OrderByDescending(c => c.Id).ToPagedList(pageIndex, pageSize);
        }

        public GenericRepository<T> GetRepository<T>() where T : class, IEntity, new()
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        internal void Dispose()
        {
            _context.Dispose();
        }
    }
}