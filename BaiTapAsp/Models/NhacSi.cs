using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
    public class NhacSi
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập họ và tên nhạc sĩ")]
        [Display(Name = "Tên nhạc sĩ")]
        public string fullName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ảnh nhạc sĩ")]
        [Display(Name = "Hình ảnh")]
        public string image { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ngày tháng năm sinh")]
        [Display(Name = "Ngày sinh")]
        public string dateofbirth { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập quê quán")]
        [Display(Name = "Quê quán")]
        public string address { get; set; }

        // thuoc tinh de upload hinh len nhung k luu
        [NotMapped]
        public HttpPostedFileBase Imageupload { get; set; }
        public NhacSi()
        {
            image = "~/Content/images/add.jpg";
        }

        public NhacSi(int id, string fullName, string image, string dateofbirth, string address)
        {
            this.id = id;
            this.fullName = fullName;
            this.image = image;
            this.dateofbirth = dateofbirth;
            this.address = address;
        }

        public NhacSi(string fullName, string image, string dateofbirth, string address)
        {
            this.fullName = fullName;
            this.image = image;
            this.dateofbirth = dateofbirth;
            this.address = address;
        }
    }
}
