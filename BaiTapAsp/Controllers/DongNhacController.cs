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
		public ActionResult Index(string q)
		{
			if (Session["username"] == null)
				return Redirect("/Auth/DangNhap");

			List<DongNhac> lists;
			if (q == null)
			{
				lists = dongnhacdao.getAllDongNhac();
			}
			else
			{
				lists = dongnhacdao.findDongNhacByName(q);
			}
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
				if (!dongnhacdao.insertDongNhac(dn))
				{
					@TempData["err"] = "Không thể thêm dòng nhạc này";
				}
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
				if (!dongnhacdao.updateDongNhac(dn))
				{
					@TempData["err"] = "Không thể sửa dòng nhạc này";
				}
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
			if (!dongnhacdao.deleteDongNhac(id))
			{
				@TempData["err"] = "Không thể xoá dòng nhạc này";
			}
			return Redirect("/DongNhac");
		}
	}
}