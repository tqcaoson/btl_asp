using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapAsp.Models;
using BaiTapAsp.ModelShow;

namespace BaiTapAsp.Controllers
{
    public class BaiHatController : Controller
    {
        // GET: BaiHat
        public ActionResult showBH()
        {
            //if (Session["username"] == null)
            //    return Redirect("/Auth/DangNhap");

            BaiHatDAO bh = new BaiHatDAO();
            NhacSiDAO ns = new NhacSiDAO();
            DongNhacDAO dn = new DongNhacDAO();
            List<DongNhac> dongnhac = dn.getAllDongNhac();
            List<NhacSi> nhacsi = ns.getAllNhacSi();
            List<BaiHat> baiHats = bh.GetBaiHats();
            List<BaiHatShow> show = new List<BaiHatShow>();

            foreach(BaiHat bai in baiHats)
            {
                BaiHatShow baiHatShow = new BaiHatShow();
                baiHatShow.Id = bai.Id;
                baiHatShow.Ten_bai_hat = bai.Ten_bai_hat;
                baiHatShow.NgayDang = bai.NgayDang;
                baiHatShow.LuotNghe = bai.LuotNghe;

                var nhacSi = nhacsi.FirstOrDefault(x => x.id == bai.Id_nhacsi);
                if (nhacSi != null)
                    baiHatShow.Ten_NhacSi = nhacSi.fullName;

                var dongNhac = dongnhac.FirstOrDefault(x => x.Id == bai.Id_dongnhac);
                if (dongNhac != null)
                    baiHatShow.Ten_DongNhac = dongNhac.TenDongNhac;

                show.Add(baiHatShow);
            }

            return View(show);
        }

        public ActionResult editBH (int id)
        {
            //if (Session["username"] == null)
            //    return Redirect("/Auth/DangNhap");

            DongNhacDAO dn = new DongNhacDAO();
            NhacSiDAO ns = new NhacSiDAO();
            BaiHatDAO da = new BaiHatDAO();
            List<DongNhac> dongnhac = dn.getAllDongNhac();
            List<NhacSi> nhacsi = ns.getAllNhacSi();

            ViewBag.DongNhac = dongnhac.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.TenDongNhac }).ToList();
            ViewBag.NhacSi = nhacsi.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.fullName }).ToList();
            BaiHat baiHat = da.getBaiHatByID(id);
            return View(baiHat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editBH (BaiHat bh) {
            BaiHatDAO da = new BaiHatDAO();
            if (bh.Id > 0)
            {
                BaiHat baiHat = da.getBaiHatByID(bh.Id);
                if(baiHat != null)
                {
                    da.UpdateBH(bh);
                    return RedirectToAction("showBH");
                }
            }
            return View();
        }

        public ActionResult addBH()
        {
            //if (Session["username"] == null)
            //    return Redirect("/Auth/DangNhap");

            DongNhacDAO dn = new DongNhacDAO();
            NhacSiDAO ns = new NhacSiDAO();
            List<DongNhac> dongnhac = dn.getAllDongNhac();
            List<NhacSi> nhacsi = ns.getAllNhacSi();

            ViewBag.DongNhac = dongnhac.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.TenDongNhac }).ToList();
            ViewBag.NhacSi = nhacsi.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.fullName }).ToList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addBH (BaiHat bh) {
            BaiHatDAO baiHat = new BaiHatDAO();
            baiHat.insertBH(bh);
            return RedirectToAction("showBH");
        }

        public ActionResult DeleteBH(int id)
        {
            //if (Session["username"] == null)
            //    return Redirect("/Auth/DangNhap");

            BaiHatDAO baiHat = new BaiHatDAO();
            ViewBag.NameBH = baiHat.getBaiHatByID(id).Ten_bai_hat;
            return View(baiHat.getBaiHatByID(id));
        }

        
        [HttpPost]
        public ActionResult DeleteBH(BaiHat bh)
        {           
            BaiHatDAO baiHat = new BaiHatDAO();
            baiHat.Delete(bh.Id);
            return RedirectToAction("showBH");
        }
    }
}