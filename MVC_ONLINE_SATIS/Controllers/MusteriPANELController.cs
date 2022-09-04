using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;
using System.Web.Security;

namespace MVC_ONLINE_SATIS.Controllers
{
    public class MusteriPANELController : Controller
    {
        // GET: MusteriPANEL

        Context db = new Context();

        [Authorize]

        public ActionResult Index()
        {
        
            var m = (string)Session["MusteriMail"];
            var ad = (string)Session["MusteriAd"];
            var soyad = (string)Session["MusteriSoyad"];
            var sekil = db.Musterilers.Where(x => x.MusteriMail == m).Select(y => y.Musterifoto).FirstOrDefault();
            ViewBag.foto = sekil;
            var deyerler = db.Musterilers.Where(x => x.MusteriMail == m).ToList();

            return View(deyerler);
        }
        [Authorize]
        public ActionResult MusteriSifaris()
        {
            var mail = (string)Session["MusteriMail"];
            var id = db.Musterilers.Where(x => x.MusteriMail == mail).Select(y => y.MusteriID).FirstOrDefault();
            var sifarisler = db.SatisHerekets.Where(x => x.MusteriID == id).ToList();
            return View(sifarisler);
        }
        [Authorize]
        public ActionResult MusteriKarqo()
        {
            var mail = (string)Session["MusteriMail"];
            var id = db.Musterilers.Where(x => x.MusteriMail == mail).Select(x => x.MusteriID).FirstOrDefault();
            var karqo = db.KARQOs.Where(x => x.MusteriID == id).ToList();
            return View(karqo);
        }
        [Authorize]
        public ActionResult KarqoDetallar(string id)
        {
            var musteri = db.KARQOs.Where(x => x.KarqoSERIA == id).Select(x => x.Musteriler.MusteriAd + " " + x.Musteriler.MusteriSoyad).FirstOrDefault();
            ViewBag.musteri = musteri;
            var karqoseria = db.Karqo_DETALLARs.Where(x => x.KarqoSERIA == id).Select(x => x.KarqoSERIA).FirstOrDefault();
            ViewBag.seria = karqoseria;
            var detallar = db.Karqo_DETALLARs.Where(x => x.KarqoSERIA == id).ToList();
            return View(detallar);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        //********************Mesajlar********************//
        public ActionResult Mesajlar()//gelen
        {
            var mail = (string)Session["MusteriMail"];
            var x = db.Mesajlars.Where(m => m.Alici == mail).OrderBy(z=>z.Delete).ToList();
            return View(x);
        }

        public ActionResult GonderilenMesajlar()
        {
            var mail = (string)Session["MusteriMail"];
            var x = db.Mesajlars.Where(m => m.Gonderici == mail).ToList();
            return View(x);
        }

        public ActionResult MesajDetallar(int id)
        {
            //var x = db.Musterilers.Find(id);
            //var zx = db.Mesajlars.Find(z.MesajID);
            //z.Delete = true;
            //db.SaveChanges();
            //var s = db.Mesajlars.Find(id);
            var user = db.Mesajlars.Where(m => m.MesajID == id).Select(y => y.Gonderici).FirstOrDefault(); 
            var name = db.Musterilers.Where(a => a.MusteriMail == user).Select(y => y.Musterifoto).FirstOrDefault();
            ViewBag.sekil = name;



            var x = db.Mesajlars.Where(m => m.MesajID == id).ToList();
            return View(x);
        }

        public ActionResult MesajPartial( int id)
        {
            var m = db.Mesajlars.Find(id);
            return PartialView(m);
        }
        public ActionResult oxudum(Mesajlar z)
        {

            var zx = db.Mesajlars.Find(z.MesajID);
            zx.Delete = true;
            db.SaveChanges();
            return RedirectToAction("Mesajlar","MusteriPanel");
        }
        public ActionResult PartialMailMenu()
        {
            var mail = (string)Session["MusteriMail"];
            var gonderilenmesaj = db.Mesajlars.Where(a => a.Delete == false).Count(x => x.Alici == mail).ToString();
            ViewBag.mesaj1 = gonderilenmesaj;

            var gelenmesajlar = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.mesaj2 = gelenmesajlar;

            var silinenmesajlar = db.Mesajlars.Where(y => y.Delete == true).Count(y => y.Gonderici == mail).ToString();
            ViewBag.mesaj3 = silinenmesajlar;
            return PartialView();
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
     
       [HttpPost]
        public ActionResult MesajGonderButton(Mesajlar m)
        {
            var mail = (string)Session["MusteriMail"];
            db.Mesajlars.Add(m);
            m.Gonderici = mail;
            m.Tarix = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Delete = false;
            db.SaveChanges();

            return RedirectToAction("Mesajlar", "MusteriPANEL");
        }


        public ActionResult PartialUserTEST()
        {
            var m = (string)Session["MusteriMail"];
            var username = db.Musterilers.Where(x => x.MusteriMail == m).Select(y => y.MusteriAd + " " + y.MusteriSoyad).FirstOrDefault();
            ViewBag.murad = username;



            var sekil = db.Musterilers.Where(x => x.MusteriMail == m).Select(y => y.Musterifoto).FirstOrDefault();
            ViewBag.foto = sekil;
            return PartialView();
        }

        public ActionResult MehsullarFotoPartial()
        {
            var mail = (string)Session["MusteriMail"];
            var id = db.Musterilers.Where(x => x.MusteriMail == mail).Select(y => y.MusteriID).FirstOrDefault();
            var sifarisler = db.SatisHerekets.Where(x => x.MusteriID == id).ToList();
            return PartialView(sifarisler);
        }
    }
}