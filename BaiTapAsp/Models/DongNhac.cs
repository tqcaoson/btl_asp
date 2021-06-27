using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
	public class DongNhac
	{
		public int Id { get; set; }
		public string TenDongNhac { get; set; }

		public DongNhac(int id, string tenDongNhac)
		{
			Id = id;
			TenDongNhac = tenDongNhac;
		}
	}
}