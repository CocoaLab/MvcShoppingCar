using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcShoppingCar.Models
{
    [DisplayName("訂單明細")]
    [DisplayColumn("Name")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("訂單主檔")]
        [Required]
        public OrderHead orderhead { get; set; }

        [DisplayName("訂購商品")]
        [Required]
        public Product product { get; set; }

        [DisplayName("商品售價")]
        [Required(ErrorMessage="請輸入商品售價")]
        [Range(99,1000,ErrorMessage="商品金額需介於99~1000")]
        [Description("商品售價可能經常異動，需保留當下的商品售價")]
        [DataType(DataType.Currency)]
        public int price{get;set;}
    }
}