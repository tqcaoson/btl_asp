using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapAsp.ModelShow
{
    public class BaiHatShow
    {
        public int Id { get; set; }
        public string Ten_NhacSi { get; set; }
        public string Ten_bai_hat { get; set; }
        public string Ten_DongNhac { get; set; }
        public DateTime NgayDang { get; set; }
        public int LuotNghe { get; set; }

        public BaiHatShow ()
        {

        }
    }
}