using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcShoppingCar.Models
{
   [DisplayName("商品類別")]
    [DisplayColumn("Name")]
    public class ProductCategory
    {
       [Key]
       public int Id { get; set; }

       [DisplayName("商品類別名稱")]
       [Required(ErrorMessage = "請輸入商品類別名稱")]
       [MaxLength(20, ErrorMessage = "類別名稱不可超過20個字")]
       public string Name { get; set; }
    }
}