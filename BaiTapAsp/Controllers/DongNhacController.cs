using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapAsp.Models;

namespace BaiTapAsp.Controllers
{
    public class DongNhacController : Controller
    {
        DongNhacDAO nhacsidao = new DongNhacDAO();
        public ActionResult Index()
        {
			List<DongNhac> lists = nhacsidao.getAllDongNhac();
            return View(lists);
        }

        // GET: DongNhac/Add/
        public ActionResult Add()
        {
            return View();
        }


        // POST: DongNhac/Add/
        [HttpPost]
        public ActionResult Add(DongNhac dn)
        {
            return Redirect("/DongNhac");
        }

        // GET: DongNhac/Edit/
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DongNhac/Edit/
        [HttpPost]
        public ActionResult Edit(DongNhac dn)
        {
            return Redirect("/DongNhac");
        }
    }
}