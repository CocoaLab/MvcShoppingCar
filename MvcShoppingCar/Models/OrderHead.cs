using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcShoppingCar.Models
{
    [DisplayName("訂單主檔")]
    [DisplayColumn("Name")]
    public class OrderHead
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("訂購會員")]
        [Required]
        public Member member { get; set; }

        [DisplayName("收件人")]
        [Required(ErrorMessage = "請輸入收件人姓名")]
        [MaxLength(40, ErrorMessage = "不可超過40個字元")]
        [Description("訂購會員不一定是收商品的人")]
        public string contractname { get; set; }

        [DisplayName("聯絡電話")]
        [Required(ErrorMessage = "請輸入你的電話號碼")]
        [MaxLength(25, ErrorMessage = "不可超過25個字元")]
        [DataType(DataType.PhoneNumber)]
        public string contactPhoneNo { get; set; }

        [DisplayName("收件地址")]
        [Required(ErrorMessage = "請輸入商品送件地址")]
        public string contractAddress { get; set; }

        [DisplayName("訂單金額")]
        [Required]
        [DataType(DataType.Currency)]
        [Description("訂單金額可能會受商品優惠活動影響")]
        public int TotalPrice { get; set; }

        [DisplayName("訂購備註")]
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }

        [DisplayName("訂購時間")]
        public DateTime buyon { get; set; }

        [NotMapped]
        public string DisplayName 
        {
            get { return this.member.Name + "於" + this.buyon + "訂購的商品"; }
        }
    }
}