using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcShoppingCar.Models
{
    public class Cart
    {
        [DisplayName("選購商品")]
        [Required]
        public Product product { get; set; }

        [DisplayName("選購數量")]
        [Required]
        public int amount { get; set; }
    }
}