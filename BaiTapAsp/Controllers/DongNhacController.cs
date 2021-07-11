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
			if (Session["username"] == null)
				return Redirect("/Auth/DangNhap");
			List<DongNhac> lists = dongnhacdao.getAllDongNhac();
			return View(lists);
		}

		// GET: DongNhac/Add/
		public ActionResult Create()
		{
			if (Session["username"] == null)
				return Redirect("/Auth/DangNhap");
			return View();
		}

		[HttpPost]
		public ActionResult Create(DongNhac dn)
		{
			if (Session["username"] == null)
				return Redirect("/Auth/DangNhap");
			if (ModelState.IsValid)
			{
				dongnhacdao.insertDongNhac(dn);
				return Redirect("/DongNhac");
			}
			else
			{
				return View();
			}
		}

		// GET: DongNhac/Edit/
		public ActionResult Edit(int id)
		{
			if (Session["username"] == null)
				return Redirect("/Auth/DangNhap");
			DongNhac dn = dongnhacdao.getDongNhacByID(id);
			return View(dn);
		}

		// POST: DongNhac/Edit/
		[HttpPost]
		public ActionResult Edit(DongNhac dn)
		{
			if (Session["username"] == null)
				return Redirect("/Auth/DangNhap");
			if (ModelState.IsValid)
			{
				dongnhacdao.updateDongNhac(dn);
				return Redirect("/DongNhac");
			}
			else
			{
				return View();
			}
		}

		public ActionResult Delete(int id)
		{
			if (Session["username"] == null)
				return Redirect("/Auth/DangNhap");
			dongnhacdao.deleteDongNhac(id);
			return Redirect("/DongNhac");
		}
	}
}