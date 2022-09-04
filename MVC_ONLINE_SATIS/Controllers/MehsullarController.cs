using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;

namespace MVC_ONLINE_SATIS.Controllers
{
    public class MehsullarController : Controller
    {
        // GET: Mehsullar
        Context db = new Context();
        public ActionResult Index()
        {
            var mehsullar = db.Mehsullars.Where(x=>x.Veziyyet==true).ToList();
            return View(mehsullar);
        }
        public ActionResult MehsulSil( int id)
        {
            var mehsl = db.Mehsullars.Find(id);
            mehsl.Veziyyet = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MehsulElaveEt()
        {
            List<SelectListItem> ktgr = (from x in db.Kateqoriyas
                                         select new SelectListItem
                                         {
                                             Value = x.KateqoriyaID.ToString(),
                                             Text = x.KateqoriyaAd
                                         }).ToList();
            ViewBag.vbktqr = ktgr;
            return View();
        }
        [HttpPost]
        public ActionResult MehsulElaveEt(Mehsullar m)
        {
            db.Mehsullars.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MehsulGetir(int id)
        {
            List<SelectListItem> ktgr = (from x in db.Kateqoriyas
                                         select new SelectListItem
                                         {
                                             Value = x.KateqoriyaID.ToString(),
                                             Text = x.KateqoriyaAd
                                         }).ToList();
            ViewBag.vbktqr = ktgr;
            var mehsul = db.Mehsullars.Find(id);
            return View("MehsulGetir", mehsul);
        }
        public ActionResult MehsulYenileButton(Mehsullar m)
        {
            var mhsl = db.Mehsullars.Find(m.MehsulID);
            mhsl.MehsulAd = m.MehsulAd;
            mhsl.Marka = m.Marka;
            mhsl.Stok = m.Stok;
            mhsl.AlisQiymet = m.AlisQiymet;
            mhsl.SatisQiymet = m.SatisQiymet;
            mhsl.Veziyyet = m.Veziyyet;
            mhsl.MehsulFoto = m.MehsulFoto;
            mhsl.KateqoriyaID = m.KateqoriyaID;
            db.SaveChanges();
            return RedirectToAction("Index", "Mehsullar");
        }
        [HttpGet]
        public ActionResult Sat( int id)
        {
            ViewBag.none = "none";
            ViewBag.block = "block";
            List<SelectListItem> isci = (from x in db.Iscilers.ToList()
                                         select new SelectListItem
                                         {
                                             Value = x.IsciID.ToString(),
                                             Text = "İşçi: " + x.IsciAd + " " + x.IsciSoyad


                                         }).ToList();
            ViewBag.isci = isci;

            //DateTime bugun = DateTime.Today;
            //ViewBag.tarix = bugun.ToString("dd/MM/yyyy");
            var Mehsul_ID = db.Mehsullars.Find(id);
            ViewBag.Mehsul_ID = Mehsul_ID.MehsulID;

            var mehsul = db.Mehsullars.Find(id);
            ViewBag.mehsul = mehsul.MehsulAd + "  " + mehsul.Marka;

            var qiymeti = db.Mehsullars.Find(id);
            ViewBag.qiymeti = qiymeti.SatisQiymet;

            var limit = db.Mehsullars.Find(id);
            ViewBag.limit = limit.Stok;
           
          
            

            return View();
        }
        [HttpPost]
        public ActionResult Sat(SatisHereket st)
        {
            st.Tarix = DateTime.Parse(DateTime.Now.ToShortTimeString());
            db.SatisHerekets.Add(st);
            db.SaveChanges();
            return RedirectToAction("Index","Mehsullar");
        }
        }
}