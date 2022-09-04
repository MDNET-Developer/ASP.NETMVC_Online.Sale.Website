using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_ONLINE_SATIS.Models.Sinifler;

namespace MVC_ONLINE_SATIS.Controllers
{
    [Authorize]

    public class KateqoriyaController : Controller
    {
        // GET: Kateqoriya
        Context db = new Context();
       
        public ActionResult Index()
        {
            var kateqoriyalar = db.Kateqoriyas.ToList();
            return View(kateqoriyalar);
        }
       
        [HttpGet]
        public ActionResult YeniKateqoriya()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKateqoriya( Kateqoriya k)
        {
            db.Kateqoriyas.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index","Kateqoriya");
        }
        public ActionResult KateqoriyaSil(int id)
        {
            var ktg = db.Kateqoriyas.Find(id);
            db.Kateqoriyas.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index", "Kateqoriya");
        }
        public ActionResult KatiqoriyaYenilePage(int id)
        {
            var ktg = db.Kateqoriyas.Find(id);
            return View("KatiqoriyaYenilePage", ktg);
        }
        public ActionResult KateqoriyaYenileButton(Kateqoriya k)
        {
            var ktqr = db.Kateqoriyas.Find(k.KateqoriyaID);
            ktqr.KateqoriyaAd = k.KateqoriyaAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Kateqoriya");
        }
    }
}