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
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection fc, QUANTRIVIEN qtv)
        {
            if(ModelState.IsValid)
            {
                data.QUANTRIVIENs.InsertOnSubmit(qtv);
                data.SubmitChanges();
                RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return Create();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }


    }
}