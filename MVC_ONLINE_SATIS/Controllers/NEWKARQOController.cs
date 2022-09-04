using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;

namespace MVC_ONLINE_SATIS.Controllers
{
    public class NEWKARQOController : Controller
    {
        // GET: NEWKARQO
        Context db = new Context();
        public ActionResult Index()
        {
            var deyerler = db.KARQOs.Where(x=>x.YesNo==true).ToList();
            return View(deyerler);
        }
        public ActionResult KarqoIscileri()
        {
        var isciler=    db.KarqoISCILERIs.ToList();
            return View(isciler);
        }
        [HttpGet]
        public ActionResult YeniKarqo()
        {
            Random rnd = new Random();
            string[] simvollar = { "A", "B", "C", "D", "E" ,"F","G","H"};
            int s1, s2, s3;
            s1 = rnd.Next(0, simvollar.Length);
            s2 = rnd.Next(0, simvollar.Length);
            s3 = rnd.Next(0,simvollar.Length);

            int n1, n2, n3;
            n1 = rnd.Next(0, 1000);
            n2 = rnd.Next(10, 99);
            n3 = rnd.Next(10, 99);
            var seria = simvollar[s1].ToString() + simvollar[s2].ToString() + simvollar[s3].ToString() + n1.ToString() + n2.ToString() + n3.ToString();
            ViewBag.seriakodu = seria;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKarqo(KARQO kqo)
        {
            db.KARQOs.Add(kqo);
            kqo.YesNo =true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KarqoDetallar(string id)
        {
            var karqoseria = db.KARQOs.Where(x=>x.KarqoSERIA==id).Select(x => x.KarqoSERIA).FirstOrDefault();
            ViewBag.seria = karqoseria;
            var detallar = db.Karqo_DETALLARs.Where(x => x.KarqoSERIA == id).ToList();
            return View(detallar);
        }
        [HttpGet]
        public ActionResult YeniDetal(string id)
        {

            var karqoseria = db.Karqo_DETALLARs.Where(x => x.KarqoSERIA == id).Select(x => x.KarqoSERIA).FirstOrDefault();
            ViewBag.seria = karqoseria;
            return View(karqoseria);
        }
        
        [HttpPost]
        public ActionResult YeniDetal(Karqo_DETALLAR dt)
        {
            db.Karqo_DETALLARs.Add(dt);
            db.SaveChanges();
            return RedirectToAction("Index","NEWKARQO");
        }
    }
}