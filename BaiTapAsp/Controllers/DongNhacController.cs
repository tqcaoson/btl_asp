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
    }
}