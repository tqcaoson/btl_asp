using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
	public class DongNhac
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập tên dòng nhạc")]
		[Display(Name = "Tên dòng nhạc")]
		public string TenDongNhac { get; set; }

		public DongNhac(int id, string tenDongNhac)
		{
			Id = id;
			TenDongNhac = tenDongNhac;
		}

		public DongNhac()
		{

		}
	}
}