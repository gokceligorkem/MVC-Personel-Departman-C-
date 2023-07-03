using personelMVC0806.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace personelMVC0806.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        PersonelDBEntities db = new PersonelDBEntities();
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm");
        }
        [HttpPost]
        public ActionResult Kaydet(Departman departman)
        {
            if (departman.id==0) //Yenikayıt
            {
                db.Departman.Add(departman);

            }
            else //id si olan kaydı güncelle
            {
                var guncellenecekdepartman=db.Departman.Find(departman.id);
                if (guncellenecekdepartman==null)
                {
                    return HttpNotFound();
                }
                guncellenecekdepartman.Ad = departman.Ad;
               
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Departman");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if(model==null)
                return HttpNotFound();
            return View("DepartmanForm",model);

        }
        public ActionResult Sil(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();

            db.Departman.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Index", "Departman");

        }
    }
}