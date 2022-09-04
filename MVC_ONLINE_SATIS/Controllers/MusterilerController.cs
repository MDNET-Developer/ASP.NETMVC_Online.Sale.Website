using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;
namespace MVC_ONLINE_SATIS.Controllers
{
    public class MusterilerController : Controller
    {
        Context db = new Context();
        // GET: Musteriler
        public ActionResult Index()
        {
            var musteriler = db.Musterilers.Where(x=>x.Veziyyet==true).ToList();
            return View(musteriler);
        }
        [HttpGet]
        public ActionResult YeniMusteriler()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteriButton( Musteriler ms)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteriler");
            }
            db.Musterilers.Add(ms);
            ms.Veziyyet = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Musteriler");
        }
        public ActionResult MusteriSIL(int id)
        {
            var m = db.Musterilers.Find(id);
            m.Veziyyet = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult MusteriGetir(int id)
        {
            var m = db.Musterilers.Find(id);
            return View(m);
        }
        public ActionResult UpdateBTN(Musteriler ms)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGetir");
            }
            var m1 = db.Musterilers.Find(ms.MusteriID);
            m1.MusteriAd = ms.MusteriAd;
            m1.MusteriSoyad = ms.MusteriSoyad;
            m1.MusteriSeher = ms.MusteriSeher;
            m1.MusteriMail = ms.MusteriMail;
            m1.Veziyyet = ms.Veziyyet;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detallar(int id)
        {
            var mstr = db.Musterilers.Where(x => x.MusteriID == id).Select(y => y.MusteriAd + " "+ y.MusteriSoyad).FirstOrDefault();
            ViewBag.musteri = mstr;
            var mhsl = db.SatisHerekets.Where(x => x.MusteriID == id).Count();
            ViewBag.mal = mhsl;
            var dtl = db.SatisHerekets.Where(x => x.MusteriID == id).ToList();
            return View(dtl);
        }
    }
}