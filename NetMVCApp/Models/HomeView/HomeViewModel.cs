using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMVCApp.Models
{
  // ViewModeller veri tabanı nesneleri arayüz nesnelerinin kapsayıcısı olması lazım.
  public class HomeViewModel
  {
    public HomeModel HomeModel { get; set; }
    public UserModel UserModel { get; set; }

    public List<EmployeeModel> Employees { get; set; }


  }
}