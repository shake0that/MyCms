using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyCms.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private IPageRepository pageRepository;
        private IPageGroupRepository pageGroupRepository;
        private MyCmsContext db = new MyCmsContext();
        public PagesController()
        {
            pageRepository=new PageRepository(db);
            pageGroupRepository=new PageGroupRepository(db);
        }
        /// <summary>
        /// کنترلری که در ابتدا اجرا شده و صفحه پیشفرض را باز میکند 
        /// </summary>
        /// <returns></returns>
        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(pageRepository.GetAllPage());
        }
        /// <summary>
        /// نمایش اطلاعات خبر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }
        /// <summary>
        /// باز کردن صفحه ایحاد خبر
        /// </summary>
        /// <returns></returns>
        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle");
            return View();
        }
        /// <summary>
        /// اضافه شدن خبر جدید
        /// </summary>
        /// <param name="page"></param>
        /// <param name="imgUp"></param>
        /// <returns></returns>
        // POST: Admin/Pages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CreateDate,Tags")] Page page,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate=DateTime.Now;

                if (imgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/"+page.ImageName));
                }

                pageRepository.InsertPage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }
        /// <summary>
        /// باز کردن صفحه مربوط به ویرایش خبر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }
        /// <summary>
        /// اعمال ویرایش برای خبر
        /// </summary>
        /// <param name="page"></param>
        /// <param name="imgUp"></param>
        /// <returns></returns>
        // POST: Admin/Pages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CreateDate,Tags")] Page page,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
                    }
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }
                pageRepository.UpdatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }
        /// <summary>
        /// باز کردن صفحه مربوط به حذف خبر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }
        /// <summary>
        /// حذف خبر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepository.GetPageById(id);
            if (page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
            }
            pageRepository.DeletePage(page);
            pageRepository.Save();
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
                pageRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
