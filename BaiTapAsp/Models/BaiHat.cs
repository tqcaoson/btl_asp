using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
    public class BaiHat
    {
        public int Id { get; set; }
        public int Id_nhacsi { get; set; }
        public int Id_dongnhac { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên bài hát")]
        [Display(Name = "Tên nhạc sĩ")]
        public string Ten_bai_hat { get; set; }
        public DateTime NgayDang { get; set; }
        [Range(0, Int64.MaxValue, ErrorMessage = "Vui lòng nhập lại lượt nghe")]
        public int LuotNghe { get; set; }

        public BaiHat ()
        {
        }

        public BaiHat (int id, int id_ns, int id_dn, string tenbh, DateTime ngay, int luotnghe)
        {
            this.Id = id;
            this.Id_nhacsi = id_ns;
            this.Id_dongnhac = id_dn;
            this.Ten_bai_hat = tenbh;
            this.NgayDang = ngay;
            this.LuotNghe = luotnghe;
        }

        public BaiHat (int id_ns, int id_dn, string tenbh, DateTime ngay, int luotnghe)
        {
            this.Id_nhacsi = id_ns;
            this.Id_dongnhac = id_dn;
            this.Ten_bai_hat = tenbh;
            this.NgayDang = ngay;
            this.LuotNghe = luotnghe;
        }
    }
}