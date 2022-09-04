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
    [Authorize(Roles = "A")]
    public class FakturaController : Controller
    {
        // GET: Faktura
        Context db = new Context();
        public ActionResult Index()
        {
            var faktura = db.Fakturas.ToList();
            return View(faktura);
        }
        [HttpGet]
        public ActionResult YeniFaktura()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniFaktura(Faktura fk)
        {
            db.Fakturas.Add(fk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FakturaGetir(int id)
        {
            var fkt = db.Fakturas.Find(id);
            return View(fkt);
        }
        public ActionResult FakturaYenileButton(Faktura fk)
        {
            var f = db.Fakturas.Find(fk.FakturaID);
            f.FakturaSeriyaNo = fk.FakturaSeriyaNo;
            f.FakturaSiraNo = fk.FakturaSiraNo;
            f.Tarix = fk.Tarix;
            f.Saat = fk.Saat;
            f.VergiIdaresi = fk.VergiIdaresi;
            f.Teslimatci = fk.Teslimatci;
            f.Alici = fk.Alici;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FakturaDetallar(int id)
        {
            var fkd = db.FakturaQeyds.Where(x => x.FakturaID == id).ToList();
            return View(fkd);
        }
    }
}