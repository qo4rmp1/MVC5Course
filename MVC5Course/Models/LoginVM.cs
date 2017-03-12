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
  }
}