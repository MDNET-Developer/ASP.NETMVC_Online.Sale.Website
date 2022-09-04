using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;

namespace MVC_ONLINE_SATIS.Controllers
{
    public class SadeDiaqramlarController : Controller
    {
        // GET: SadeDiaqramlar
        Context db = new Context();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Partial()
        {
            var kate = db.Kateqoriyas.ToList();
            return PartialView(kate);
        }
        public ActionResult Partial1()
        {
            var sehermusteri = from x in db.Musterilers
                               group x by x.MusteriSeher into g
                               select new SinifGroup
                               {
                                   Seher = g.Key,
                                   Say = g.Count()

                               };
            return PartialView(sehermusteri);
        }
        public ActionResult Partial2()
        {
            var departman = from y in db.Iscilers
                            group y by y.Sobeler.SobeAd into z
                            select new SinifQrup2
                            {
                                Sobeler = z.Key,
                                say = z.Count()
                            };
            return PartialView(departman);
        }
        public ActionResult Partial3()
        {
            var musteriler = db.Musterilers.Where(x => x.Veziyyet == true).ToList();
            return PartialView(musteriler);
        }
        public ActionResult PartialMehsul()
        {
            var mehs = db.Mehsullars.ToList();
            return PartialView(mehs);
        }
    }
}