using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;

namespace MVC_ONLINE_SATIS.Controllers
{
    public class StatiskaController : Controller
    {
        // GET: Statiska
        Context db = new Context();
        public ActionResult Index()
        {
            var musteri = db.Musterilers.Count().ToString();
            ViewBag.d1 = musteri;
            var mehsul = db.Mehsullars.Count().ToString();
            ViewBag.d2 = mehsul;
            var isci = db.Iscilers.Count().ToString();
            ViewBag.d3 = isci;
            var ktg = db.Kateqoriyas.Count().ToString();
            ViewBag.d4 = ktg;
            var stok = db.Mehsullars.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = stok;
            var markasay = (from x in db.Mehsullars select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = markasay;
            var kritik = db.Mehsullars.Count(x=>x.Stok<10).ToString();
            ViewBag.d7 = kritik;
            var baha = (from x in db.Mehsullars orderby x.SatisQiymet descending select x.MehsulAd + "/" + x.Marka).FirstOrDefault();
            ViewBag.d8 = baha;
            var ucuz = (from x in db.Mehsullars orderby x.SatisQiymet ascending select x.MehsulAd + "/" + x.Marka).FirstOrDefault();
            ViewBag.d9 = ucuz;
            var kassadakipul = db.SatisHerekets.Sum(x => x.UmumiXerc).ToString();
            ViewBag.d14 = kassadakipul;

            var encoxmarka = db.Mehsullars.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = encoxmarka;

            //var samsung = db.Mehsullars.Where(x => x.Marka == "SAMSUNG").Sum(y => y.Stok).ToString();
            //ViewBag.test = samsung;
            var encoxsatan = db.SatisHerekets.GroupBy(x => x.Mehsullars.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d13 = encoxsatan;
            //var coksatan = db.Mehsullars.Where(a => a.MehsulID == (db.SatisHerekets.GroupBy(x => x.MehsulID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(ms => ms.MehsulAd).FirstOrDefault();

            DateTime bugun = DateTime.Today;
            var bugunkusatis = db.SatisHerekets.Count(x => x.Tarix == bugun).ToString();
             ViewBag.d15 = bugunkusatis;
            
            var bugunkukassa = db.SatisHerekets.Where(y => y.Tarix== bugun).Sum(X => (decimal?)X.UmumiXerc).ToString();
                ViewBag.d16 = bugunkukassa;
            

            
  
           
            return View();
        }
        public ActionResult SadeDiaqramlar()
        {
            
            return View();
                               
        }
    }
}