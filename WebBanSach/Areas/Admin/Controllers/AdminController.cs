using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;
using PagedList;
using PagedList.Mvc;

namespace WebBanSach.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        dbWebBanSachDataContext data = new dbWebBanSachDataContext();

        // GET: Admin/Admin
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1); // Tuong duong pageNumber = page != null ? page : 1;
            int pageSize = 7;
            var GetAll = data.QUANTRIVIENs.ToList().OrderBy(a => a.MaQTV).ToPagedList(pageNumber,pageSize);
            return View(GetAll);
        }

        public ActionResult Create()
        {
            QUANTRIVIEN qtv = new QUANTRIVIEN();
            return View(qtv);
        }

        [HttpPost]
        public ActionResult Create(QUANTRIVIEN qtv)
        {
            if(ModelState.IsValid)
            {
                data.QUANTRIVIENs.InsertOnSubmit(qtv);
                data.SubmitChanges();
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return Create();
        }

        public ActionResult Edit(int id)
        {
            var qtv = data.QUANTRIVIENs.SingleOrDefault(a => a.MaQTV == id);
            if(qtv == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return View(qtv);
        }

        [HttpPost]
        public ActionResult Edit(int id, QUANTRIVIEN qtv)
        {
            if (ModelState.IsValid)
            {
                var _qtv = data.QUANTRIVIENs.Single(a => a.MaQTV == id);
                UpdateModel(_qtv);
                data.SubmitChanges();
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return Edit(qtv.MaQTV);
        }

        public ActionResult Delete(int id)
        {
            var qtv = data.QUANTRIVIENs.SingleOrDefault(a => a.MaQTV == id);
            if (qtv == null)
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            data.QUANTRIVIENs.DeleteOnSubmit(qtv);
            data.SubmitChanges();
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }


    }
}