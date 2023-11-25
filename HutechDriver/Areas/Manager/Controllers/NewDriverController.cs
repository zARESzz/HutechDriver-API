﻿using HutechDriver.Models.EF;
using HutechDriver.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HutechDriver.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager,Admin")]
    public class NewDriverController : Controller
    {
        // GET: Admin/NewDriver
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string SearchText, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Contact> items = db.Contacts.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.Name.Contains(SearchText) || x.PhoneNumber.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        [HttpPost]
        public ActionResult Approve(int id)
        {
            string contentApprove = System.IO.File.ReadAllText(Server.MapPath("~/Content/Notification/NotificationNewDriver.html"));
            var find = db.Contacts.FirstOrDefault(p => p.Id == id);
            if (find != null)
            {
                find.IsRead = 1;
                find.IsStatus = 1;
                SendMail.SendEmail(find.Email, "Thư chúc mừng", contentApprove, "");
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult Fall(int id)
        {
            string contentFall = System.IO.File.ReadAllText(Server.MapPath("~/Content/Notification/NotificationNon.html"));
            var find = db.Contacts.FirstOrDefault(p => p.Id == id);
            if (find != null)
            {
                find.IsRead = 1;
                find.IsStatus = 0;
                SendMail.SendEmail(find.Email, "Rất tiếc bạn đã bị loại ", contentFall, "");
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Contacts.Find(id);
            if (item != null)
            {
                db.Contacts.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Contacts.Find(Convert.ToInt32(item));
                        db.Contacts.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}