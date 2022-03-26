using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id)
        {
            var kategori = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MusteriGetir(int id)
        {
            var ktgr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", ktgr);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var ktgr = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            ktgr.MUSTERIAD = p1.MUSTERIAD;
            ktgr.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}