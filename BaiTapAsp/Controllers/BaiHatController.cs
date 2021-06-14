using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapAsp.Models;

namespace BaiTapAsp.Controllers
{
    public class BaiHatController : Controller
    {
        // GET: BaiHat
        public ActionResult showBH()
        {
            return View();
        }

        public ActionResult editBH (int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult editBH (BaiHat bh) {
            return View();
        }

        [HttpPost]
        public ActionResult addBH (BaiHat bh) {
            return View();
        }

        public ActionResult deleteBH(int id)
        {
            return View();
        }
    }
}