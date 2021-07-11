using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaiTapAsp.Models;
using System.Web.Mvc;

namespace BaiTapAsp.Controllers
{
    public class AuthController : Controller
    {
        AuthDAO dao = new AuthDAO();
        // GET: Auth
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            string user = Request.Form.Get("taikhoan");
            string pass = Request.Form.Get("matkhau");
            if (user == "" || pass == "")
            {
                TempData["err"] = "vui lòng nhập đủ các trường dữ liệu";
                return Redirect("/Auth/DangNhap");
            }
            if (!dao.login(user, pass))
            {
                TempData["err"] = "tài khoản mật khẩu sai";
                return Redirect("/Auth/DangNhap");
            }
            Session.Add("username", user);
            return Redirect("/Home");
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin()
        {
            string user = Request.Form.Get("taikhoan");
            string pass = Request.Form.Get("matkhau");
            string repass = Request.Form.Get("rematkhau");
            if(user == "" || pass == "" || repass == "")
            {
                TempData["err"] = "vui lòng nhập đủ các trường dữ liệu";
                return Redirect("/Auth/DangKy");
            }
            if (pass != repass)
            {
                TempData["err"] = "mật khẩu nhập lại không khớp";
                return Redirect("/Auth/DangKy");
            }
            if (!dao.checkunique(user))
            {
                TempData["err"] = "tài khoản đã tồn tại";
                return Redirect("/Auth/DangKy");
            }
            if (!dao.signin(user, pass))
            {
                TempData["err"] = "đăng ký thất bại";
                return Redirect("/Auth/DangKy");
            }
            return Redirect("/Auth/DangNhap");
        }
        public ActionResult LogOut()
        {
            Session.Remove("username");
            return Redirect("/Home");
        }
    }
}