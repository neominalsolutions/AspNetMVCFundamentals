using NetMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NetMVCApp.Controllers
{
  // ControllerName/ActionName
  //[RoutePrefix("/")]
  public class HomeController : Controller
  {
    // GET: Home
    // gelen isteği /Controller/Action/id route yönlendirme formatında alır. 2.kısımdaki action controller içerisindeki methoda ismine denk gelir. ve ilgili method bir sayfa döndürür. 
    [Route("")]
    public ActionResult Index()
    {
      // veri tabanı üzerinden bir model çekip view bu modeli gönderir. dinamik içeriği sahip view oluştururuz.
      //var model = new HomeViewModel();
      //model.Title = "Title-1";
      //model.Content = "Content-1";
      // view model göndermek için view methoduna modeli parametre olarak geçtik.

      // WebFormdaki ViewState çok benzer bir kullanım
      // view göndereceğimiz class model dışında extra bir data taşımak için tercih edilebilir. 
      // view birden fazla veri taşıma yöntemleri
      // 1.yöntem ViewBag
      ViewBag.Message = "Message-1"; // dynamic tipi sayesinde ViewBag.Degiskenİsmi istedeğimiz kadar view veri taşıyabiliriz.
      ViewBag.Success = true;
      ViewData["Alert"] = "Information";
      ViewBag.Names = new List<string>();
      ViewBag.Names.Add("Ali");
      ViewBag.Names.Add("Ahmet");
      ViewBag.PageUrl = $"/{HttpContext.Request.RequestContext.RouteData.Values["Controller"]}/{HttpContext.Request.RequestContext.RouteData.Values["Action"]}" ;

      // gelen request içinden action yada controller ismini okuma HttpContext.Request.RequestContext.RouteData.Values["Action"]


      // this.ControllerContext.RouteData.Values["action"].ToString();

      //ViewContext.RequestContext.RouteData["Controller"]

      // 2.Yöntem ise Tupple kullanımı
      // new {id:1,name:"ali"} anonim class olmayan bir obje
      //var model2 = Tuple.Create(new HomeModel { Title = "Title-1", Content = "Content-1"},new UserModel {Id=1,Name="ali"});

      // 3. kullanım şekli
      var model3 = new HomeViewModel
      {
        Employees = new List<EmployeeModel>
        {
          new EmployeeModel
          {
            Name = "Ali",
            Description = "Ali"
          },
           new EmployeeModel
          {
            Name = "Mehmet",
            Description = "Mehmet"
          }
        },
        HomeModel = new HomeModel
        {
          Title = "Home Page",
          Content = "Home Content"
        },
        UserModel = new UserModel
        {
          Id = 1,
          Name = "Ahmet"
        }
      };
      

      return View(model3);
    }


    //[HttpGet("iletisim-bilgileri")]

    [Route("iletisim-bilgileri")]
    // url bazlı yönlendirme attribute'ü
    public ActionResult Contact(string name, string description)
    {
      // mvc de querystring üzerinden değerleri okumak için route kısmında herhangi bir işlem yapmamıza gerek yok.
      return View();
    }

    [Route("hakkimizda/{id:int?}")] // hakkimizda/1 hakkimizda/2
    // int? route oluşturuken ? değeri ile route üzerinden gönderilecek parametreler opsiyonel olabilir. ? koymaz isek bunu zorunlu yapar. link olmadığından sayfa patlar.
    public ActionResult About(int? id)
    {
      return View();
    }


    [Route("htmlOrContent")]
    public ActionResult HtmlOrContentResult()
    {

      // veri tabananından bir html yada text içeriğini ekranda göstermek istersek kullanacağımız bir tip
      return Content("<h1>Deneme</h1>");
    }

    [Route("json")]
    public ActionResult JsonResult()
    {
      // JsonRequestBehavior.AllowGet döndürmeye izin ver
      // script ile bir saldırı olur diye böyle bir tanımlam yapılmış
      return Json(new { id = 1, name = "ali", surname = "tan" }, JsonRequestBehavior.AllowGet);
    }

    [Route("redirect-result")]
    public ActionResult RedirectResult()
    {
      // uygulamadaki eski ve kırık linkler için tercih ederiz.
      return Redirect("iletisim-bilgileri");
    }

    [Route("file-result")]
    public ActionResult FileResult()
    {

      return File("~/Content/MultiDbContext.pdf", "application/pdf");

      //return File("~/Content/Information.txt", "text/plain");
    }

    [Route("partial-view")]
    public ActionResult PartialHtmlResult()
    {
      // bazen uygulamada sadece belirli bir parça html kodu ekranda kullanmanız gerekebilir.
      // ilgili html dosya yolu üzerinden açmamı sağlayan bir yöntem.
      // partial view model gönderip dinamik hale getirebiliriz.
      return PartialView("_header",new UserModel() {  Id = 1, Name = "PartialView"});
    }

    //public bool Index()
    //{
    //  return true;
    //}
  }
}