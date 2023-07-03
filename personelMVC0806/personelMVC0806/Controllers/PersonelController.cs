using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personelMVC0806.ViewModels;
using personelMVC0806.Models.EntityFramework;
using System.Data.Entity;

namespace personelMVC0806.Controllers
{

    public class PersonelController : Controller
    {
        // GET: Personel
        PersonelDBEntities db = new PersonelDBEntities();
        public ActionResult Index()
        {
            var model = db.Personel.Include(x => x.Departman).ToList(); //Departmanlar tablosundaki bilgileri personnele ekleyip model olarak index view ına gönderdim.
            return View(model);
        }
        [HttpGet]
        public ActionResult Listele()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList()
            };
            return View("PersonelEkle",model);//indexismini değiştirdik aynı isimde olmazsa ismini göstermek zorundasın.Değilse gerek yok.
        }
        public ActionResult Kaydet(Personel personel)
        {
            if (personel.id==0)
            {
                db.Personel.Add(personel);
            }
            else
            {
                db.Entry(personel).State=EntityState.Modified;// bu satırda id bilgisini almadan o anki kaydın güncellemesini yapıyoruz
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            return View("PersonelEkle", model);
        }
        public ActionResult Sil(int id)
        {
            var model = db.Personel.Find(id);
            if (model == null)
                return HttpNotFound();

            db.Personel.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}