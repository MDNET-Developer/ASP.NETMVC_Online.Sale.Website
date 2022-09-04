using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ONLINE_SATIS.Models.Sinifler;
using System.Web.Security;
namespace MVC_ONLINE_SATIS.Controllers

{
    [Authorize]
    public class IscilerController : Controller
    {
        Context db = new Context();
        // GET: Isciler
        public ActionResult Index()
        {
            var isciler = db.Iscilers.ToList();
            return View(isciler);
        }
        public ActionResult IsciYenile(int id)
        {
            List<SelectListItem> sobeler = (from x in db.Sobelers
                                            select new SelectListItem
                                            {
                                                Value=x.SobeID.ToString(),
                                                Text=x.SobeAd
                                            }).ToList();
            ViewBag.sobeler = sobeler;
            var isci = db.Iscilers.Find(id);
            return View(isci);
        }
        public ActionResult IsiciYenileButton(Isciler I)
        {
            var worker = db.Iscilers.Find(I.IsciID);
            worker.IsciAd = I.IsciAd;
            worker.IsciSoyad = I.IsciSoyad;
            worker.IsciFoto = I.IsciFoto;
            worker.SobeID = I.SobeID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniIsci()
        {
            List<SelectListItem> sobeler = (from x in db.Sobelers
                                            select new SelectListItem
                                            {
                                                Value = x.SobeID.ToString(),
                                                Text = x.SobeAd
                                            }).ToList();
            ViewBag.sobeler = sobeler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniIsci(Isciler s)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ICONS/" + filename + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                s.IsciFoto = "~/ICONS/" + filename + uzanti;
            }
            db.Iscilers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UmumiIsciler()
        {
            var isciler = db.Iscilers.ToList();
            return View(isciler);
        }
    }
}