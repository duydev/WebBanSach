using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        dbWebBanSachDataContext data = new dbWebBanSachDataContext();

        // GET: Admin/Admin
        public ActionResult Index()
        {
            var GetAll = data.QUANTRIVIENs.ToList();
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

        public ActionResult Delete()
        {
            return View();
        }


    }
}