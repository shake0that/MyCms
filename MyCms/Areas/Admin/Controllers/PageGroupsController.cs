using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyCms.Areas.Admin.Controllers
{
    [Authorize]
    public class PageGroupsController : Controller
    {
        private IPageGroupRepository pageGroupRepository;
        MyCmsContext db=new MyCmsContext();
        public PageGroupsController()
        {
            pageGroupRepository=new PageGroupRepository(db);
        }
        /// <summary>
        /// کنترلری که در ابتدا اجرا شده و صفحه پیشفرض را باز میکند 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(pageGroupRepository.GetAllGroups());
        }
        /// <summary>
        /// نمایش اطلاعات مربوط ب گروه خبری
        /// </summary>
        /// <param name="id"> کلید گروه خبری </param>
        /// <returns></returns>
        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }
        /// <summary>
        /// باز کردن صفحه مربوط به ایجاد گروه خبری
        /// GET
        /// </summary>
        /// <returns></returns>
        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }
        /// <summary>
        /// ایجاد گروه خبری 
        /// POST
        /// </summary>
        /// <param name="pageGroup"></param>
        /// <returns></returns>
        // POST: Admin/PageGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.InsertGroup(pageGroup);
                pageGroupRepository.save();
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }
        /// <summary>
        /// باز کردن صفحه مربوط به ویرایش گروه خبری
        /// GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/PageGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }
        /// <summary>
        /// اعمال ویرایش برای گروه خبری
        /// </summary>
        /// <param name="pageGroup"></param>
        /// <returns></returns>
        // POST: Admin/PageGroups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.UpdateGroup(pageGroup);
                pageGroupRepository.save();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }
        /// <summary>
        /// باز کردن صفحه مربوط به حذف گروه خبری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/PageGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }
        /// <summary>
        /// حذف گروه خبری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pageGroupRepository.DeleteGroup(id);
            pageGroupRepository.save();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
