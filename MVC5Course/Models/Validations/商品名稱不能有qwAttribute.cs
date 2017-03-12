using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Validations
{
  public class 商品名稱不能有qwAttribute:DataTypeAttribute
  {
    public 商品名稱不能有qwAttribute() :base(DataType.Text)
    {
      this.ErrorMessage = "商品名稱不能有qw字串";
    }
    public override bool IsValid(object value)
    {
      string str = Convert.ToString(value);

      if (str.Contains("qw"))
      {
        return false;
      }
      return true;
    }
  }
}