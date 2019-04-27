using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using learning.LogMvcDemo.Codes;
using learning.LogMvcDemo.Codes.Entitys;

namespace learning.LogMvcDemo.Controllers
{
    public class ApplicationEntitiesController : Controller
    {
        LogLogic logic = new LogLogic();

        // GET: ApplicationEntities
        public ActionResult Index(int? pageIndex, int pageSize = 2)
        {
            int pageNumber = pageIndex ?? 1;
            var list = logic.GetPage(pageNumber, pageSize);
            return View(list);
        }

        // GET: ApplicationEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationEntity applicationEntity = logic.GetRepository<ApplicationEntity>().GetAll(c => c.Id == id).FirstOrDefault();
            if (applicationEntity == null)
            {
                return HttpNotFound();
            }
            return View(applicationEntity);
        }

        // GET: ApplicationEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationEntities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Appsecret,Enable,ValidDateTime")] ApplicationEntity applicationEntity)
        {
            if (ModelState.IsValid)
            {
                logic.GetRepository<ApplicationEntity>().Insert(applicationEntity);
                logic.SaveChange();

                return RedirectToAction("Index");
            }

            return View(applicationEntity);
        }

        // GET: ApplicationEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationEntity applicationEntity = logic.GetRepository<ApplicationEntity>().GetAll(c => c.Id == id).FirstOrDefault();
            if (applicationEntity == null)
            {
                return HttpNotFound();
            }
            return View(applicationEntity);
        }

        // POST: ApplicationEntities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Appsecret,Enable,ValidDateTime")] ApplicationEntity applicationEntity)
        {
            if (ModelState.IsValid)
            {
                logic.GetRepository<ApplicationEntity>().UpdateFromQuery(c => c.Id == applicationEntity.Id, c => applicationEntity);

                return RedirectToAction("Index");
            }
            return View(applicationEntity);
        }

        // GET: ApplicationEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationEntity applicationEntity = logic.GetRepository<ApplicationEntity>().GetAll(c => c.Id == id).FirstOrDefault();
            if (applicationEntity == null)
            {
                return HttpNotFound();
            }
            return View(applicationEntity);
        }

        // POST: ApplicationEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            logic.GetRepository<ApplicationEntity>().DeleteFromQuery(c => c.Id == id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                logic.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
