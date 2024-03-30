using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TEST.Models.Members
{

    public class Members
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "帳號需介於6~30字")]
        [Remote("AccountCheck", ErrorMessage = "此帳號已被註冊")]
        public string Account { get; set; }
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
        [DisplayName("信箱")]
        [Required(ErrorMessage = "請輸入信箱")]
        [StringLength(200, ErrorMessage = "信箱不可超過200字")]
        [EmailAddress(ErrorMessage = "這不是Email格式")]
        public string Email { get; set; }
        public string AuthCode { get; set; }
        [DisplayName("身分")]
        public int Role { get; set; }
        public bool IsDelete { get; set; }
    }
}