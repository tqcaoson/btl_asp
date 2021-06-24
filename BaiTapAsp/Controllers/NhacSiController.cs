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
        public ActionResult Index(string name_find)
        {
            NhacSiDAO nhacsidao = new NhacSiDAO();
            List<NhacSi> listNhacSi = nhacsidao.getAllNhacSi();

            if (!string.IsNullOrEmpty(name_find))
            {
                listNhacSi = nhacsidao.getNhacSiByName(name_find);
            }

            return View(listNhacSi);


        }

        // GET: NhacSi/Details/5
        public ActionResult Details(int id)
        {
            NhacSiDAO nhacsidao = new NhacSiDAO();
            NhacSi ns = nhacsidao.getNhacSiByID(id);
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
                if (ns.image != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ns.Imageupload.FileName);
                    string extension = Path.GetExtension(ns.Imageupload.FileName);
                    fileName = fileName + extension;
                    ns.image = "~/Content/images/" + fileName;
                    ns.Imageupload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    NhacSiDAO nhacsidao = new NhacSiDAO();
                    nhacsidao.insertNhacSi(ns);
                    return RedirectToAction("Index");
                }

            }
            else return View();
            return View();
        }




        // GET: NhacSi/Edit/5
        public ActionResult Edit(int id)
        {
            NhacSiDAO nhacsidao = new NhacSiDAO();
            NhacSi ns = nhacsidao.getNhacSiByID(id);
            return View(ns);
        }

        // POST: NhacSi/Edit/5
        [HttpPost]
        public ActionResult Edit(NhacSi ns)
        {
            if (ModelState.IsValid)
            {
                if (ns.image != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ns.Imageupload.FileName);
                    string extension = Path.GetExtension(ns.Imageupload.FileName);
                    fileName = fileName + extension;
                    ns.image = "~/Content/images/" + fileName;
                    ns.Imageupload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    NhacSiDAO nhacsidao = new NhacSiDAO();
                    nhacsidao.updateNhacSi(ns);
                    return RedirectToAction("Index");
                }

            }
            else return View();
            return View();
        }

        // GET: NhacSi/Delete/5
        public ActionResult Delete(int id)
        {
            NhacSiDAO nhacsidao = new NhacSiDAO();
            NhacSi ns = nhacsidao.getNhacSiByID(id);
            return View(ns);
        }

        // POST: NhacSi/Delete/5
        [HttpPost]
        public ActionResult Delete(NhacSi ns)
        {
            NhacSiDAO nhacsidao = new NhacSiDAO();
            nhacsidao.deleteNhacSi(ns);
            return RedirectToAction("Index");
        }
    }
}
