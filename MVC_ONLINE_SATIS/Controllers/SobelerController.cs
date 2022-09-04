using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;

namespace MVC_ONLINE_SATIS.Controllers
{
    public class SobelerController : Controller
    {
        Context db = new Context();
        // GET: Sobeler
        public ActionResult Index()
        {
            var sobeler = db.Sobelers.Where(x=>x.Veziyyet==true).ToList();
            return View(sobeler);
        }
        [HttpGet]
        public ActionResult YeniSobeler()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSobeler( Sobeler s)
        {
            db.Sobelers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SobeSil(int id)
        {
            var sb = db.Sobelers.Find(id);
            sb.Veziyyet = false;
            db.SaveChanges();
            return RedirectToAction("Index","Sobeler");
        }
        public ActionResult SobeGetir(int id)
        {
            var sbl = db.Sobelers.Find(id);
            return View("SobeGetir", sbl);
        }
        public ActionResult SobeYenile(Sobeler sv)
        {
            var sblr = db.Sobelers.Find(sv.SobeID);
            sblr.SobeAd = sv.SobeAd;
            sblr.Veziyyet = sv.Veziyyet;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detallar(int id)
        {
            var dtl = db.Iscilers.Where(x => x.SobeID == id).ToList();
            var sobead = db.Sobelers.Where(x => x.SobeID == id).Select(y => y.SobeAd).FirstOrDefault();
            ViewBag.sblad = sobead;
            var iscisay = db.Iscilers.Where(x=>x.SobeID==id).Count();
            ViewBag.say = iscisay;
            return View(dtl);
        }
        public ActionResult SobeIsciSatis(int id)
        {
           

            var isci = db.Iscilers.Where(x => x.IsciID == id).Select(y => y.IsciAd + y.IsciSoyad).FirstOrDefault();
            ViewBag.worker = isci;

            var satissayi = db.SatisHerekets.Where(x => x.IsciID == id).Count();
            ViewBag.say = satissayi;
            var sts = db.SatisHerekets.Where(x => x.IsciID == id).ToList();
            return View(sts);
        }
    }
}