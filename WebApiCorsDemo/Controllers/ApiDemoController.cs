using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiCorsDemo.Models;

namespace WebApiCorsDemo.Controllers
{
    /// <summary>
    /// demo。
    /// </summary>
    public class ApiDemoController : ApiController
    {
        private static List<DemoData> dataList = new List<DemoData>()
        {
            new DemoData()
            {
                Id = 1, Name = "小二", BirthDate = DateTime.Now.AddDays(-2000)
            }
        };

        /// <summary>
        /// 返回列表数据。
        /// </summary>
        /// <returns>数据。</returns>
        public IEnumerable<DemoData> GetList()
        {
            return dataList;
        }

        /// <summary>
        /// 根据Id查询。
        /// </summary>
        /// <param name="id">id。</param>
        /// <returns></returns>
        public DemoData Get(int id)
        {
            var data = dataList.FirstOrDefault(c => c.Id == id);
            return data;
        }

        /// <summary>
        /// 添加。
        /// </summary>
        /// <param name="data">数据。</param>
        /// <returns>返回id。</returns>
        public int Add([FromBody]DemoData data)
        {
            int resultId = 0;
            if (data != null)
            {
                int maxId = dataList.Select(c => c.Id).DefaultIfEmpty().Max();
                data.Id = maxId + 1;
               dataList.Add(data);
               resultId = data.Id;
            }

            return resultId;
        }

        /// <summary>
        /// 修改。
        /// </summary>
        /// <param name="model">数据。</param>
        /// <returns></returns>
        public int Modify([FromBody] DemoData model)
        {
            int resultId = 0;
            var data = dataList.FirstOrDefault(c => c.Id == model.Id);
            if (data != null)
            {
                resultId = model.Id;
                data.Name = model.Name;
                data.BirthDate = model.BirthDate;
                data.Enable = model.Enable;
            }

            return resultId;
        }

        /// <summary>
        /// 删除。
        /// </summary>
        /// <param name="id">id。</param>
        /// <returns></returns>
        public int Delete(int id)
        {
            dataList.RemoveAll(c => c.Id == id);
            return  1;
        }
    }
}
