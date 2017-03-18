using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
  public class LoginVM : IValidatableObject
  {
    [Required]
    //[MinLength(3)]
    public String UserName { get; set; }
    [Required]
    //[MinLength(6)]
    public String PassWord { get; set; }
    public bool LoginCheck()
    {
      bool CheckOK = false;
      //check with EntityFramework
      //另一方式可以把ViewModel放在EntityFramework Member's Model下,就不會太多層
      CheckOK = (this.UserName == "admin" && this.PassWord == "admin");      
      return CheckOK;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (LoginCheck())
      {
        yield return ValidationResult.Success;
      }
      else
      {
        yield return new ValidationResult("登入錯誤", new string[] { "UserName" });
      }
    }
  }
}