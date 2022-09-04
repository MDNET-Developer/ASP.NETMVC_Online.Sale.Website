using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_ONLINE_SATIS.Models.Sinifler;

namespace MVC_ONLINE_SATIS.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialSignUp()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialSignUp(Musteriler ms)
        {
            db.Musterilers.Add(ms);
            db.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult MusteriLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriLogin( Musteriler m)
        {
            var veriler = db.Musterilers.FirstOrDefault(x => x.MusteriMail == m.MusteriMail && x.MusteriSifre == m.MusteriSifre);
            if (veriler != null)
            {
                FormsAuthentication.SetAuthCookie(veriler.MusteriMail, false);
                Session["MusteriMail"] = veriler.MusteriMail.ToString();
                return RedirectToAction("Index", "MusteriPanel");
            }
            return RedirectToAction("Index","Login");
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var verilenler = db.Admins.FirstOrDefault(y => y.IstifadeciAd == a.IstifadeciAd && y.Sifre == a.Sifre);
    
            if (verilenler != null)
            {
                FormsAuthentication.SetAuthCookie(verilenler.IstifadeciAd, false);
                Session["IstifadeciAd"] = verilenler.IstifadeciAd.ToString();
                return RedirectToAction("Index", "AdminProfile");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}