using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
namespace MvcShoppingCar.Models
{
    [DisplayName("商品資訊")]
    [DisplayColumn("Name")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("商品類別")]
        [Required]
        public ProductCategory producatCategory { get; set; }

        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "商品名稱不可空白")]
        [MaxLength(60, ErrorMessage = "商品名稱不可超過60個字")]
        public string Name { get; set; }

        [DisplayName("商品簡介")]
        [Required(ErrorMessage = "請輸入商品簡介")]
        [MaxLength(250, ErrorMessage = "商品簡介不可超過250個字")]
        public string Description { get; set; }

        [DisplayName("商品顏色")]
        [Required(ErrorMessage = "請選擇商顏色")]
        public Color color { get; set; }

        [DisplayName("商品售價")]
        [Required(ErrorMessage = "請輸入商品售價")]
        [Range(99, 10000, ErrorMessage = "商品售價必須介於99~10000之間")]
        public int price { get; set; }

        [DisplayName("上架時間")]
        [Description("如不設定上架時間，代表此商品永不上架")]
        public DateTime? PublishOn { get; set; }
    }
}