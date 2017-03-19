namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Validations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }

    public partial class ProductMetaData
    {
        public int ProductId { get; set; }
        //可參考PDF(P62)
        [Required(ErrorMessage = "請輸入商品名稱{0}")]
        [DisplayName("商品名稱")]
        [StringLength(80, ErrorMessage = "欄位長度不得大於 80 個字元")]
        [商品名稱不能有qw]
        //可在1.這邊設定(ErrorMessage ="ProductNameCan'tContain qw")
        //2.覆寫"商品名稱不能有qwAttribute.cs/this.ErrorMessage"
        public string ProductName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "NT$ {0:N0}")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        [Range(0, 9999999999999)]
        public Nullable<decimal> Stock { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
