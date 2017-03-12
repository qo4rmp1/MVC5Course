using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
  public class LoginVM
  {
    [Required]
    [MinLength(3)]
    public String UserName { get; set; }
    [Required]
    [MinLength(6)]
    public String PassWord { get; set; }
    public bool LoginCheck()
    {
      bool CheckOK = false;
      //check with EntityFramework
      //另一方式可以把ViewModel放在EntityFramework Member's Model下,就不會太多層
      return CheckOK;
    }
  }
}