using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapAsp.Models;
namespace BaiTapAsp.Controllers
{
    public class NhacSiController : Controller
    {
        static List<NhacSi> listNhacSi = new List<NhacSi>();
        // GET: NhacSi
        public ActionResult Index(string name_find)
        {
            if (Session["username"] == null)
                return Redirect("/Auth/DangNhap");
            NhacSiDAO nhacsidao = new NhacSiDAO();
            listNhacSi = nhacsidao.getAllNhacSi();

            if (!string.IsNullOrEmpty(name_find))
            {
                listNhacSi = nhacsidao.getNhacSiByTen_nhacsi(name_find);
            }

            return View(listNhacSi);

            
        }

        // GET: NhacSi/Details/5
        public ActionResult Details(int id)
        {
            NhacSi ns = listNhacSi.Find(x => x.id == id);
            return View(ns);
        }

        // GET: NhacSi/Create
        public ActionResult Create()
        {
            NhacSi ns = new NhacSi();
            return View(ns);
        }

        // POST: NhacSi/Create
        [HttpPost]
        public ActionResult Create(NhacSi ns)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(ns.Imageupload.FileName);
                string extension = Path.GetExtension(ns.Imageupload.FileName);
                if (extension != ".jpg" && extension != ".png" && extension != ".jpeg"
                    && extension != ".JPG" && extension != ".PNG" && extension != ".JPEG")
                {
                    TempData["err"] = "vui lòng chọn ảnh đúng định dạng";
                    return Redirect("/NhacSi/Create");
                }
                fileName = fileName + extension;
                  ns.image = "~/Content/images/" + fileName;
                // luu len server
                  ns.Imageupload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                  NhacSiDAO nhacsidao = new NhacSiDAO();
    
                  nhacsidao.insertNhacSi(ns);
                  return RedirectToAction("Index");
            }
            return View();
        }
           

            

        // GET: NhacSi/Edit/5
        public ActionResult Edit(int id)
        {
            NhacSi ns = listNhacSi.Find(x => x.id == id);
            return View(ns);
        }

        // POST: NhacSi/Edit/5
        [HttpPost]
        public ActionResult Edit(NhacSi ns)
        {
            if (ns.Imageupload!=null)
            {
                    string fileName = Path.GetFileNameWithoutExtension(ns.Imageupload.FileName);
                    string extension = Path.GetExtension(ns.Imageupload.FileName);
                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg"
                        && extension != ".JPG" && extension != ".PNG" && extension != ".JPEG")
                    {
                    TempData["err"] = "vui lòng chọn ảnh đúng định dạng";
                        return Redirect("/NhacSi/Create");
                    }
                    fileName = fileName + extension;
                    ns.image = "~/Content/images/" + fileName;
                    ns.Imageupload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    NhacSiDAO nhacsidao = new NhacSiDAO();
                    nhacsidao.updateNhacSi(ns);
                    return RedirectToAction("Index");

            }
            else
            {
                NhacSiDAO nhacsidao = new NhacSiDAO();
                nhacsidao.updateNhacSiWithoutImage(ns);
                return RedirectToAction("Index");
            }
          
        }

        // GET: NhacSi/Delete/5
        public ActionResult Delete(int id)
        {
            NhacSi ns = listNhacSi.Find(x => x.id == id);
            return View(ns);
        }

        // POST: NhacSi/Delete/5
        [HttpPost]
        public ActionResult Delete( NhacSi ns)
        {
            NhacSiDAO nhacsidao = new NhacSiDAO();
            if (Session["username"] == null)
                return Redirect("/Auth/DangNhap");
            if (!nhacsidao.deleteNhacSi(ns))
            {
                @TempData["err"] = "Không thể xoá nhạc sĩ này";
            }
            
            return RedirectToAction("Index");
        }
    }
}

