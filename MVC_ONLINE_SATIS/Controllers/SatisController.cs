using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;
namespace MVC_ONLINE_SATIS.Controllers
{
    public class SatisController : Controller
    {
        Context db = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var satislar = db.SatisHerekets.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult Satiset()
        {
            List<SelectListItem> mehsul = (from x in db.Mehsullars.Where(x=>x.Stok>0).ToList()
                                           select new SelectListItem
                                           {
                                               Value = x.MehsulID.ToString(),
                                               Text ="Məhsul: " +x.MehsulAd + " / "+ " Marka: " + x.Marka +" / " + "Məhsul qiyməti: "  + x.SatisQiymet+ "AZN"
                                               + " / " + "Stok sayı: " + x.Stok

                                           }).ToList();
            ViewBag.mehsul = mehsul;
            List<SelectListItem> musteri = (from x in db.Musterilers.ToList()
                                           select new SelectListItem
                                           {
                                               Value = x.MusteriID.ToString(),
                                               Text = "Müştəri: " + x.MusteriAd + " " +                                     x.MusteriSoyad 


                                           }).ToList();
            List<SelectListItem> isci = (from x in db.Iscilers.ToList()
                                            select new SelectListItem
                                            {
                                                Value = x.IsciID.ToString(),
                                                Text = "İşçi: " + x.IsciAd + " " + x.IsciSoyad


                                            }).ToList();
            ViewBag.mehsul = mehsul;
            ViewBag.musteri = musteri;
            ViewBag.isci = isci;
            return View();
        }
        [HttpPost]
        public ActionResult Satiset( SatisHereket sh)
        {
        
            sh.Tarix = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHerekets.Add(sh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}