using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanSach.Models
{
    [MetadataType(typeof(AdminValidation))]
    public partial class QUANTRIVIEN
    {

    }

    public class AdminValidation
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng điền tên đăng nhập.")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập tối đa 50 ký tự.")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng điền mật khẩu.")]
        [StringLength(50, ErrorMessage = "Mật khẩu tối đa 50 ký tự.")]
        public string MatKhau { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng điền họ tên đầy đủ.")]
        [StringLength(100, ErrorMessage = "Họ tên tối đa 50 ký tự.")]
        public string HoTen { get; set; }
    }
}