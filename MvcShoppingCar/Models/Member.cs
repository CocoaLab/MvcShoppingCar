using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcShoppingCar.Models
{
    [DisplayName("會員資料")]
    [DisplayColumn("Name")]
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("會員帳號")]
        [Required(ErrorMessage = "請輸入email adress")]
        [Description("我們採用email為帳號")]
        [MaxLength(250, ErrorMessage = "EMAIL長度不能超過250個字")]
        [DataType(DataType.EmailAddress)]
        [System.Web.Mvc.Remote("CheckDup","Member",HttpMethod="Post",ErrorMessage="此mail已經註冊過了")]
        public string email { get; set; }

        [DisplayName("會員密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [MaxLength(40, ErrorMessage = "密碼不可超過40")]
        [Description("密碼將以sha1加密")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DisplayName("中文姓名")]
        [Required(ErrorMessage = "請輸入中文姓名")]
        [MaxLength(5, ErrorMessage = "不可超過5個字元")]
        [Description("暫不提供外國人註冊")]
        public string Name { get; set; }

        [DisplayName("匿稱")]
        [Required(ErrorMessage = "請輸入匿稱")]
        [MaxLength(10, ErrorMessage = "不可超過10個字元")]
        public string nickname { get; set; }

        [DisplayName("註冊時間")]
        public DateTime RegisterOn { get; set; }

        [DisplayName("會員啟用認證")]
        [MaxLength(36)]
        [Description("當authcode,等於null則代表些會員已經通過驗證")]
        public string authcode { get; set; }


    }
}