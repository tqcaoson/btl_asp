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
        DongNhacDAO dongnhacdao = new DongNhacDAO();
        public ActionResult Index()
        {
			List<DongNhac> lists = dongnhacdao.getAllDongNhac();
            return View(lists);
        }

        // GET: DongNhac/Add/
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DongNhac dn)
        {
            dongnhacdao.insertDongNhac(dn);
            return Redirect("/DongNhac");
        }

        // GET: DongNhac/Edit/
        public ActionResult Edit(int id)
        {
            DongNhac dn = dongnhacdao.getDongNhacByID(id);
            return View(dn);
        }

        // POST: DongNhac/Edit/
        [HttpPost]
        public ActionResult Edit(DongNhac dn)
        {
            dongnhacdao.updateDongNhac(dn);
            return Redirect("/DongNhac");
        }

        public ActionResult Delete(int id)
		{
            dongnhacdao.deleteDongNhac(id);
            return Redirect("/DongNhac");
		}
    }
}